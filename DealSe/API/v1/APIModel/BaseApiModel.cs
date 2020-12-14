using Microsoft.AspNetCore.Mvc.ModelBinding;
using Newtonsoft.Json;
using System.Linq;

namespace DealSe.API.v1.APIModel
{
    public class BaseApiModel
    {
        public int Code { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Message { get; set; }

        public BaseApiModel() { }

        public BaseApiModel(int statusCode, string message = null)
        {
            Code = statusCode;
            Message = message ?? GetDefaultMessageForStatusCode(statusCode);
        }

        private static string GetDefaultMessageForStatusCode(int statusCode)
        {
            switch (statusCode)
            {
                case 404:
                    return "Resource not found";
                case 500:
                    return "An unhandled error occurred";
                default:
                    return null;
            }
        }
    }

    public class ApiBadRequestResponse : BaseApiModel
    {
        public object Data { get; set; }

        public ApiBadRequestResponse() { }
        public ApiBadRequestResponse(ModelStateDictionary modelState) : base(400)
        {
            Message = "Please resolve the following errors";
            Data = modelState.SelectMany(x => x.Value.Errors)
                .Select(x => x.ErrorMessage).ToArray();
        }
    }

    public class ApiOkResponse : BaseApiModel
    {
        public object Data { get; set; }
        public ApiOkResponse() : base(200)
        {
        }
        public ApiOkResponse(object result) : base(200)
        {
            Data = result;
        }
    }
}
