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
    public class OfferBannerController : ControllerBase
    {
        private readonly IOfferBannerService OfferBannerService;
        private readonly IWebHostEnvironment hostingEnvironment;
        private readonly IOptions<CustomSettings> config;
        private readonly IMapper mapper;
        public OfferBannerController(IOfferBannerService OfferBannerService, IWebHostEnvironment hostingEnvironment, IOptions<CustomSettings> config, IMapper mapper)
        {
            this.OfferBannerService = OfferBannerService;
            this.hostingEnvironment = hostingEnvironment;
            this.config = config;
            this.mapper = mapper;
        }

        [Route("AddOfferImage")]
        [ProducesResponseType(404)]
        [ProducesResponseType(200)]
        [HttpPost]
        public async Task<IActionResult> AddOfferImage([FromForm] AddOfferBannerParamApiFormModel model)
        {
            ApiOkResponse apiModel = new ApiOkResponse();
            if (ModelState.IsValid)
            {
                string offerImage = "";

                // Getting Image
                var image = model.OfferImage;
                // Saving Image on Server
                if (image != null)
                {
                    string targetDirectory = Path.Combine(hostingEnvironment.WebRootPath, "Upload/Offer/" + model.OfferId);

                    if (!Directory.Exists(targetDirectory))
                        Directory.CreateDirectory(targetDirectory);

                    string extension = Path.GetExtension(image.FileName);
                    offerImage = DateTime.Now.Ticks.ToString() + extension;
                    var imagePath = Path.Combine(targetDirectory, offerImage);

                    using (var fileStream = new FileStream(imagePath, FileMode.Create))
                    {
                        image.CopyTo(fileStream);
                    }
                }

                var mappedResult = mapper.Map<AddOfferBannerParamApiFormModel, OfferBanner>(model);
                mappedResult.Image = offerImage;
                mappedResult.Approved = false;
                mappedResult.Active = true;
                mappedResult.AddedDate = DateTime.Now;
                await OfferBannerService.Create(mappedResult);

                AddOfferBannerReturnApiFormModel addOfferBannerReturnApiFormModel = new AddOfferBannerReturnApiFormModel();
                addOfferBannerReturnApiFormModel.OfferBannerId = mappedResult.OfferBannerId;
                string baseURL = config.Value.BaseUrl;
                string offerImageUrl = Path.Combine(baseURL + "images", "default.jpg");
                if (System.IO.File.Exists(Path.Combine(hostingEnvironment.WebRootPath, "Upload/Offer/" + model.OfferId, offerImageUrl)))
                    offerImageUrl = Path.Combine(baseURL + "Upload\\Offer\\" + model.OfferId, offerImageUrl);
                addOfferBannerReturnApiFormModel.OfferImageUrl = offerImageUrl;

                apiModel = APIStatusHelper.Success(addOfferBannerReturnApiFormModel, DealSeResource.InsertMessage.Replace("{0}", "Offer Image"));
                return Ok(apiModel);
            }
            return StatusCode((int)HttpStatusCode.Forbidden, APIStatusHelper.Forbidden("Model not valid"));
        }

        [Route("DeleteOfferImage")]
        [ProducesResponseType(404)]
        [ProducesResponseType(200)]
        [HttpPost]
        public async Task<IActionResult> DeleteOfferImage(DeleteOfferBannerParamApiFormModel model)
        {
            ApiOkResponse apiModel = new ApiOkResponse();
            if (ModelState.IsValid)
            {
                //Delete old image
                var offerBannerData = await OfferBannerService.GetById(model.OfferBannerId);
                ImageProcessor.RemoveImageFromFolder("Upload/Offer", offerBannerData.Image);

                apiModel = APIStatusHelper.Success(null, DealSeResource.DeleteMessage.Replace("{0}", "Offer Image"));
                return Ok(apiModel);
            }
            return StatusCode((int)HttpStatusCode.Forbidden, APIStatusHelper.Forbidden("Model not valid"));
        }
    }
}
