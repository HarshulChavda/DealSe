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
    public class UserController : ControllerBase
    {
        private readonly IUserService userService;
        private readonly IMapper mapper;
        public UserController(IUserService userService, IMapper mapper)
        {
            this.userService = userService;
            this.mapper = mapper;
        }

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
                else
                    user = await userService.CheckUserExists(model.RegistrationType, model.FacebookId);

                if (user == null)
                {
                    var mappedResult = mapper.Map<UserParamApiFormModel, User>(model);
                    mappedResult.Active = true;
                    mappedResult.AddedDate = DateTime.Now;
                    //mappedResult.DeviceType = (int)UserDeviceType.Android;
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
    }
}
