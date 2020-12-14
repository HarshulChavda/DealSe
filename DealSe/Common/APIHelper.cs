using DealSe.API.v1.APIModel;
using Newtonsoft.Json;
using RestSharp;
using System.Threading.Tasks;

namespace DealSe.Common
{
    public static class APIHelper
    {
        public static async Task<ApiOkResponse> APICall(dynamic param, string accessToken, string apiBaseUrl, string apiUrl, Method type)
        {
            try
            {               
                var client = new RestClient(apiBaseUrl + apiUrl);
                client.AddDefaultHeader("Authorization", string.Format("Bearer {0}", accessToken));
                var request = new RestRequest(type);
                request.AddHeader("content-type", "application/json");
                if(param != null)
                {
                    request.AddParameter("application/json", Newtonsoft.Json.JsonConvert.SerializeObject(param), ParameterType.RequestBody);
                }
                var response = await client.ExecuteAsync(request);
                if (response.Content != null)
                {
                    var baseObj = JsonConvert.DeserializeObject<ApiOkResponse>(response.Content);
                    return baseObj;                   
                }
                return null;

            }
            catch 
            {
                return null;
            }
        }
    }
}
