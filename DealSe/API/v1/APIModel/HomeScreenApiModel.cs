using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DealSe.API.v1.APIModel
{
    public class GetUserUsedOfferListByStoreParamApiModel
    {
        [Required]
        public int storeId { get; set; }
        [Required]
        public int pageIndex { get; set; }
        [Required]
        public int pageSize { get; set; }
    }

    public class GetUserUsedOfferListByStoreReturnApiModel
    {
        public int UserUsedOfferId { get; set; }
        public string UserName { get; set; }
        public string UserMobileNo { get; set; }
        public string OfferName { get; set; }
        public DateTime RedeemDate { get; set; }
    }

    public class GetAreaAndStoreTypeListReturnApiFormModel
    {
        public List<AreaListModel> areaListModel { get; set; }
        public List<StoreTypeListApiModel> storeTypeApiModel { get; set; }
    }

    public class GetUserHomeScreenDetailsParamsApiFormModel
    {
        [Required]
        public decimal UserLatitude { get; set; }
        [Required]
        public decimal UserLogitude { get; set; }
    }

    public class GetUserHomeScreenDetailsReturnApiFormModel
    {
        public List<AreaListModel> Areas { get; set; }
        public List<StoreTypeListApiModel> StoreTypes { get; set; }
        public List<UserNearByPlaces> UserNearByPlaces { get; set; }
        public List<GetLimitedTimeOffers> LimitedTimeOffers { get; set; }

        public GetUserHomeScreenDetailsReturnApiFormModel()
        {
            Areas = new List<AreaListModel>();
            StoreTypes = new List<StoreTypeListApiModel>();
            UserNearByPlaces = new List<UserNearByPlaces>();
            LimitedTimeOffers = new List<GetLimitedTimeOffers>();
        }
    }

    public class GetLimitedTimeOffers
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
        public string ShortDescription { get; set; }
        public string OfferNote { get; set; }

    }
}
