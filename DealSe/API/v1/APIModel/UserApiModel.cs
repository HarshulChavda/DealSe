﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DealSe.API.v1.APIModel
{
    public class UserParamApiFormModel
    {
        [StringLength(50)]
        public string Name { get; set; }
        [StringLength(12)]
        public string MobileNo { get; set; }
        [StringLength(100)]
        public string Email { get; set; }
        [StringLength(255)]
        public string FacebookId { get; set; }
        public string GooglePlusId { get; set; }
        [Required]
        public int RegistrationType { get; set; }
        public string DeviceID { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
    }

    public class UserUpdateImageReturnModel
    {
        public string Photo { get; set; }
    }

    public class LoginApiModel
    {
        [Required]
        public int RegistrationType { get; set; }
        public string MobileNumber { get; set; }
        public string FacebookId { get; set; }
        public string GooglePlusId { get; set; }
    }

    public class GetUserUsedOfferParamAPIFormModel
    {
        [Required]
        public int UserId { get; set; }
        [Required]
        public int PageIndex { get; set; }
    }

    public class GetUserUsedOfferHistoryReturnAPIModel
    {
        public int OfferID { get; set; }
        public string Title { get; set; }
        public string Image { get; set; }
        public string StoreName { get; set; }
        public string AreaName { get; set; }
        public string StoreAddress { get; set; }
        public string ShortDescription { get; set; }
        public string OfferNote { get; set; }
        public string RedeemDate { get; set; }
    }

    public class GetOfferDetailsReturnAPIModel
    {
        public int OfferID { get; set; }
        public int StoreId { get; set; }
        public List<OfferImages> OfferImages { get; set; }
        public string OfferName { get; set; }
        public string StoreName { get; set; }
        public string StoreAddress { get; set; }
        public string OfferStartDate { get; set; }
        public string OfferEndDate { get; set; }
        public string StoreContact { get; set; }
        public string StoreOwnerContact { get; set; }
        public List<StoreTimes> StoreTimes { get; set; }
        public string OfferLongDescription { get; set; }
        public string OfferShortDescription { get; set; }
        public string StoreLatitude { get; set; }
        public string StoreLongitude { get; set; }
        public string OfferTermsAndConditions { get; set; }
        public List<UserNearByPlaces> UserNearByPlaces { get; set; }

        public GetOfferDetailsReturnAPIModel()
        {
            OfferImages = new List<OfferImages>();
            StoreTimes = new List<StoreTimes>();
            UserNearByPlaces = new List<UserNearByPlaces>();
        }
    }

    public class GetOfferDetailsParamAPIModel
    {
        [Required]
        public int OfferID { get; set; }
        [Required]
        public decimal UserLatitude { get; set; }
        [Required]
        public decimal UserLogitude { get; set; }
        [Required]
        public int CategoryID { get; set; }
    }

    public class OfferImages
    {
        public int OfferBannerId { get; set; }
        public string Image { get; set; }
    }

    public class StoreTimes
    {
        public string MondayOpenHours { get; set; }
        public string MondayCloseHours { get; set; }
        public string TuesdayOpenHours { get; set; }
        public string TuesdayCloseHours { get; set; }
        public string WednesdayOpenHours { get; set; }
        public string WednesdayCloseHours { get; set; }
        public string ThursdayOpenHours { get; set; }
        public string ThursdayCloseHours { get; set; }
        public string FridayOpenHours { get; set; }
        public string FridayCloseHours { get; set; }
        public string SaturdayOpenHours { get; set; }
        public string SaturdayCloseHours { get; set; }
        public string SundayOpenHours { get; set; }
        public string SundayCloseHours { get; set; }
    }

    public class UserNearByPlaces
    {
        [Required]
        public int OfferID { get; set; }
        [Required]
        public string OfferName { get; set; }
        public string StoreImage { get; set; }
        [Required]
        public string StoreName { get; set; }
        [Required]
        public string AreaName { get; set; }
        [Required]
        public string OfferShortDescription { get; set; }
        public string OfferLongDescription { get; set; }
    }

    public class GetUserNearByPlacesByPagingParamAPIModel
    {
        [Required]
        public int CategoryID { get; set; }
        [Required]
        public decimal UserLatitude { get; set; }
        [Required]
        public decimal UserLongitude { get; set; }
        [Required]
        public int PageIndex { get; set; }
    }

    public class UserUpdateParamApiModel
    {
        [Required]
        public int UserID { get; set; }
        [Required]
        public int? AreaID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [Required]
        public string MobileNo { get; set; }
        public string Email { get; set; }
        public string FacebookId { get; set; }
        public string GooglePlusId { get; set; }
        public int RegistrationType { get; set; }
        public string DeviceID { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public int? Gender { get; set; }
        public int? MaritalStatus { get; set; }
        public DateTime? DOB { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Address3 { get; set; }
    }

    public class UserAddUpdateReturnApiModel
    {
        public int UserID { get; set; }
        public string Name { get; set; }
        public string MobileNo { get; set; }
        public string Email { get; set; }
        public string FacebookId { get; set; }
        public string GooglePlusId { get; set; }
        public int RegistrationType { get; set; }
        public string DeviceID { get; set; }
        public string DeviceType { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public int? Gender { get; set; }
        public int? MaritalStatus { get; set; }
        public DateTime? DOB { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Address3 { get; set; }
        public string Photo { get; set; }
    }

    public class GenerateQRCodeParamAPIFormModel
    {
        [Required]
        public int UserId { get; set; }
        [Required]
        public int OfferId { get; set; }
    }
}
