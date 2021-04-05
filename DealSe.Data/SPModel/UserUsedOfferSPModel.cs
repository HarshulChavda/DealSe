using System;
using System.ComponentModel.DataAnnotations;

namespace DealSe.Data.SPModel
{
    public class GetUserUsedOfferListByStoreSPModel
    {
        [Key]
        public int UserUsedOfferId { get; set; }
        public string UserName { get; set; }
        public string UserMobileNo { get; set; }
        public string OfferName { get; set; }
        public DateTime RedeemDate { get; set; }
    }
}
