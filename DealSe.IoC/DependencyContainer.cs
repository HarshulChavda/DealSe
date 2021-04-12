using DealSe.Service;
using DealSe.Service.Interface;
using DealSe.Service.Service;
using Microsoft.Extensions.DependencyInjection;

namespace DealSe.IoC
{
    public class DependencyContainer
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddScoped<ILoginService, LoginService>();
            services.AddScoped<ISiteSettingService, SiteSettingService>();
            services.AddScoped<IEmailTemplateService, EmailTemplateService>();
            services.AddScoped<ICountryService, CountryService>();
            services.AddScoped<IStateService, StateService>();
            services.AddScoped<ICityService, CityService>();
            services.AddScoped<IAreaService, AreaService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IStoreService, StoreService>();
            services.AddScoped<IStoreTypeService, StoreTypeService>();
            services.AddScoped<IOfferService, OfferService>();
            services.AddScoped<IOfferBannerService, OfferBannerService>();
            services.AddScoped<IUserUsedOfferService, UserUsedOfferService>();
        }
    }
}
