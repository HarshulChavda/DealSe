using System;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using DealSe.API.v1.APIModel;
using DealSe.Common;
using DealSe.Data.Models;
using DealSe.Service.Interface;
using DealSe.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using DealSe.Utils.Enum;
using DealSe.ExceptionFilter;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using DealSe.Data.SPModel;
using System.Collections.Generic;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

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

        public UserController(IUserService userService, IMapper mapper, DealSeContext dataContext, IOptions<CustomSettings> config)
        {
            this.userService = userService;
            this.mapper = mapper;
            this.dataContext = dataContext;
            this.config = config;
        }

        //User Login API
        [Route("Login")]
        [ProducesResponseType(200)]
        [ProducesResponseType(401)]
        [ProducesResponseType(typeof(GetProfileForm), 200)]
        [HttpPost]
        public async Task<IActionResult> Login(LoginApiModel model)
        {
            ApiOkResponse apiOkResponse = new ApiOkResponse();
            if (ModelState.IsValid)
            {
                GetProfileForm getProfileForm = new GetProfileForm();
                var checkUserExist = await userService.CheckUserExistsBasedOnMobileNumber(model.MobileNumber);
                if (checkUserExist != null)
                {
                    getProfileForm.IsRegistered = true;
                    apiOkResponse = APIStatusHelper.Success(getProfileForm, "Welcome to DealSe!");
                    return Ok(apiOkResponse);
                }
                else
                {
                    getProfileForm.IsRegistered = false;
                    apiOkResponse.Code = (int)HttpStatusCode.NotFound;
                    apiOkResponse.Message = "User is not yet registered";
                    apiOkResponse.Data = getProfileForm;
                    return Ok(apiOkResponse);
                }
            }
            return StatusCode((int)HttpStatusCode.Forbidden, APIStatusHelper.Forbidden("Model not valid"));
        }

        //Add user / registration API
        [Route("AddUser")]
        [ProducesResponseType(404)]
        [ProducesResponseType(200)]
        [HttpPost]
        public async Task<IActionResult> AddUser(UserParamApiFormModel model)
        {
            ApiOkResponse apiModel = new ApiOkResponse();
            if (ModelState.IsValid)
            {
                UserApiModel userApiModel = new UserApiModel();
                User user = new User();
                if (model.RegistrationType == (int)RegistrationType.Google)
                    user = await userService.CheckUserExists(model.RegistrationType, model.GooglePlusId);
                else if (model.RegistrationType == (int)RegistrationType.Facebook)
                    user = await userService.CheckUserExists(model.RegistrationType, model.FacebookId);
                else
                    user= await userService.CheckUserExistsBasedOnMobileNumber(model.MobileNo);

                if (user == null)
                {
                    var mappedResult = mapper.Map<UserParamApiFormModel, User>(model);
                    mappedResult.Active = true;
                    mappedResult.AddedDate = DateTime.Now;
                    await userService.Create(mappedResult);
                    userApiModel.UserId = mappedResult.UserId;
                    apiModel = APIStatusHelper.Success(userApiModel, DealSeResource.InsertMessage.Replace("{0}", "User"));
                    return Ok(apiModel);
                }

                userApiModel.UserId = user.UserId;
                apiModel = APIStatusHelper.Success(userApiModel, DealSeResource.RecordExists.Replace("{0}", "User"));
                return Ok(apiModel);
            }
            return StatusCode((int)HttpStatusCode.Forbidden, APIStatusHelper.Forbidden("Model not valid"));
        }

        //Get user used offer history
        [Route("GetUserUsedOfferHistory")]
        [ProducesResponseType(404)]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(GetUserUsedOfferHistoryReturnAPIModel), 200)]
        [HttpPost]
        public IActionResult GetUserUsedOfferHistory([FromQuery]GetUserUsedOfferParamAPIFormModel model)
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
        [Route("GetOfferDetails")]
        [ProducesResponseType(404)]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(GetOfferDetailsReturnAPIModel), 200)]
        [HttpPost]
        public IActionResult GetOfferDetails([FromQuery]GetOfferDetailsParamAPIModel model)
        {
            ApiOkResponse apiOkResponse = new ApiOkResponse();
            if(ModelState.IsValid)
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

        //Get near by places by Paging
        [Route("GetUserOfferDetailsNearByPlacesByPaging")]
        [ProducesResponseType(404)]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(List<UserNearByPlaces>), 200)]
        [HttpPost]
        public IActionResult GetUserOfferDetailsNearByPlacesByPaging([FromQuery] GetUserNearByPlacesByPagingParamAPIModel model)
        {
            var baseURL = config.Value.BaseUrl;
            ApiOkResponse apiOkResponse = new ApiOkResponse();
            var nearByPlaces = userService.GetUserNearByPlaces(model.CategoryID, model.UserLatitude, model.UserLongitude, model.PageIndex, baseURL);
            if(nearByPlaces.Count() > 0)
            {
                var mappedData = mapper.Map<List<Service.Common.GetUserNearByPlaces>, List<UserNearByPlaces>>(nearByPlaces);
                apiOkResponse = APIStatusHelper.Success(mappedData, DealSeResource.DetailsLoaded.Replace("{0}", "User near by places"));
                return Ok(apiOkResponse);
            }
            return NotFound(APIStatusHelper.NotFound());
        }
    }
}
