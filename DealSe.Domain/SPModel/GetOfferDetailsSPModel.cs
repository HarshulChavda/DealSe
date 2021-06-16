using System;
using System.ComponentModel.DataAnnotations;

namespace DealSe.Domain.SPModel
{
    public class GetOfferDetailsSPModel
    {
        [Key]
        public int OfferID { get; set; }
        public string OfferName { get; set; }
        public string StoreName { get; set; }
        public string StoreAddress { get; set; }
        public string OfferStartDate { get; set; }
        public string OfferEndDate { get; set; }
        public string StoreContact { get; set; }
        public string StoreOwnerContact { get; set; }
        public string OfferLongDescription { get; set; }
        public string OfferShortDescription { get; set; }
        public decimal StoreLatitude { get; set; }
        public decimal StoreLongitude { get; set; }
        public string OfferTermsAndConditions { get; set; }
        public string OfferImages { get; set; }
        public string StoreTimes { get; set; }
    }
}
