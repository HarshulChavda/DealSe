using System;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using DealSe.API.v1.APIModel;
using DealSe.Common;
using DealSe.Domain.Models;
using DealSe.Service.Interface;
using DealSe.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using DealSe.Utils.Enum;
using DealSe.ExceptionFilter;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using DealSe.Domain.SPModel;
using System.Collections.Generic;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using DealSe.Shared.Common;
using Microsoft.AspNetCore.Http;
using System.IO;

namespace DealSe.API.v1
{
    [ApiVersion("1.0")]
    [Produces("application/json")]
    [Authorize]
    [APIExceptionHandler]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService userService;
        private readonly IMapper mapper;
        private readonly DealSeContext dataContext;
        private readonly IOptions<CustomSettings> config;
        private IWebHostEnvironment hostingEnvironment;
        private readonly INotificationService notificationService;

        public UserController(IUserService userService, IMapper mapper, DealSeContext dataContext, IOptions<CustomSettings> config, IWebHostEnvironment hostingEnvironment, INotificationService notificationService)
        {
            this.userService = userService;
            this.mapper = mapper;
            this.dataContext = dataContext;
            this.config = config;
            this.hostingEnvironment = hostingEnvironment;
            this.notificationService = notificationService;
        }

        //User Login API
        [Route("LoginForUserApp")]
        [ProducesResponseType(200)]
        [ProducesResponseType(401)]
        [ProducesResponseType(typeof(UserAddUpdateReturnApiModel), 200)]
        [HttpPost]
        public async Task<IActionResult> Login(LoginApiModel model)
        {
            ApiOkResponse apiOkResponse = new ApiOkResponse();
            if (ModelState.IsValid)
            {
                User user = new User();
                if (model.RegistrationType == (int)RegistrationType.Google)
                    user = await userService.CheckUserExists(model.RegistrationType, model.GooglePlusId);
                else if (model.RegistrationType == (int)RegistrationType.Facebook)
                    user = await userService.CheckUserExists(model.RegistrationType, model.FacebookId);
                else
                    user = await userService.CheckUserExistsBasedOnMobileNumber(model.MobileNumber);

                if (user != null)
                {
                    var userApiModel = mapper.Map<User, UserAddUpdateReturnApiModel>(user);
                    var baseURL = config.Value.BaseUrl;
                    var imagePath = "Upload/UserProfilePicture/";
                    if (!string.IsNullOrEmpty(userApiModel.Photo))
                    {
                        userApiModel.Photo = baseURL + imagePath + userApiModel.Photo;
                    }
                    else
                    {
                        userApiModel.Photo = baseURL + imagePath + "Default.png";
                    }
                    userApiModel.UserID = user.UserId;
                    apiOkResponse = APIStatusHelper.Success(userApiModel, "Welcome to DealSe!");
                    return Ok(apiOkResponse);
                }
                else
                {
                    UserAddUpdateReturnApiModel userAddUpdateReturnApiModel = new UserAddUpdateReturnApiModel();
                    apiOkResponse.Code = (int)HttpStatusCode.NotFound;
                    apiOkResponse.Message = "User is not yet registered";
                    apiOkResponse.Data = userAddUpdateReturnApiModel;
                    return Ok(apiOkResponse);
                }
            }
            return StatusCode((int)HttpStatusCode.Forbidden, APIStatusHelper.Forbidden("Model not valid"));
        }

