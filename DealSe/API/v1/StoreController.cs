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
        private readonly IMapper mapper;
        public StoreController(IStoreService storeService, IMapper mapper)
        {
            this.storeService = storeService;
            this.mapper = mapper;
        }

        //[Route("AddRetailer")]
        //[ProducesResponseType(404)]
        //[ProducesResponseType(200)]
        //[HttpPost]
        //public async Task<IActionResult> AddRetailer(RetailerParamApiFormModel model)
        //{
        //    ApiOkResponse apiModel = new ApiOkResponse();
        //    if (ModelState.IsValid)
        //    {
        //        RetailerApiModel RetailerApiModel = new RetailerApiModel();
        //        Retailer Retailer = new Retailer();
        //        if (model.RegistrationType == (int)RetailerRegistrationType.Google)
        //            Retailer = await RetailerService.CheckRetailerExists(model.RegistrationType, model.GooglePlusId);
        //        else
        //            Retailer = await RetailerService.CheckRetailerExists(model.RegistrationType, model.FacebookId);

        //        if (Retailer == null)
        //        {
        //            var mappedResult = mapper.Map<RetailerParamApiFormModel, Retailer>(model);
        //            mappedResult.Active = true;
        //            mappedResult.AddedDate = DateTime.Now;
        //            //mappedResult.DeviceType = (int)RetailerDeviceType.Android;
        //            await RetailerService.Create(mappedResult);
        //            RetailerApiModel.RetailerId = mappedResult.RetailerId;
        //            apiModel = APIStatusHelper.Success(RetailerApiModel, DealSeResource.InsertMessage.Replace("{0}", "Retailer"));
        //            return Ok(apiModel);
        //        }

        //        RetailerApiModel.RetailerId = Retailer.RetailerId;
        //        apiModel = APIStatusHelper.Success(RetailerApiModel, DealSeResource.RecordExists.Replace("{0}", "Retailer"));
        //        return Ok(apiModel);
        //    }
        //    return StatusCode((int)HttpStatusCode.Forbidden, APIStatusHelper.Forbidden("Model not valid"));
        //}
    }
}
