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
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using DealSe.Data.SPModel;

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
        private readonly IMapper mapper;
        public HomeScreenController(DealSeContext dataContext, IMapper mapper)
        {
            this.dataContext = dataContext;
            this.mapper = mapper;
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
                parameters[0] = new SqlParameter("@PageIndex", model.pageIndex);
                parameters[1] = new SqlParameter("@PageSize", model.pageSize);

                List<GetUserUsedOfferListByStoreReturnApiModel> getUserUsedOfferListByStoreReturnApiModel = new List<GetUserUsedOfferListByStoreReturnApiModel>();

                var result = dataContext.GetUserUsedOfferListByStore.FromSqlRaw("GetUserUsedOfferListByStore @PageIndex,@PageSize", parameters).ToList();
                getUserUsedOfferListByStoreReturnApiModel = mapper.Map<List<GetUserUsedOfferListByStoreSPModel>, List<GetUserUsedOfferListByStoreReturnApiModel>>(result);

                apiModel = APIStatusHelper.Success(getUserUsedOfferListByStoreReturnApiModel, DealSeResource.RecordExists.Replace("{0}", "UserUsedOffer"));
                return Ok(apiModel);
            }
            return StatusCode((int)HttpStatusCode.Forbidden, APIStatusHelper.Forbidden("Model not valid"));
        }
    }
}
