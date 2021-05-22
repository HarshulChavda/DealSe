using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Text;
using DealSe.API.v1.APIModel;
using DealSe.Shared.Common;

namespace DealSe.API.v1
{
    [ApiVersion("1.0")]
    [Produces("application/json")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [EnableCors("AllowOrigin")]
    public class AuthenticationController : ControllerBase
    {
        private readonly IOptions<CustomSettings> config;

        public AuthenticationController(IOptions<CustomSettings> config)
        {
            this.config = config;
        }

        [Route("GetToken")]
        [ProducesResponseType(200)]
        [ProducesResponseType(401)]
        [HttpPost]
        public IActionResult GetToken(AuthenticationApiModel model)
        {
            ApiOkResponse apiModel = new ApiOkResponse();
            if (model.ClientSecret == config.Value.ClientSecret)
            {
                apiModel.Code = (int)HttpStatusCode.OK;
                apiModel.Message = "Token generated successfully.";

                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(config.Value.JWTSecret);
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                    new Claim(ClaimTypes.Name, "0")
                    }),
                    Expires = System.DateTime.Today.AddYears(1),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };
                var token = tokenHandler.CreateToken(tokenDescriptor);
                var returnToken = tokenHandler.WriteToken(token);
                apiModel.Data = new TokenApiModel() { Token = returnToken };
                return Ok(apiModel);
            }
            else
            {
                apiModel.Code = (int)HttpStatusCode.Unauthorized;
                apiModel.Message = "Client Secret is invalid, please pass a valid secret key.";
                apiModel.Data = null;
                return StatusCode((int)HttpStatusCode.Unauthorized, apiModel);
            }
        }
    }
}