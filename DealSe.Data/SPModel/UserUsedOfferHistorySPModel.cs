using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DealSe.Data.SPModel
{
    public class UserUsedOfferHistorySPModel
    {
        [Key]
        public int OfferID { get; set; }
        public string Title { get; set; }
        public string Image { get; set; }
        public string StoreName { get; set; }
        public string AreaName { get; set; }
        public string StoreAddress { get; set; }
        public string ShortDescription { get; set; }
        public string OfferNote { get; set; }

    }
}
