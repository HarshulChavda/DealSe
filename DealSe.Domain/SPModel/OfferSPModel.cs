using System;
using System.ComponentModel.DataAnnotations;

namespace DealSe.Domain.SPModel
{
    public class GetOfferListByStoreIdSPModel
    {
        [Key]
        public int OfferId { get; set; }
        public string Name { get; set; }
        public string OfferImagesList { get; set; }
        public string EffectiveDateRange { get; set; }
        public string SortDescription { get; set; }
        public string LongDescription { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string TermsAndConditions { get; set; }
        public bool Active { get; set; }
        public DateTime AddedDate { get; set; }
    }
}