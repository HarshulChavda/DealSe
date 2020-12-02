using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Text;

namespace DealSe.ActionFilter
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, Inherited = true, AllowMultiple = true)]
    public class AdminAuthorizeFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (string.IsNullOrEmpty(filterContext.HttpContext.Session.GetString("admin")))
            {
                string OriginalUrl = filterContext.HttpContext.Request.Path;
                var loginUrl = new UrlHelper(filterContext).Content("~/Admin/Home/Login");
                if (loginUrl == OriginalUrl) OriginalUrl = "";
                var fullURL = $"{loginUrl}?ReturnUrl={WebUtility.UrlEncode(OriginalUrl)}";
                filterContext.HttpContext.Response.StatusCode = 307;
                filterContext.HttpContext.Response.Headers.Add("Location", fullURL);
            }
        }
    }

    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, Inherited = true, AllowMultiple = true)]
    public class APIAuthorizeFilterAttribute : ActionFilterAttribute
    {

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (string.IsNullOrEmpty(filterContext.HttpContext.Session.GetString("ACCESS_TOKEN")) || (!string.IsNullOrEmpty(filterContext.HttpContext.Session.GetString("REFRESH_TOKEN")) && filterContext.HttpContext.Session.GetString("REFRESH_TOKEN") == "true"))
            {
                //get token          
                // authentication successful so generate jwt token
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes("14173664216C44D32AA2A49C7AD75");
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
                filterContext.HttpContext.Session.SetString("ACCESS_TOKEN", returnToken);
            }
        }
    }
}
