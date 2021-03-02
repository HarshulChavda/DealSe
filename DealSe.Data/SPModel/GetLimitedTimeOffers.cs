using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DealSe.Data.SPModel
{
    public class GetLimitedTimeOffers
    {
        [Key]
        public Int64 SrNo { get; set; }
        public string LimitedTimeOffers { get; set; }
    }
}
