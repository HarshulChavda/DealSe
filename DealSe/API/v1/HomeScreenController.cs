using System.Net;
using AutoMapper;
using DealSe.API.v1.APIModel;
using DealSe.Common;
using DealSe.Domain.Models;
using DealSe.Service.Interface;
using DealSe.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using DealSe.ExceptionFilter;
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

        [Route("GetUserUsedOfferListByStoreForStoreApp")]
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

        [Route("GetAreaAndStoreTypeListForStoreApp")]
        [ProducesResponseType(404)]
        [ProducesResponseType(200)]
        [HttpPost]
        public IActionResult GetAreaAndStoreTypeList()
        {
            ApiOkResponse apiModel = new ApiOkResponse();
            GetAreaAndStoreTypeListReturnApiFormModel getAreaAndStoreTypeListReturnApiFormModel = new GetAreaAndStoreTypeListReturnApiFormModel();
            var areaList = areaService.GetMany(c => c.Active == true).OrderBy(c => c.Name).ToList();
            getAreaAndStoreTypeListReturnApiFormModel.areaListModel = mapper.Map<List<Area>, List<AreaListModelReturnApiFormModel>>(areaList);
            var storeList = storeTypeService.GetMany(c => c.Active == true && c.Deleted == false).OrderBy(c => c.Name).ToList();
            getAreaAndStoreTypeListReturnApiFormModel.storeTypeApiModel = mapper.Map<List<StoreType>, List<StoreTypeListReturnApiFormModel>>(storeList);

            apiModel = APIStatusHelper.Success(getAreaAndStoreTypeListReturnApiFormModel, DealSeResource.DetailsLoaded.Replace("{0}", "Area And StoreType List"));
            return Ok(apiModel);
        }
        
        // Get home screen details API method
        [Route("GetUserHomeScreenDetailsForUserApp")]
        [ProducesResponseType(404)]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(GetUserHomeScreenDetailsReturnApiFormModel), 200)]
        [HttpPost]
        public IActionResult GetUserHomeScreenDetails(GetUserHomeScreenDetailsParamsApiFormModel model)
        {
            ApiOkResponse apiModel = new ApiOkResponse();
            if(ModelState.IsValid)
            {
                GetUserHomeScreenDetailsReturnApiFormModel getUserHomeScreenDetailsReturnApiFormModel = new GetUserHomeScreenDetailsReturnApiFormModel();
                var baseURL = config.Value.BaseUrl;
                var areas = areaService.GetAllAreaForAPI(0);
                var categories = storeTypeService.GetAllStoreTypes(0);
;               var nearByPlaces = userService.GetUserNearByPlaces(model.StoreTypeId, model.UserLatitude, model.UserLogitude, 0 , baseURL);
                var limitedTimeOffers = GetLimitedTimeOffers(model.UserLatitude, model.UserLogitude, 0);
                if (areas.Count() > 0)  
                {
                    getUserHomeScreenDetailsReturnApiFormModel.Areas = mapper.Map<List<Service.Common.GetAreaListForAPI>, List<AreaListModelReturnApiFormModel>>(areas);
                }
                if(categories.Count() > 0)
                {
                    getUserHomeScreenDetailsReturnApiFormModel.StoreTypes = mapper.Map<List<Service.Common.GetStoreTypeList>, List<StoreTypeListReturnApiFormModel>>(categories);
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
        [ProducesResponseType(typeof(List<AreaListModelReturnApiFormModel>), 200)]
        [HttpPost]
        public IActionResult GetAreasByPaging(PageIndexApiFormModel pageIndexApiFormModel)
        {
            ApiOkResponse apiModel = new ApiOkResponse();
            var areas = areaService.GetAllAreaForAPI(pageIndexApiFormModel.PageIndex);
            if (areas.Count() > 0)
            {
                var mappedData = mapper.Map<List<Service.Common.GetAreaListForAPI>, List<AreaListModelReturnApiFormModel>>(areas);
                apiModel = APIStatusHelper.Success(mappedData, DealSeResource.DetailsLoaded.Replace("{0}", "Areas"));
                return Ok(apiModel);
            }
            return NotFound(APIStatusHelper.NotFound());
        }

        //Get categories by paging API methos
        [Route("GetCategoriesByPaging")]
        [ProducesResponseType(404)]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(List<StoreTypeListReturnApiFormModel>), 200)]
        [HttpPost]
        public IActionResult GetCategoriesByPaging(PageIndexApiFormModel pageIndexApiFormModel)
        {
            ApiOkResponse apiModel = new ApiOkResponse();
            var categories = storeTypeService.GetAllStoreTypes(pageIndexApiFormModel.PageIndex);
            if (categories.Count() > 0)
            {
                var mappedData = mapper.Map<List<Service.Common.GetStoreTypeList>, List<StoreTypeListReturnApiFormModel>>(categories);
                apiModel = APIStatusHelper.Success(mappedData, DealSeResource.DetailsLoaded.Replace("{0}", "Categories"));
                return Ok(apiModel);
            }
            return NotFound(APIStatusHelper.NotFound());
        }

        //Get limited time offers by paging API method
        [Route("GetLimitedTimeOffersByPagingForUserApp")]
        [ProducesResponseType(404)]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(List<GetLimitedTimeOffersReturnApiFormModel>), 200)]
        [HttpPost]
        public IActionResult GetLimitedTimeOffersByPaging(GetLimitedTimeOffersByPagingParamApiModel getLimitedTimeOffersByPagingParamApiModel)
        {
            ApiOkResponse apiModel = new ApiOkResponse();
            var limitedOffers = GetLimitedTimeOffers(getLimitedTimeOffersByPagingParamApiModel.UserLatitude, getLimitedTimeOffersByPagingParamApiModel.UserLongitude, getLimitedTimeOffersByPagingParamApiModel.PageIndex);
            if(limitedOffers.Count() > 0)
            {
                apiModel = APIStatusHelper.Success(limitedOffers, DealSeResource.DetailsLoaded.Replace("{0}", "Limited Offers"));
                return Ok(apiModel);
            }
            return NotFound(APIStatusHelper.NotFound());
        }

        //GetLimitedTimeOffers sp result
        [ApiExplorerSettings(IgnoreApi = true)]
        public List<GetLimitedTimeOffersReturnApiFormModel> GetLimitedTimeOffers(decimal userLatitude, decimal userLongitude, int pageIndex)
        {
            int pagesize = 10;
            var baseURL = config.Value.BaseUrl;
            SqlParameter[] parameters = new SqlParameter[4];
            parameters[0] = new SqlParameter("@UserLatitude", userLatitude);
            parameters[1] = new SqlParameter("@UserLongitude", userLongitude);
            parameters[2] = new SqlParameter("@PageIndex", pageIndex == 0 ? 1 : pageIndex);
            parameters[3] = new SqlParameter("@PageSize", pagesize);
            var spResult = dataContext.GetLimitedTimeOffers.FromSqlRaw("GetLimitedTimeOffers @UserLatitude,@UserLongitude,@PageIndex,@PageSize", parameters).ToList();
            List<GetLimitedTimeOffersReturnApiFormModel> limitedTimeOffers = new List<GetLimitedTimeOffersReturnApiFormModel>();
            if(spResult.FirstOrDefault().LimitedTimeOffers!=null)
            {
                limitedTimeOffers = JsonConvert.DeserializeObject<List<GetLimitedTimeOffersReturnApiFormModel>>(spResult.FirstOrDefault().LimitedTimeOffers.ToString());
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
