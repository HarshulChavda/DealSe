using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DealSe.Areas.Admin.ViewModels
{
    public class OfferViewModel
    { 
        public int OfferId { get; set; }
        public string StoreName { get; set; }
        public string Name { get;set; }
        public string ValidityDates { get; set; }
        public string AddedDate { get; set; }
        public int UserRedeemLimit { get; set; }
    }
}
