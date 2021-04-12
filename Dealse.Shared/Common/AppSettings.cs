namespace DealSe.Shared.Common
{
    public partial class CustomSettings
    {
        public string BaseUrl { get; set; }
        public string AdminVerifyAccount { get; set; }
        public string ApiVersion { get; set; }
        public string APIBaseUrl { get; set; }
        public string JWTSecret { get; set; }
        public string ClientSecret { get; set; }
        public string GoogleMapAPIKey { get; set; }
    }

    public partial class ConnectionStrings
    {
        public string DealSeContext { get; set; }
    }
}
