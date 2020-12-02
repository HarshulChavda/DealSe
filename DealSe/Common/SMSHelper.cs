using DealSe.Models;
using Newtonsoft.Json;
using RestSharp;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DealSe.Common
{
    public static class SMSHelper
    {    
        public static async Task SendSMSAsync(string apiKey, List<SMSModel> sMSModel)
        {
            SendSMSModel sendSMSModel = new SendSMSModel
            {
                sms = sMSModel
            };
            var jsonResult = JsonConvert.SerializeObject(sendSMSModel);
            var client = new RestClient("https://api.msg91.com/api/v2/sendsms");
            var request = new RestRequest(Method.POST);
            request.AddHeader("content-type", "application/json");
            request.AddHeader("authkey", apiKey);
            request.AddParameter("application/json", jsonResult, ParameterType.RequestBody);
            IRestResponse response = await client.ExecuteAsync(request);
        }
        public static async Task<string> SendOTP(string apiKey, string templateId, string mobileNumer,string email)
        {
            string mobileNumberWithCountryCode = "91" + mobileNumer;
            var client = new RestClient("https://api.msg91.com/api/v5/otp?authkey="+ apiKey +"&template_id=" + templateId +
                "&extra_param=%7B%22Param1%22%3A%22Value1%22%2C%20%22Param2%22%3A%22Value2%22%2C%20%22Param3%22%3A%20%22Value3%22%7D&mobile=" + mobileNumberWithCountryCode + "&email=" + email + "&otp_length=6&otp_expiry=5");
            var request = new RestRequest(Method.GET);
            request.AddHeader("content-type", "application/json");
            IRestResponse response = await client.ExecuteAsync(request);
            if (response.Content != null)
            {
                var responseResult = JsonConvert.DeserializeObject<SMSResponseModel>(response.Content);
                return responseResult.type; //success 
            }
            return "Error";
        }
        public static async Task<VerifyPasswordResponseModel> VerifyOTP(string apiKey, string otp, string mobileNumer)
        {
            string mobileNumberWithCountryCode = "91" + mobileNumer;
            var client = new RestClient("https://api.msg91.com/api/v5/otp/verify?mobile=" + mobileNumberWithCountryCode + "&otp=" + otp +"&authkey=" + apiKey);
            var request = new RestRequest(Method.POST);
            IRestResponse response = await client.ExecuteAsync(request);          
            var responseResult = JsonConvert.DeserializeObject<VerifyPasswordResponseModel>(response.Content);
            return responseResult; 
        }
        public static async Task<string> ResendOTP(string apiKey, string mobileNumer)
        {
            string mobileNumberWithCountryCode = "91" + mobileNumer;
            var client = new RestClient("https://api.msg91.com/api/v5/otp/retry?mobile=" + mobileNumberWithCountryCode  + "&authkey=" + apiKey + "&retrytype=text");
            var request = new RestRequest(Method.POST);
            IRestResponse response = await client.ExecuteAsync(request);
            if (response.Content != null)
            {
                var responseResult = JsonConvert.DeserializeObject<SMSResponseModel>(response.Content);
                return responseResult.type; //success 
            }
            return "Error";
        }

    }
}
