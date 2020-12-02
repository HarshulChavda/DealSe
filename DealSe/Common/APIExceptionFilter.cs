using DealSe.API.v1.APIModel;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace DealSe.ExceptionFilter
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, Inherited = true, AllowMultiple = true)]
    public class APIExceptionHandlerAttribute : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            var errorData = new ApiBadRequestResponse();
            errorData.Data = new List<string>() { context.Exception.Message };
            errorData.Code = 500;
            errorData.Message = "An error occured";
            var error = new BadRequestObjectResult(errorData);
            context.Result = error;
			//string exceptionData = JsonConvert.SerializeObject(error);
			//CustomErrorLog customErrorLog = new CustomErrorLog();			
			//customErrorLog.AddErrorLog(context.HttpContext, exceptionData);
        }
    }
}
