using DealSe.API.v1.APIModel;
using DealSe.Utils;
using System.Net;

namespace DealSe.Common
{
    public static class APIStatusHelper
    {
        public static ApiOkResponse Success(dynamic result, string message)
        {
            ApiOkResponse apiModel = new ApiOkResponse();
            apiModel.Code = (int)HttpStatusCode.OK;
            apiModel.Message = message;
            apiModel.Data = result ?? new object();
            return apiModel;
        }
        public static ApiOkResponse NotFound()
        {
            ApiOkResponse apiModel = new ApiOkResponse();
            apiModel.Code = (int)HttpStatusCode.NotFound;
            apiModel.Message = DealSeResource.NoRecordFound;
            apiModel.Data = new object();
            return apiModel;
        }
        public static ApiOkResponse InternalServerError()
        {
            ApiOkResponse apiModel = new ApiOkResponse();
            apiModel.Code = (int)HttpStatusCode.InternalServerError;
            apiModel.Message = DealSeResource.InternalServerError;
            apiModel.Data = new object();
            return apiModel;
        }
        public static ApiOkResponse Forbidden(string message)
        {
            ApiOkResponse apiModel = new ApiOkResponse();
            apiModel.Code = (int)HttpStatusCode.Forbidden;
            apiModel.Message = message;
            apiModel.Data = new object();
            return apiModel;
        }
        public static ApiOkResponse Found(dynamic result, string message)
        {
            ApiOkResponse apiModel = new ApiOkResponse();
            apiModel.Code = (int)HttpStatusCode.Found;
            apiModel.Message = message;
            apiModel.Data = result ?? new object();
            return apiModel;
        }
        public static ApiOkResponse NotAcceptable(dynamic result, string message)
        {
            ApiOkResponse apiModel = new ApiOkResponse();
            apiModel.Code = (int)HttpStatusCode.NotAcceptable;
            apiModel.Message = message;
            apiModel.Data = result ?? new object();
            return apiModel;
        }

    }
}