        //Add user / registration API
        [Route("AddUserForUserApp")]
        [ProducesResponseType(404)]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(UserAddUpdateReturnApiModel), 200)]
        [HttpPost]
        public async Task<IActionResult> AddUser(UserParamApiFormModel model)
        {
            ApiOkResponse apiModel = new ApiOkResponse();
            try
            {
                if (ModelState.IsValid)
                {
                    UserAddUpdateReturnApiModel userApiModel = new UserAddUpdateReturnApiModel();
                    User user = new User();
                    if (model.RegistrationType == (int)RegistrationType.Google)
                        user = await userService.CheckUserExists(model.RegistrationType, model.GooglePlusId);
                    else if (model.RegistrationType == (int)RegistrationType.Facebook)
                        user = await userService.CheckUserExists(model.RegistrationType, model.FacebookId);
                    else
                        user = await userService.CheckUserExistsBasedOnMobileNumber(model.MobileNo);

                    if (user == null)
                    {
                        var mappedResult = mapper.Map<UserParamApiFormModel, User>(model);
                        mappedResult.Active = true;
                        mappedResult.AddedDate = DateTime.Now;
                        mappedResult.DeviceType = (int)UserDeviceType.Android;
                        await userService.Create(mappedResult);
                        userApiModel = mapper.Map<User, UserAddUpdateReturnApiModel>(mappedResult);
                        var baseURL = config.Value.BaseUrl;
                        var imagePath = "Upload/UserProfilePicture/";
                        if (!string.IsNullOrEmpty(userApiModel.Photo))
                        {
                            userApiModel.Photo = baseURL + imagePath + userApiModel.Photo;
                        }
                        else
                        {
                            userApiModel.Photo = baseURL + imagePath + "Default.png";
                        }
						userApiModel.UserID = mappedResult.UserId;
                        apiModel = APIStatusHelper.Success(userApiModel, DealSeResource.InsertMessage.Replace("{0}", "User"));
                        return Ok(apiModel);
                    }

                    userApiModel.UserID = user.UserId;
                    apiModel = APIStatusHelper.Found(userApiModel, DealSeResource.RecordExists.Replace("{0}", "User"));

                    //Send mobile notification
                    string notificationHeading = "Welcome, DealSe";
                    string notificationBody = "Let's Start Exploring Nearby Best Deals.";
                    string userNotificationCount = "0";
                    notificationService.SendMobileNotification((int)UserDeviceType.Android, "", model.DeviceID, notificationHeading, notificationBody, userNotificationCount);

                    return Ok(apiModel);
                }
                return StatusCode((int)HttpStatusCode.Forbidden, APIStatusHelper.Forbidden("Model not valid"));
            }
            catch (Exception)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, APIStatusHelper.InternalServerError());
            }
        }

        [Route("UpdateUserForUserApp")]
        [ProducesResponseType(404)]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(UserAddUpdateReturnApiModel), 200)]
        [HttpPut]
        public async Task<IActionResult> UpdateUser(UserUpdateParamApiModel model)
        {
            ApiOkResponse apiModel = new ApiOkResponse();
            try
            {
                if (ModelState.IsValid)
                {
                    var user = await userService.GetUser(model.UserID);
                    if (user != null)
                    {
                        var checkUserMobileExists = await userService.CheckUserMobileNoExists(model.UserID, model.MobileNo);
                        if (checkUserMobileExists != null)
                        {
                            apiModel = APIStatusHelper.Found(null, DealSeResource.RecordExists.Replace("{0}", "Mobile number"));
                        }
                        var checkUserEmailExists = await userService.CheckUserEmailExists(model.UserID, model.Email);
                        if (checkUserEmailExists != null)
                        {
                            apiModel = APIStatusHelper.Found(null, DealSeResource.RecordExists.Replace("{0}", "Email"));
                        }
                        var mappedData = mapper.Map(model, user);
                        mappedData.DeviceType = (int)UserDeviceType.Android;
                        await userService.Update(mappedData);
                        var usermappedData = mapper.Map<User, UserAddUpdateReturnApiModel>(mappedData);
                        var baseURL = config.Value.BaseUrl;
                        var imagePath = "Upload/UserProfilePicture/";
                        if (!string.IsNullOrEmpty(usermappedData.Photo))
                        {
                            usermappedData.Photo = baseURL + imagePath + usermappedData.Photo;
                        }
                        else
                        {
                            usermappedData.Photo = baseURL + imagePath + "Default.png";
                        }
                        apiModel = APIStatusHelper.Success(usermappedData, DealSeResource.UpdateMessage.Replace("{0}", "User"));
                        return Ok(apiModel);
                    }
                    else
                    {
                        return NotFound(APIStatusHelper.NotFound());
                    }
                }
                return StatusCode((int)HttpStatusCode.Forbidden, APIStatusHelper.Forbidden("Model not valid"));
            }
            catch (Exception)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, APIStatusHelper.InternalServerError());
            }
        }

        //Update user image
        [Route("UpdateUserImageForUserApp")]
        [ProducesResponseType(404)]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(UserUpdateImageReturnModel), 200)]
        [HttpPut]
        public async Task<IActionResult> UpdateUserImage(IFormFile file, int userID, bool isRemoveProfilePicture)
        {
            ApiOkResponse apiModel = new ApiOkResponse();
            try
            {
                var dbuser = await userService.GetById(userID);
                if (dbuser != null)
                {
                    var oldImage = dbuser.Photo;
                    if (isRemoveProfilePicture == false)
                    {
                        var stream = file.OpenReadStream();
                        var ext = file.FileName.Split(".").LastOrDefault();
                        var fName = DateTime.Now.Ticks + "." + ext;
                        var filePath = Path.Combine(hostingEnvironment.WebRootPath + "\\Upload\\UserProfilePicture", fName);
                        dbuser.Photo = fName;
                        using (var fileStream = new FileStream(filePath, FileMode.CreateNew))
                        {
                            await file.CopyToAsync(fileStream);
                        }
                        ImageProcessor.ResizeImage(filePath, 250, 250);
                    }
                    else
                    {
                        dbuser.Photo = null;
                    }
                    await userService.Update(dbuser);

                    if (oldImage != null)
                    {
                        string deletePath = Path.Combine(hostingEnvironment.WebRootPath + "\\Upload\\UserProfilePicture", oldImage);
                        if (System.IO.File.Exists(deletePath))
                        {
                            System.IO.File.Delete(deletePath);
                        }
                    }
                    UserUpdateImageReturnModel userUpdateImageReturnModel = new UserUpdateImageReturnModel();
                    var baseURL = config.Value.BaseUrl;
                    var imagePath = "Upload/UserProfilePicture/";
                    userUpdateImageReturnModel.Photo = baseURL + imagePath + dbuser.Photo;
                    apiModel = APIStatusHelper.Success(userUpdateImageReturnModel, DealSeResource.UpdateMessage.Replace("{0}", "User profile image"));
                    return Ok(apiModel);
                }
                else
                {
                    return NotFound(APIStatusHelper.NotFound());
                }
            }
            catch (Exception)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, APIStatusHelper.InternalServerError());
            }
        }

        //Get user used offer history
        [Route("GetUserUsedOfferHistoryForUserApp")]
        [ProducesResponseType(404)]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(GetUserUsedOfferHistoryReturnAPIModel), 200)]
        [HttpPost]
        public IActionResult GetUserUsedOfferHistory(GetUserUsedOfferParamAPIFormModel model)
        {
            ApiOkResponse apiOkResponse = new ApiOkResponse();
            int pagesize = 10;

            if (ModelState.IsValid)
            {
                SqlParameter[] parameters = new SqlParameter[3];
                parameters[0] = new SqlParameter("@UserID", model.UserId);
                parameters[1] = new SqlParameter("@PageIndex", model.PageIndex);
                parameters[2] = new SqlParameter("@PageSize", pagesize);
                var spResult = dataContext.GetUserUsedOfferHistoryModel.FromSqlRaw("GetUserUsedOfferHistory @UserID,@PageIndex,@PageSize", parameters).ToList();

                if (spResult.Count() > 0)
                {
                    var baseURL = config.Value.BaseUrl;
                    var mappedData = mapper.Map<IEnumerable<UserUsedOfferHistorySPModel>, IEnumerable<GetUserUsedOfferHistoryReturnAPIModel>>(spResult);
                    mappedData = mappedData.Select(top =>
                    {
                        if (!(string.IsNullOrEmpty(top.Image)))
                        {
                            top.Image = baseURL + "Upload/Store/Logo/" + top.Image;
                        }
                        else
                        {
                            top.Image = "";
                        }; return top;
                    }).ToList();
                    apiOkResponse = APIStatusHelper.Success(mappedData, DealSeResource.DetailsLoaded.Replace("{0}", "User used offer history"));

                    return Ok(apiOkResponse);
                }
                else
                {
                    return NotFound(APIStatusHelper.NotFound());
                }
            }
            return StatusCode((int)HttpStatusCode.Forbidden, APIStatusHelper.Forbidden("Model not valid"));
        }

        //Get offer details
        [Route("GetOfferDetailsForUserApp")]
        [ProducesResponseType(404)]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(GetOfferDetailsReturnAPIModel), 200)]
        [HttpPost]
        public IActionResult GetOfferDetails(GetOfferDetailsParamAPIModel model)
        {
            ApiOkResponse apiOkResponse = new ApiOkResponse();
            if (ModelState.IsValid)
            {
                var baseURL = config.Value.BaseUrl;

                SqlParameter[] parameters = new SqlParameter[1];
                parameters[0] = new SqlParameter("@OfferID", model.OfferID);
                var spResult = dataContext.GetOfferDetailsModel.FromSqlRaw("GetOfferDetails @OfferID", parameters).AsEnumerable();

                if (spResult != null)
                {
                    var mappedData = mapper.Map<GetOfferDetailsSPModel, GetOfferDetailsReturnAPIModel>(spResult.FirstOrDefault());
                    if (mappedData != null)
                    {
                        if (!string.IsNullOrEmpty(spResult.FirstOrDefault().OfferImages))
                        {
                            mappedData.OfferImages = JsonConvert.DeserializeObject<List<OfferImages>>(spResult.FirstOrDefault().OfferImages.ToString());
                            mappedData.OfferImages = mappedData.OfferImages.Select(top => { top.Image = baseURL + "Upload/Offer/" + mappedData.OfferID + "/" + top.Image; return top; }).ToList();
                        }
                        if (!string.IsNullOrEmpty(spResult.FirstOrDefault().StoreTimes))
                        {
                            mappedData.StoreTimes = JsonConvert.DeserializeObject<List<StoreTimes>>(spResult.FirstOrDefault().StoreTimes.ToString());
                        }
                        var nearByPlaces = userService.GetUserNearByPlaces(model.CategoryID, model.UserLatitude, model.UserLogitude, 0, baseURL);
                        mappedData.UserNearByPlaces = mapper.Map<List<Service.Common.GetUserNearByPlaces>, List<UserNearByPlaces>>(nearByPlaces);
                        apiOkResponse = APIStatusHelper.Success(mappedData, DealSeResource.DetailsLoaded.Replace("{0}", "Offer details"));
                        return Ok(apiOkResponse);
                    }
                }
                return NotFound(APIStatusHelper.NotFound());
            }
            return StatusCode((int)HttpStatusCode.Forbidden, APIStatusHelper.Forbidden("Model not valid"));
        }

        //Get near by places by paging
        //[Route("GetUserOfferDetailsNearByPlacesByPagingForUserApp")]
        //[ProducesResponseType(404)]
        //[ProducesResponseType(200)]
        //[ProducesResponseType(typeof(List<UserNearByPlaces>), 200)]
        //[HttpPost]
        //public IActionResult GetUserOfferDetailsNearByPlacesByPaging(GetUserNearByPlacesByPagingParamAPIModel model)
        //{
        //    var baseURL = config.Value.BaseUrl;
        //    ApiOkResponse apiOkResponse = new ApiOkResponse();
        //    var nearByPlaces = userService.GetUserNearByPlaces(model.AreaId, model.CategoryID, model.UserLatitude, model.UserLongitude, model.PageIndex, baseURL);
        //    if (nearByPlaces.Count() > 0)
        //    {
        //        var mappedData = mapper.Map<List<Service.Common.GetUserNearByPlaces>, List<UserNearByPlaces>>(nearByPlaces);
        //        apiOkResponse = APIStatusHelper.Success(mappedData, DealSeResource.DetailsLoaded.Replace("{0}", "User near by places"));
        //        return Ok(apiOkResponse);
        //    }
        //    return NotFound(APIStatusHelper.NotFound());
        //}

        //Generate QR code on redeem button
        //[Route("GenerateQRCodeForUserApp")]
        //[ProducesResponseType(404)]
        //[ProducesResponseType(200)]
        //[ProducesResponseType(typeof(List<UserNearByPlaces>), 200)]
        //[HttpPost]
        //public IActionResult GenerateQRCode()
        //{

        //}
    }
}
