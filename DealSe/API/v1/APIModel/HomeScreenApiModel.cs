using System;
using System.ComponentModel.DataAnnotations;

namespace DealSe.API.v1.APIModel
{
    public class GetUserUsedOfferListByStoreParamApiModel
    {
        [Required]
        public int pageIndex { get; set; }
        [Required]
        public int pageSize { get; set; }
    }

    public class GetUserUsedOfferListByStoreReturnApiModel
    {
        public int UserUsedOfferId { get; set; }
        public string UserName { get; set; }
        public string OfferName { get; set; }
        public DateTime RedeemDate { get; set; }
    }
}
