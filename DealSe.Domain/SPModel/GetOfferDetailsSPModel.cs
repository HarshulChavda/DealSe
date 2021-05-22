using System;
using System.ComponentModel.DataAnnotations;

namespace DealSe.Domain.SPModel
{
    public class GetOfferDetailsSPModel
    {
        [Key]
        public int OfferID { get; set; }
        public string Title { get; set; }
        public string StoreName { get; set; }
        public string StoreAddress { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string StoreContact { get; set; }
        public string StoreOwnerContact { get; set; }
        public string ShortDescription { get; set; }
        public decimal StoreLatitude { get; set; }
        public decimal StoreLongitude { get; set; }
        public string TermsAndConditions { get; set; }
        public string OfferImages { get; set; }
        public string StoreTimes { get; set; }
    }
}
