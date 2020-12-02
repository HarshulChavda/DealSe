using AutoMapper;
using MEPass.API.v1.APIModel;
using MEPass.Common;
using MEPass.Data.Models;
using MEPass.Data.SPModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace MEPass.API.v1
{
    [ApiVersion("1.0")]
    [Produces("application/json")]
    [Authorize]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class OrganiserController : ControllerBase
    {
        private readonly MEPassContext dataContext;
        private readonly IMapper mapper;
        private readonly IOptions<CustomSettings> config;
        public OrganiserController(MEPassContext dataContext, IMapper mapper, IOptions<CustomSettings> config)
        {
            this.dataContext = dataContext;
            this.mapper = mapper;
            this.config = config;
        }
        [Route("GetOrganiserDropdown")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [HttpGet]
        public IActionResult GetOrganiserDropdown()
        {
            var spResult = dataContext.GetAllOrganiserForDropdown.FromSqlRaw("GetAllOrganiserForDropdown").ToList();
            if (spResult.Any())
            {
                var mappedResult = mapper.Map<List<GetAllOrganiserForDropdown>, List<OrganiserDropDownApiModel>>(spResult);
                return Ok(APIStatusHelper.Success(mappedResult.ToList(), null));
            }
            return NotFound(APIStatusHelper.NotFound());
        }

        [Route("GetAllOrganiser")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [HttpGet]
        public IActionResult GetAllOrganiser([FromQuery]OrganiserListParamApiModel model)
        {            
            var spResult = dataContext.GetAllOrganiserForFront.FromSqlRaw("GetAllOrganiserForFront @OrganiserIdList", new[] {
                new SqlParameter("@OrganiserIdList", model.OrganiserIdList ?? (object)DBNull.Value)
            }).ToList();

            if (spResult.Any())
            {
                string baseURL = config.Value.BaseUrl;
                var mappedResult = mapper.Map<List<GetAllOrganiserForFront>, List<OrganiserListApiModel>>(spResult);
                mappedResult = mappedResult.Select(s =>
                {
                    if (s.Logo != null)
                    {
                        s.Logo = Path.Combine(baseURL + "Upload\\Organiser", s.OrganiserId.ToString() + "\\Logo", s.Logo);
                    }
                    return s;
                }).ToList();
                return Ok(APIStatusHelper.Success(mappedResult.ToList(), null));
            }
            return NotFound(APIStatusHelper.NotFound());
        }

    }
}