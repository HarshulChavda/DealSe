using System;
using System.ComponentModel.DataAnnotations;

namespace DealSe.Data.SPModel
{
    public class GetOfferListByStoreIdSPModel
    {
        [Key]
        public int OfferId { get; set; }
        public string Name { get; set; }
        public string OfferListImage { get; set; }
        public string EffectiveDateRange { get; set; }
        public string SortDescription { get; set; }
        public bool Active { get; set; }
    }
}