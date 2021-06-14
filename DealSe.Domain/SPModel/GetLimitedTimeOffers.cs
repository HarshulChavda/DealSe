using System;
using System.ComponentModel.DataAnnotations;

namespace DealSe.Domain.SPModel
{
    public class GetLimitedTimeOffersSPModel
    {
        [Key]
        public Int64 SrNo { get; set; }
        public string LimitedTimeOffers { get; set; }
    }
}
