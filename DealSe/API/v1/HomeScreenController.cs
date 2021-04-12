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
using System.IO;
using Microsoft.AspNetCore.Hosting;
using System.Linq;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using DealSe.Domain.SPModel;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using DealSe.Shared.Common;

namespace DealSe.API.v1
{
    [ApiVersion("1.0")]
    [Produces("application/json")]
    [Authorize]
    [APIExceptionHandler]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class HomeScreenController : ControllerBase
    {
        private readonly DealSeContext dataContext;
        private readonly IAreaService areaService;
        private readonly IStoreTypeService storeTypeService;
        private readonly IMapper mapper;
        private readonly IOptions<CustomSettings> config;
        private readonly IUserService userService;
        public HomeScreenController(DealSeContext dataContext, IAreaService areaService, IStoreTypeService storeTypeService, IMapper mapper, IOptions<CustomSettings> config, IUserService userService)
        {
            this.dataContext = dataContext;
            this.areaService = areaService;
            this.storeTypeService = storeTypeService;
            this.mapper = mapper;
            this.config = config;
            this.userService = userService;
        }

        [Route("GetUserUsedOfferListByStore")]
        [ProducesResponseType(404)]
        [ProducesResponseType(200)]
        [HttpPost]
        public IActionResult GetUserUsedOfferListByStore(GetUserUsedOfferListByStoreParamApiModel model)
        {
            ApiOkResponse apiModel = new ApiOkResponse();
            if (ModelState.IsValid)
            {
                //Get filtered product list
                SqlParameter[] parameters = new SqlParameter[3];
                parameters[0] = new SqlParameter("@StoreId", model.storeId);
                parameters[1] = new SqlParameter("@PageIndex", model.pageIndex);
                parameters[2] = new SqlParameter("@PageSize", model.pageSize);

                List<GetUserUsedOfferListByStoreReturnApiModel> getUserUsedOfferListByStoreReturnApiModel = new List<GetUserUsedOfferListByStoreReturnApiModel>();
                var result = dataContext.GetUserUsedOfferListByStore.FromSqlRaw("GetUserUsedOfferListByStore @StoreId,@PageIndex,@PageSize", parameters).ToList();
                getUserUsedOfferListByStoreReturnApiModel = mapper.Map<List<GetUserUsedOfferListByStoreSPModel>, List<GetUserUsedOfferListByStoreReturnApiModel>>(result);

                apiModel = APIStatusHelper.Success(getUserUsedOfferListByStoreReturnApiModel, DealSeResource.DetailsLoaded.Replace("{0}", "User Used Offer"));
                return Ok(apiModel);
            }
            return StatusCode((int)HttpStatusCode.Forbidden, APIStatusHelper.Forbidden("Model not valid"));
        }

        [Route("GetAreaAndStoreTypeList")]
        [ProducesResponseType(404)]
        [ProducesResponseType(200)]
        [HttpPost]
        public IActionResult GetAreaAndStoreTypeList()
        {
            ApiOkResponse apiModel = new ApiOkResponse();
            GetAreaAndStoreTypeListReturnApiFormModel getAreaAndStoreTypeListReturnApiFormModel = new GetAreaAndStoreTypeListReturnApiFormModel();
            var areaList = areaService.GetMany(c => c.Active == true).OrderBy(c => c.Name).ToList();
            getAreaAndStoreTypeListReturnApiFormModel.areaListModel = mapper.Map<List<Area>, List<AreaListModel>>(areaList);
            var storeList = storeTypeService.GetMany(c => c.Active == true && c.Deleted == false).OrderBy(c => c.Name).ToList();
            getAreaAndStoreTypeListReturnApiFormModel.storeTypeApiModel = mapper.Map<List<StoreType>, List<StoreTypeListApiModel>>(storeList);

            apiModel = APIStatusHelper.Success(getAreaAndStoreTypeListReturnApiFormModel, DealSeResource.DetailsLoaded.Replace("{0}", "Area And StoreType List"));
            return Ok(apiModel);
        }
        
        // Get home screen details API method
        [Route("GetUserHomeScreenDetails")]
        [ProducesResponseType(404)]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(GetUserHomeScreenDetailsReturnApiFormModel), 200)]
        [HttpPost]
        public IActionResult GetUserHomeScreenDetails([FromQuery] GetUserHomeScreenDetailsParamsApiFormModel model)
        {
            ApiOkResponse apiModel = new ApiOkResponse();
            if(ModelState.IsValid)
            {
                GetUserHomeScreenDetailsReturnApiFormModel getUserHomeScreenDetailsReturnApiFormModel = new GetUserHomeScreenDetailsReturnApiFormModel();
                var baseURL = config.Value.BaseUrl;
                var areas = areaService.GetAllAreas(0);
                var categories = storeTypeService.GetAllStoreTypes(0);
;               var nearByPlaces = userService.GetUserNearByPlaces(0, model.UserLatitude, model.UserLogitude, 0 , baseURL);
                var limitedTimeOffers = GetLimitedTimeOffersSpResult(model.UserLatitude, model.UserLogitude, 0);
                if (areas.Count() > 0)  
                {
                    getUserHomeScreenDetailsReturnApiFormModel.Areas = mapper.Map<List<Service.Common.GetAreaList>, List<AreaListModel>>(areas);
                }
                if(categories.Count() > 0)
                {
                    getUserHomeScreenDetailsReturnApiFormModel.StoreTypes = mapper.Map<List<Service.Common.GetStoreTypeList>, List<StoreTypeListApiModel>>(categories);
                }
                if (nearByPlaces.Count() > 0)
                {
                    getUserHomeScreenDetailsReturnApiFormModel.UserNearByPlaces = mapper.Map<List<Service.Common.GetUserNearByPlaces>, List<UserNearByPlaces>>(nearByPlaces);
                }
                if(limitedTimeOffers.Count() > 0)
                {
                    getUserHomeScreenDetailsReturnApiFormModel.LimitedTimeOffers = limitedTimeOffers;
                }
                apiModel = APIStatusHelper.Success(getUserHomeScreenDetailsReturnApiFormModel, DealSeResource.DetailsLoaded.Replace("{0}", "User home screen details"));
                return Ok(apiModel);
            }
            return StatusCode((int)HttpStatusCode.Forbidden, APIStatusHelper.Forbidden("Model not valid"));
        }

        // Get areas by paging API method
        [Route("GetAreasByPaging")]
        [ProducesResponseType(404)]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(List<AreaListModel>), 200)]
        [HttpPost]
        public IActionResult GetAreasByPaging([FromQuery] int pageIndex)
        {
            ApiOkResponse apiModel = new ApiOkResponse();
            var areas = areaService.GetAllAreas(pageIndex);
            if (areas.Count() > 0)
            {
                var mappedData = mapper.Map<List<Service.Common.GetAreaList>, List<AreaListModel>>(areas);
                apiModel = APIStatusHelper.Success(mappedData, DealSeResource.DetailsLoaded.Replace("{0}", "Areas"));
                return Ok(apiModel);
            }
            return NotFound(APIStatusHelper.NotFound());
        }

        //Get categories by paging API methos
        [Route("GetCategoriesByPaging")]
        [ProducesResponseType(404)]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(List<StoreTypeListApiModel>), 200)]
        [HttpPost]
        public IActionResult GetCategoriesByPaging([FromQuery] int pageIndex)
        {
            ApiOkResponse apiModel = new ApiOkResponse();
            var categories = storeTypeService.GetAllStoreTypes(pageIndex);
            if (categories.Count() > 0)
            {
                var mappedData = mapper.Map<List<Service.Common.GetStoreTypeList>, List<StoreTypeListApiModel>>(categories);
                apiModel = APIStatusHelper.Success(mappedData, DealSeResource.DetailsLoaded.Replace("{0}", "Categories"));
                return Ok(apiModel);
            }
            return NotFound(APIStatusHelper.NotFound());
        }

        //Get limited time offers by paging API method
        [Route("GetLimitedTimeOffersByPaging")]
        [ProducesResponseType(404)]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(List<APIModel.GetLimitedTimeOffers>), 200)]
        [HttpPost]
        public IActionResult GetLimitedTimeOffersByPaging([FromQuery] decimal UserLatitude, decimal UserLongitude, int PageIndex)
        {
            ApiOkResponse apiModel = new ApiOkResponse();
            var limitedOffers = GetLimitedTimeOffersSpResult(UserLatitude, UserLongitude, PageIndex);
            if(limitedOffers.Count() > 0)
            {
                apiModel = APIStatusHelper.Success(limitedOffers, DealSeResource.DetailsLoaded.Replace("{0}", "Limited Offers"));
                return Ok(apiModel);
            }
            return NotFound(APIStatusHelper.NotFound());
        }

        //GetLimitedTimeOffers sp result
        [ApiExplorerSettings(IgnoreApi = true)]
        public List<APIModel.GetLimitedTimeOffers> GetLimitedTimeOffersSpResult(decimal UserLatitude, decimal UserLongitude, int PageIndex)
        {
            int pagesize = 10;
            var baseURL = config.Value.BaseUrl;
            SqlParameter[] parameters = new SqlParameter[4];
            parameters[0] = new SqlParameter("@UserLatitude", UserLatitude);
            parameters[1] = new SqlParameter("@UserLongitude", UserLongitude);
            parameters[2] = new SqlParameter("@PageIndex", PageIndex == 0 ? 1 : PageIndex);
            parameters[3] = new SqlParameter("@PageSize", pagesize);
            var spResult = dataContext.GetLimitedTimeOffers.FromSqlRaw("GetLimitedTimeOffers @UserLatitude,@UserLongitude,@PageIndex,@PageSize", parameters).ToList();
            List<APIModel.GetLimitedTimeOffers> limitedTimeOffers = new List<APIModel.GetLimitedTimeOffers>();
            if(spResult.FirstOrDefault().LimitedTimeOffers!=null)
            {
                limitedTimeOffers = JsonConvert.DeserializeObject<List<APIModel.GetLimitedTimeOffers>>(spResult.FirstOrDefault().LimitedTimeOffers.ToString());
                limitedTimeOffers = limitedTimeOffers.Select(top => 
                {
                    if (!(string.IsNullOrEmpty(top.Image)))
                    {
                        top.Image = baseURL + "Upload/Offer/" + top.OfferID + "/" + top.Image;
                    }
                    else
                    {
                        top.Image = string.Empty;
                    }
                    ; return top; 
                }).ToList();
            }
            return limitedTimeOffers;
        }
    }
}
