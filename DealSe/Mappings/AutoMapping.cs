﻿using AutoMapper;
using DealSe.API.v1.APIModel;
using DealSe.Areas.Admin.FormModels;
using DealSe.Areas.Admin.ViewModels;
using DealSe.Data.Models;
using DealSe.Data.SPModel;
using DealSe.Utils.Enum;

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
            CreateMap<User, UserFormModel>()
                .ForMember(dest => dest.RegistrationType, opt => opt.MapFrom(src => src.RegistrationType == (int)UserRegistrationType.Facebook ? "Facebook" : src.RegistrationType == (int)UserRegistrationType.Google ? "Google+" : "Guest"))
                //.ForMember(dest => dest.DeviceType, opt => opt.MapFrom(src => src.DeviceType == (int)UserDeviceType.Android ? "Android" : "IOS"))
                .ForMember(dest => dest.Gender, opt => opt.MapFrom(src => src.Gender == (int)Gender.Male ? "Male" : src.Gender == (int)Gender.Female ? "Female" : "-"))
                .ForMember(dest => dest.MobileNo, opt => opt.MapFrom(src => string.IsNullOrEmpty(src.MobileNo) ? "-" : src.MobileNo))
                .ForMember(dest => dest.FacebookId, opt => opt.MapFrom(src => string.IsNullOrEmpty(src.FacebookId) ? "-" : src.FacebookId))
                .ForMember(dest => dest.GooglePlusId, opt => opt.MapFrom(src => string.IsNullOrEmpty(src.GoogleId) ? "-" : src.GoogleId))
                .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => string.IsNullOrEmpty(src.FirstName) ? "-" : src.FirstName))
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => string.IsNullOrEmpty(src.LastName) ? "-" : src.LastName))
                .ReverseMap();
            // ================= View Model =======================
            CreateMap<SiteSetting, SiteSettingViewModel>()
              .ForMember(dest => dest.AddedDate, opt => opt.MapFrom(src => src.AddedDate.ToString("dd/MM/yyyy hh:mm tt")));
            CreateMap<EmailTemplate, EmailTemplateViewModel>()
                .ForMember(dest => dest.AddedDate, opt => opt.MapFrom(src => src.AddedDate.ToString("dd/MM/yyyy hh:mm tt")));
            CreateMap<GetAllCountry, CountryViewModel>()
               .ForMember(dest => dest.DisplayAddedDate, opt => opt.MapFrom(src => src.AddedDate.ToString("dd/MM/yyyy hh:mm tt")));
            CreateMap<UsersSPModel, UserViewModel>()
                .ForMember(dest => dest.AddedDate, opt => opt.MapFrom(src => src.AddedDate.ToString("dd/MM/yyyy hh:mm tt")));
            #endregion

            #region API Mapping
            CreateMap<User, UserParamApiFormModel>().ReverseMap();
            #endregion
        }
    }
}
