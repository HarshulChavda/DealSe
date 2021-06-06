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
using DealSe.ExceptionFilter;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using System.Linq;
using System.Collections.Generic;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.SignalR;
using DealSe.Hubs;
using DealSe.Areas.Admin.ViewModels;
using DealSe.Shared.Common;
using DealSe.Utils.Enum;

namespace DealSe.API.v1
{
    [ApiVersion("1.0")]
    [Produces("application/json")]
    [Authorize]
    [APIExceptionHandler]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class StoreController : ControllerBase
    {
        private readonly IStoreService storeService;
        private readonly IAreaService areaService;
        private readonly IStoreTypeService storeTypeService;
        private readonly IUserUsedOfferService userUsedOfferService;
        private readonly IOfferService offerService;
        private readonly IHubContext<NotificationUserHub> notificationUserHubContext;
        private readonly INotificationService notificationService;
        private readonly IWebHostEnvironment hostingEnvironment;
        private readonly IOptions<CustomSettings> config;
        private readonly IMapper mapper;
        
        public StoreController(IStoreService storeService, IAreaService areaService, IStoreTypeService storeTypeService, IUserUsedOfferService userUsedOfferService, IOfferService offerService, IHubContext<NotificationUserHub> notificationUserHubContext, INotificationService notificationService, IWebHostEnvironment hostingEnvironment, IOptions<CustomSettings> config, IMapper mapper)
        {
            this.storeService = storeService;
            this.areaService = areaService;
            this.storeTypeService = storeTypeService;
            this.userUsedOfferService = userUsedOfferService;
            this.offerService = offerService;
            this.notificationUserHubContext = notificationUserHubContext;
            this.notificationService = notificationService;
            this.hostingEnvironment = hostingEnvironment;
            this.config = config;
            this.mapper = mapper;
        }

        [Route("CheckStoreMobieNumberExist")]
        [ProducesResponseType(404)]
        [ProducesResponseType(200)]
        [HttpPost]
        public async Task<IActionResult> CheckStoreMobieNumberExist(CheckStoreMobieNumberParamApiFormModel model)
        {
            ApiOkResponse apiModel = new ApiOkResponse();
            if (ModelState.IsValid)
            {
                CheckStoreMobieNumberReturnApiFormModel checkStoreMobieNumberReturnApiFormModel = new CheckStoreMobieNumberReturnApiFormModel();
                var storeDetails = await storeService.CheckStoreMobileNoExists(0, model.MobileNo);
                if (storeDetails == null)
                    checkStoreMobieNumberReturnApiFormModel.StoreId = null;
                else
                {
                    checkStoreMobieNumberReturnApiFormModel.StoreId = storeDetails.StoreId;
                    string baseURL = config.Value.BaseUrl;
                    string logoUrl = Path.Combine(baseURL + "images", "default.jpg");
                    if (!String.IsNullOrEmpty(storeDetails.Logo))
                        if (System.IO.File.Exists(Path.Combine(hostingEnvironment.WebRootPath, "Upload/Store/Logo", storeDetails.Logo)))
                            logoUrl = Path.Combine(baseURL + "Upload\\Store\\Logo", storeDetails.Logo);
                    checkStoreMobieNumberReturnApiFormModel = mapper.Map<Store, CheckStoreMobieNumberReturnApiFormModel>(storeDetails);
                    checkStoreMobieNumberReturnApiFormModel.LogoUrl = logoUrl;
                    checkStoreMobieNumberReturnApiFormModel.OldLogo = storeDetails.Logo;
                }

                var areaList = areaService.GetMany(c => c.Active == true).OrderBy(c => c.Name).ToList();
                checkStoreMobieNumberReturnApiFormModel.areaListModel = mapper.Map<List<Area>, List<AreaListModel>>(areaList);
                var storeList = storeTypeService.GetMany(c => c.Active == true && c.Deleted == false).OrderBy(c => c.Name).ToList();
                checkStoreMobieNumberReturnApiFormModel.storeTypeApiModel = mapper.Map<List<StoreType>, List<StoreTypeListApiModel>>(storeList);
                apiModel = APIStatusHelper.Found(checkStoreMobieNumberReturnApiFormModel, DealSeResource.RecordExists.Replace("{0}", "Store"));
                return Ok(apiModel);
            }
            return StatusCode((int)HttpStatusCode.Forbidden, APIStatusHelper.Forbidden("Model not valid"));
        }

        [Route("AddStore")]
        [ProducesResponseType(404)]
        [ProducesResponseType(200)]
        [HttpPost]
        public async Task<IActionResult> AddStore([FromForm] AddStoreParamApiFormModel model)
        {
            ApiOkResponse apiModel = new ApiOkResponse();
            if (ModelState.IsValid)
            {
                AddStoreReturnApiFormModel addStoreReturnApiFormModel = new AddStoreReturnApiFormModel();
                string logo = "";

                // Getting Image
                var image = model.Logo;
                // Saving Image on Server
                if (image != null)
                {
                    string targetDirectory = Path.Combine(hostingEnvironment.WebRootPath, "Upload/Store/Logo");

                    if (!Directory.Exists(targetDirectory))
                        Directory.CreateDirectory(targetDirectory);

                    string extension = Path.GetExtension(image.FileName);
                    logo = DateTime.Now.Ticks.ToString() + extension;
                    var imagePath = Path.Combine(targetDirectory, logo);

                    using (var fileStream = new FileStream(imagePath, FileMode.Create))
                    {
                        image.CopyTo(fileStream);
                    }
                }

                var mappedResult = mapper.Map<AddStoreParamApiFormModel, Store>(model);
                mappedResult.Logo = logo;
                mappedResult.Active = true;
                mappedResult.AddedDate = DateTime.Now;
                await storeService.Create(mappedResult);

                addStoreReturnApiFormModel.StoreId = mappedResult.StoreId;
                string baseURL = config.Value.BaseUrl;
                string logoUrl = Path.Combine(baseURL + "images", "default.jpg");
                if (System.IO.File.Exists(Path.Combine(hostingEnvironment.WebRootPath, "Upload/Store/Logo", logo)))
                    logoUrl = Path.Combine(baseURL + "Upload\\Store\\Logo", logo);
                addStoreReturnApiFormModel = mapper.Map<Store, AddStoreReturnApiFormModel>(mappedResult);
                addStoreReturnApiFormModel.LogoUrl = logoUrl;
                addStoreReturnApiFormModel.OldLogo = logo;

                var areaList = areaService.GetMany(c => c.Active == true).OrderBy(c => c.Name).ToList();
                addStoreReturnApiFormModel.areaListModel = mapper.Map<List<Area>, List<AreaListModel>>(areaList);
                var storeList = storeTypeService.GetMany(c => c.Active == true && c.Deleted == false).OrderBy(c => c.Name).ToList();
                addStoreReturnApiFormModel.storeTypeApiModel = mapper.Map<List<StoreType>, List<StoreTypeListApiModel>>(storeList);

                apiModel = APIStatusHelper.Success(addStoreReturnApiFormModel, DealSeResource.InsertMessage.Replace("{0}", "Store"));

                //Send new store notification to admin
                var sendStoreRegistrationToastrNotificationHubDetails = mapper.Map<Store, SendStoreRegistrationToastrNotificationHubViewModel>(mappedResult);
                sendStoreRegistrationToastrNotificationHubDetails.BaseUrl = config.Value.BaseUrl;
                var areaDetails = await areaService.GetById(mappedResult.AreaId);
                sendStoreRegistrationToastrNotificationHubDetails.AreaName = areaDetails.Name;
                await notificationUserHubContext.Clients.Groups("group_1").SendAsync("SendStoreRegistrationToastrNotificationToAdmin", sendStoreRegistrationToastrNotificationHubDetails);

                notificationService.SendMobileNotification((int)UserDeviceType.Android,"",model.DeviceID, "","","2");

                return Ok(apiModel);
            }
            return StatusCode((int)HttpStatusCode.Forbidden, APIStatusHelper.Forbidden("Model not valid"));
        }

        [Route("UpdateStore")]
        [ProducesResponseType(404)]
        [ProducesResponseType(200)]
        [HttpPost]
        public async Task<IActionResult> UpdateStore([FromForm] UpdateStoreParamApiFormModel model)
        {
            ApiOkResponse apiModel = new ApiOkResponse();
            if (ModelState.IsValid)
            {
                string logo = model.OldLogo;
                // Getting image
                var image = model.Logo;
                // Saving image on server
                if (image != null)
                {

                    //Delete old image
                    if (!String.IsNullOrEmpty(logo))
                        ImageProcessor.RemoveImageFromFolder("Upload/Store/Logo", logo);

                    //Add new image
                    string targetDirectory = Path.Combine(hostingEnvironment.WebRootPath, "Upload/Store/Logo");
                    if (!Directory.Exists(targetDirectory))
                        Directory.CreateDirectory(targetDirectory);

                    string extension = Path.GetExtension(image.FileName);
                    logo = DateTime.Now.Ticks.ToString() + extension;
                    var imagePath = Path.Combine(targetDirectory, logo);

                    using (var fileStream = new FileStream(imagePath, FileMode.Create))
                    {
                        image.CopyTo(fileStream);
                    }
                }

                var mappedResult = mapper.Map<UpdateStoreParamApiFormModel, Store>(model);
                mappedResult.Logo = logo;
                mappedResult.UpdatedDate = DateTime.Now;
                mappedResult.AddedDate = model.AddedDate;
                await storeService.Update(mappedResult);

                AddStoreReturnApiFormModel addStoreReturnApiFormModel = new AddStoreReturnApiFormModel();
                string baseURL = config.Value.BaseUrl;
                string logoUrl = Path.Combine(baseURL + "images", "default.jpg");
                if (!String.IsNullOrEmpty(logo))
                    if (System.IO.File.Exists(Path.Combine(hostingEnvironment.WebRootPath, "Upload/Store/Logo", logo)))
                        logoUrl = Path.Combine(baseURL + "Upload\\Store\\Logo", logo);

                addStoreReturnApiFormModel = mapper.Map<Store, AddStoreReturnApiFormModel>(mappedResult);
                addStoreReturnApiFormModel.LogoUrl = logoUrl;
                addStoreReturnApiFormModel.OldLogo = logo;

                var areaList = areaService.GetMany(c => c.Active == true).OrderBy(c => c.Name).ToList();
                addStoreReturnApiFormModel.areaListModel = mapper.Map<List<Area>, List<AreaListModel>>(areaList);
                var storeList = storeTypeService.GetMany(c => c.Active == true && c.Deleted == false).OrderBy(c => c.Name).ToList();
                addStoreReturnApiFormModel.storeTypeApiModel = mapper.Map<List<StoreType>, List<StoreTypeListApiModel>>(storeList);
                apiModel = APIStatusHelper.Success(addStoreReturnApiFormModel, DealSeResource.UpdateMessage.Replace("{0}", "Store"));
                return Ok(apiModel);
            }
            return StatusCode((int)HttpStatusCode.Forbidden, APIStatusHelper.Forbidden("Model not valid"));
        }

        [Route("ScanUserOffer")]
        [ProducesResponseType(404)]
        [ProducesResponseType(200)]
        [HttpPost]
        public async Task<IActionResult> ScanUserOffer(UserUsedOfferFormModel model)
        {
            ApiOkResponse apiModel = new ApiOkResponse();
            if (ModelState.IsValid)
            {
                var offerDetails = await offerService.GetById(model.OfferId);
                if (offerDetails.StoreId != model.StoreId)
                {
                    apiModel = APIStatusHelper.NotAcceptable(null, "This offer is not valid for your store");
                    return Ok(apiModel);
                }
                var userUsedOffer = await userUsedOfferService.CheckUserUsedOfferByUserIdOfferId(model.UserId, model.OfferId,model.StoreId);
                if (userUsedOffer != null)
                {
                    apiModel = APIStatusHelper.Found(null, "Already used offer");
                    return Ok(apiModel);
                }
                var mappedResult = mapper.Map<UserUsedOfferFormModel, UserUsedOffer>(model);
                mappedResult.Active = true;
                mappedResult.IsRedeem = true;
                mappedResult.AddedDate = DateTime.Now;
                mappedResult.RedeemDate = DateTime.Now;
                await userUsedOfferService.Create(mappedResult);
                apiModel = APIStatusHelper.Success(null, DealSeResource.InsertMessage.Replace("{0}", "Redeem successfully"));
                return Ok(apiModel);
            }
            return StatusCode((int)HttpStatusCode.Forbidden, APIStatusHelper.Forbidden("Model not valid"));
        }
    }
}
