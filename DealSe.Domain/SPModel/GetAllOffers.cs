using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DealSe.Domain.SPModel
{
    public class GetAllOffers
    {
        [Key]
        public int OfferId { get; set; }
        public string StoreName { get; set; }
        public string Name { get; set; }
        public string ValidityDates { get; set; }
        public string AddedDate { get; set; }
        public int UserRedeemLimit { get; set; }
    }
}
