using AutoMapper;
using DealSe.API.v1.APIModel;
using DealSe.Areas.Admin.FormModels;
using DealSe.Areas.Admin.ViewModels;
using DealSe.Domain.Models;
using DealSe.Domain.SPModel;
using DealSe.Utils.Common;
using DealSe.Utils.Enum;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace DealSe.Mappings
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            #region Admin Mapping
            // ================= Form Model =======================
            CreateMap<Admin, AdminFormModel>().ReverseMap();
            CreateMap<SiteSetting, SiteSettingFormModel>()
                .ForMember(dest => dest.TextTypeSiteSettingValue, opt => opt.MapFrom(src => src.SiteSettingValue))
                .ForMember(dest => dest.NumberTypeSiteSettingValue, opt => opt.MapFrom(src => src.SiteSettingValue))
                .ForMember(dest => dest.BooleanTypeSiteSettingValue, opt => opt.MapFrom(src => src.SiteSettingValue == "True" ? true : false))
                .ForMember(dest => dest.HtmlTypeSiteSettingValue, opt => opt.MapFrom(src => src.SiteSettingValue))
                .ForMember(dest => dest.EmailTypeSiteSettingValue, opt => opt.MapFrom(src => src.SiteSettingValue))
                .ForMember(dest => dest.DomainTypeSiteSettingValue, opt => opt.MapFrom(src => src.SiteSettingValue))
                .ReverseMap();
            CreateMap<EmailTemplate, EmailTemplateFormModel>().ReverseMap();
            CreateMap<Country, CountryFormModel>().ReverseMap();
            CreateMap<State, StateFormModel>().ReverseMap();
            CreateMap<City, CityFormModel>().ReverseMap();
            CreateMap<Area, AreaFormModel>().ReverseMap();
            CreateMap<User, UserFormModel>()
                .ForMember(dest => dest.RegistrationType, opt => opt.MapFrom(src => src.RegistrationType == (int)RegistrationType.Facebook ? "Facebook" : src.RegistrationType == (int)RegistrationType.Google ? "Google+" : "Guest"))
                .ForMember(dest => dest.Gender, opt => opt.MapFrom(src => src.Gender == (int)Gender.Male ? "Male" : src.Gender == (int)Gender.Female ? "Female" : "-"))
                .ForMember(dest => dest.MobileNo, opt => opt.MapFrom(src => string.IsNullOrEmpty(src.MobileNo) ? "-" : src.MobileNo))
                .ForMember(dest => dest.FacebookId, opt => opt.MapFrom(src => string.IsNullOrEmpty(src.FacebookId) ? "-" : src.FacebookId))
                .ForMember(dest => dest.GooglePlusId, opt => opt.MapFrom(src => string.IsNullOrEmpty(src.GoogleId) ? "-" : src.GoogleId))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => string.IsNullOrEmpty(src.Name) ? "-" : src.Name))
                .ReverseMap();
            CreateMap<StoreType, StoreTypeFormModel>().ReverseMap();
            CreateMap<Store, StoreFormModel>().ReverseMap();
            
            // ================= View Model =======================
            CreateMap<SiteSetting, SiteSettingViewModel>()
              .ForMember(dest => dest.AddedDate, opt => opt.MapFrom(src => src.AddedDate.ToString("dd/MM/yyyy hh:mm tt")));
            CreateMap<EmailTemplate, EmailTemplateViewModel>()
                .ForMember(dest => dest.AddedDate, opt => opt.MapFrom(src => src.AddedDate.ToString("dd/MM/yyyy hh:mm tt")));
            CreateMap<GetAllCountry, CountryViewModel>()
               .ForMember(dest => dest.DisplayAddedDate, opt => opt.MapFrom(src => src.AddedDate.ToString("dd/MM/yyyy hh:mm tt")));
            CreateMap<GetAllState, StateViewModel>()
               .ForMember(dest => dest.DisplayAddedDate, opt => opt.MapFrom(src => src.AddedDate.ToString("dd/MM/yyyy hh:mm tt")));
            CreateMap<GetAllCity, CityViewModel>()
               .ForMember(dest => dest.DisplayAddedDate, opt => opt.MapFrom(src => src.AddedDate.ToString("dd/MM/yyyy hh:mm tt")));
            CreateMap<GetAllArea, AreaViewModel>()
               .ForMember(dest => dest.DisplayAddedDate, opt => opt.MapFrom(src => src.AddedDate.ToString("dd/MM/yyyy hh:mm tt")));
            CreateMap<UsersSPModel, UserViewModel>()
                .ForMember(dest => dest.DisplayAddedDate, opt => opt.MapFrom(src => src.AddedDate.ToString("dd/MM/yyyy hh:mm tt")));
            CreateMap<GetAllStoreType, StoreTypeViewModel>()
                .ForMember(dest => dest.DisplayAddedDate, opt => opt.MapFrom(src => src.AddedDate.ToString("dd/MM/yyyy hh:mm tt")));
            CreateMap<GetAllStore, StoreViewModel>()
                .ForMember(dest => dest.DisplayAddedDate, opt => opt.MapFrom(src => src.AddedDate.ToString("dd/MM/yyyy hh:mm tt")));
            #endregion

            #region API Mapping
            CreateMap<User, UserParamApiFormModel>().ReverseMap();
            CreateMap<AddStoreParamApiFormModel, Store>().ReverseMap();
            CreateMap<Store, AddStoreReturnApiFormModel>().ReverseMap();
            CreateMap<Store, AddStoreReturnApiFormModel>().ReverseMap();
            CreateMap<UpdateStoreParamApiFormModel, Store>().ReverseMap();
            CreateMap<AddOfferBannerParamApiFormModel, OfferBanner>().ReverseMap();
            CreateMap<AddOfferParamApiFormModel, Offer>().ReverseMap();
            CreateMap<AddOfferReturnApiFormModel, Offer>().ReverseMap();
            CreateMap<UpdateOfferParamApiFormModel, Offer>().ReverseMap();
            CreateMap<GetOfferListByStoreIdSPModel, GetOfferListByStoreIdReturnApiFormModel>()
                .ForMember(dest => dest.offerImagesLists, opt => opt.MapFrom(src => JsonConvert.DeserializeObject<List<OfferImagesList>>(src.OfferImagesList)))
                .ReverseMap();
            CreateMap<GetUserUsedOfferListByStoreSPModel, GetUserUsedOfferListByStoreReturnApiModel>().ReverseMap();
            CreateMap<Area, AreaListModel>()
                 .ForMember(dest => dest.areaId, opt => opt.MapFrom(src => src.AreaId))
                 .ForMember(dest => dest.areaName, opt => opt.MapFrom(src => src.Name))
                .ReverseMap();
            CreateMap<StoreType, StoreTypeListApiModel>()
                 .ForMember(dest => dest.storeTypeId, opt => opt.MapFrom(src => src.StoreTypeId))
                 .ForMember(dest => dest.storeTypeName, opt => opt.MapFrom(src => src.Name))
                 .ReverseMap();
            CreateMap<UserUsedOfferHistorySPModel, GetUserUsedOfferHistoryReturnAPIModel>().ReverseMap();
            CreateMap<GetOfferDetailsSPModel, GetOfferDetailsReturnAPIModel>()
                  .ForMember(dest => dest.OfferImages, opt => opt.Ignore())
                  .ForMember(dest => dest.StoreTimes, opt => opt.Ignore())
                  .ForMember(dest => dest.UserNearByPlaces, opt => opt.Ignore()).ReverseMap();
            CreateMap<Service.Common.GetUserNearByPlaces, UserNearByPlaces>().ReverseMap();
            CreateMap<Service.Common.GetAreaList, AreaListModel>().ReverseMap();
            CreateMap<Service.Common.GetStoreTypeList, StoreTypeListApiModel>().ReverseMap();
			 CreateMap<Store, CheckStoreMobieNumberReturnApiFormModel>().ReverseMap(); 
			 CreateMap<UserUsedOfferFormModel, UserUsedOffer>().ReverseMap();
            CreateMap<Store, SendStoreRegistrationToastrNotificationHubViewModel>();
            CreateMap<Offer, SendAddedOfferToastrNotificationHubViewModel>();
            CreateMap<UserUpdateParamApiModel, User>().ReverseMap();
            CreateMap<User, UserAddUpdateReturnApiModel>();
            #endregion
        }
    }
}
