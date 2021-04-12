using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DealSe.API.v1.APIModel
{
    public class UserParamApiFormModel
    {
        public int AreaID { get; set; }
        [StringLength(50)]
        public string FirstName { get; set; }
        [StringLength(50)]
        public string LastName { get; set; }
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
        public string DeviceType { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public int Gender { get; set; }
        public int MaritalStatus { get; set; }
        public DateTime DOB { get; set; }
        [StringLength(500)]
        public string Address1 { get; set; }
        [StringLength(500)]
        public string Address2 { get; set; }
        [StringLength(500)]
        public string Address3 { get; set; }

    }

    public class UserApiModel
    {
        public int UserId { get; set; }
    }

    public class LoginApiModel
    {
        [Required]
        public int RegistrationType { get; set; }
        public string MobileNumber { get; set; }
        public string FacebookId { get; set; }
        public string GooglePlusId { get; set; }
    }

    public class GetProfileForm
    {
        [Required]
        public bool IsRegistered { get; set; }
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
        [Required]
        public int OfferID { get; set; }
        [Required]
        public string Title { get; set; }
        public string Image { get; set; }
        [Required]
        public string StoreName { get; set; }
        [Required]
        public string AreaName { get; set; }
        [Required]
        public string StoreAddress { get; set; }
        [Required]
        public string ShortDescription { get; set; }
        [Required]
        public string OfferNote { get; set; }
    }

    public class GetOfferDetailsReturnAPIModel
    {
        [Required]
        public int OfferID { get; set; }
        public List<OfferImages> OfferImages { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string StoreName { get; set; }
        [Required]
        public string StoreAddress { get; set; }
        [Required]
        public string StartDate { get; set; }
        [Required]
        public string EndDate { get; set; }
        public string StoreContact { get; set; }
        [Required]
        public string StoreOwnerContact { get; set; }
        public List<StoreTimes> StoreTimes { get; set; }
        [Required]
        public string ShortDescription { get; set; }
        [Required]
        public string StoreLatitude { get; set; }
        [Required]
        public string StoreLongitude { get; set; }
        public string TermsAndConditions { get; set; }
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
        public string Title { get; set; }
        public string StoreImage { get; set; }
        [Required]
        public string StoreName { get; set; }
        [Required]
        public string AreaName { get; set; }
        [Required]
        public string ShortDescription { get; set; }
        public string OfferNote { get; set; }
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
        public int AreaID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [Required]
        public string MobileNo { get; set; }
        public string Email { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public int Gender { get; set; }
        public int MaritalStatus { get; set; }
        public DateTime DOB { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Address3 { get; set; }
    }

    public class UserUpdateReturnApiModel
    {
        public int UserID { get; set; }
        public int AreaID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MobileNo { get; set; }
        public string Email { get; set; }
        public string FacebookId { get; set; }
        public string GooglePlusId { get; set; }
        public int RegistrationType { get; set; }
        public string DeviceID { get; set; }
        public string DeviceType { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public int Gender { get; set; }
        public int MaritalStatus { get; set; }
        public DateTime DOB { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Address3 { get; set; }
    }
}
