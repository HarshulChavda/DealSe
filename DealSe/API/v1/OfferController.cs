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
using Microsoft.Data.SqlClient;
using DealSe.Data.SPModel;
using Microsoft.EntityFrameworkCore;

namespace DealSe.API.v1
{
    [ApiVersion("1.0")]
    [Produces("application/json")]
    [Authorize]
    [APIExceptionHandler]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class OfferController : ControllerBase
    {
        private readonly DealSeContext dataContext;
        private readonly IOfferService OfferService;
        private readonly IWebHostEnvironment hostingEnvironment;
        private readonly IOptions<CustomSettings> config;
        private readonly IMapper mapper;
        public OfferController(DealSeContext dataContext, IOfferService OfferService, IWebHostEnvironment hostingEnvironment, IOptions<CustomSettings> config, IMapper mapper)
        {
            this.dataContext = dataContext;
            this.OfferService = OfferService;
            this.hostingEnvironment = hostingEnvironment;
            this.config = config;
            this.mapper = mapper;
        }

        [Route("GetOfferList")]
        [ProducesResponseType(404)]
        [ProducesResponseType(200)]
        [HttpPost]
        public IActionResult GetOfferList(GetOfferListByStoreIdParamApiFormModel model)
        {
            ApiOkResponse apiModel = new ApiOkResponse();
            if (ModelState.IsValid)
            {

                List<GetOfferListByStoreIdReturnApiFormModel> getOfferListByStoreIdReturnApiFormModel = new List<GetOfferListByStoreIdReturnApiFormModel>();
                string baseURL = config.Value.BaseUrl;
                int pagesize = 10;

                //Get filtered product list
                SqlParameter[] parameters = new SqlParameter[3];
                parameters[0] = new SqlParameter("@StoreId", model.StoreId);
                parameters[1] = new SqlParameter("@PageIndex", model.PageIndex);
                parameters[2] = new SqlParameter("@PageSize", pagesize);

                var result = dataContext.GetOfferListByStoreId.FromSqlRaw("GetOfferListByStoreId @StoreId,@PageIndex,@PageSize", parameters).ToList();
                var mappedResult = mapper.Map<IEnumerable<GetOfferListByStoreIdSPModel>, IEnumerable<GetOfferListByStoreIdReturnApiFormModel>>(result);

                foreach (var item in mappedResult)
                {
                    foreach (var s in item.offerImagesLists)
                    {
                        if (s.OfferImage != null)
                        {
                            if (System.IO.File.Exists(Path.Combine(hostingEnvironment.WebRootPath, "Upload/Offer/" + item.OfferId, s.OfferImage)))
                                s.OfferImage = Path.Combine(baseURL + "Upload\\Offer\\" + item.OfferId, s.OfferImage);
                            else
                                s.OfferImage = Path.Combine(baseURL + "images", "icondefault.jpg");
                        }
                        else
                            s.OfferImage = Path.Combine(baseURL + "images", "icondefault.jpg");
                    }
                }

                getOfferListByStoreIdReturnApiFormModel = mappedResult.ToList();
                if (result.Any())
                {
                    apiModel = APIStatusHelper.Success(getOfferListByStoreIdReturnApiFormModel.ToList(), DealSeResource.DetailsLoaded.Replace("{0}", "Product List"));
                    return Ok(apiModel);
                }
                return NotFound(APIStatusHelper.NotFound());

            }
            return StatusCode((int)HttpStatusCode.Forbidden, APIStatusHelper.Forbidden("Model not valid"));
        }

        [Route("AddOffer")]
        [ProducesResponseType(404)]
        [ProducesResponseType(200)]
        [HttpPost]
        public async Task<IActionResult> AddOffer(AddOfferParamApiFormModel model)
        {
            ApiOkResponse apiModel = new ApiOkResponse();
            if (ModelState.IsValid)
            {
                AddOfferReturnApiFormModel addOfferReturnApiFormModel = new AddOfferReturnApiFormModel();
                var mappedResult = mapper.Map<AddOfferParamApiFormModel, Offer>(model);
                mappedResult.LimitedTimeOffer = false;
                mappedResult.Approved = false;
                mappedResult.Active = true;
                mappedResult.AddedDate = DateTime.Now;
                await OfferService.Create(mappedResult);
                addOfferReturnApiFormModel.OfferId = mappedResult.OfferId;
                apiModel = APIStatusHelper.Success(addOfferReturnApiFormModel, DealSeResource.InsertMessage.Replace("{0}", "Offer"));
                return Ok(apiModel);
            }
            return StatusCode((int)HttpStatusCode.Forbidden, APIStatusHelper.Forbidden("Model not valid"));
        }

        [Route("UpdateOffer")]
        [ProducesResponseType(404)]
        [ProducesResponseType(200)]
        [HttpPost]
        public async Task<IActionResult> UpdateOffer(UpdateOfferParamApiFormModel model)
        {
            ApiOkResponse apiModel = new ApiOkResponse();
            if (ModelState.IsValid)
            {
                var mappedResult = mapper.Map<UpdateOfferParamApiFormModel, Offer>(model);
                mappedResult.UpdatedDate = DateTime.Now;
                await OfferService.Update(mappedResult);
                apiModel = APIStatusHelper.Success(null, DealSeResource.UpdateMessage.Replace("{0}", "Offer"));
                return Ok(apiModel);
            }
            return StatusCode((int)HttpStatusCode.Forbidden, APIStatusHelper.Forbidden("Model not valid"));
        }
    }
}
