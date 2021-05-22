using System;
using System.ComponentModel.DataAnnotations;

namespace DealSe.Domain.SPModel
{
    public class GetLimitedTimeOffers
    {
        [Key]
        public Int64 SrNo { get; set; }
        public string LimitedTimeOffers { get; set; }
    }
}
