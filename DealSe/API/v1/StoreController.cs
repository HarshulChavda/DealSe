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
using System.IO;
using Microsoft.AspNetCore.Hosting;
using System.Linq;
using System.Collections.Generic;
using Microsoft.Extensions.Options;

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
        private readonly IWebHostEnvironment hostingEnvironment;
        private readonly IOptions<CustomSettings> config;
        private readonly IMapper mapper;
        public StoreController(IStoreService storeService, IAreaService areaService, IStoreTypeService storeTypeService, IWebHostEnvironment hostingEnvironment, IOptions<CustomSettings> config, IMapper mapper)
        {
            this.storeService = storeService;
            this.areaService = areaService;
            this.storeTypeService = storeTypeService;
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
                    checkStoreMobieNumberReturnApiFormModel.StoreId = storeDetails.StoreId;

                var areaList = areaService.GetMany(c => c.Active == true).OrderBy(c => c.Name).ToList();
                checkStoreMobieNumberReturnApiFormModel.areaListModel = mapper.Map<List<Area>, List<AreaListModel>>(areaList);
                var storeList = storeTypeService.GetMany(c => c.Active == true && c.Deleted == false).OrderBy(c => c.Name).ToList();
                checkStoreMobieNumberReturnApiFormModel.storeTypeApiModel = mapper.Map<List<StoreType>, List<StoreTypeListApiModel>>(storeList);
                apiModel = APIStatusHelper.Success(checkStoreMobieNumberReturnApiFormModel, DealSeResource.RecordExists.Replace("{0}", "Store"));
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
                addStoreReturnApiFormModel.LogoUrl = logoUrl;
                
                apiModel = APIStatusHelper.Success(addStoreReturnApiFormModel, DealSeResource.InsertMessage.Replace("{0}", "Store"));
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
                string logo = "";
                // Getting image
                var image = model.Logo;
                // Saving image on server
                if (image != null)
                {
                    //Delete old image
                    var storeData = await storeService.GetById(model.StoreId);
                    ImageProcessor.RemoveImageFromFolder("Upload/Store/Logo", storeData.Logo);

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
                await storeService.Update(mappedResult);
                apiModel = APIStatusHelper.Success(null, DealSeResource.UpdateMessage.Replace("{0}", "Store"));
                return Ok(apiModel);
            }
            return StatusCode((int)HttpStatusCode.Forbidden, APIStatusHelper.Forbidden("Model not valid"));
        }
    }
}
