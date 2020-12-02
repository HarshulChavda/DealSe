using System;
using System.ComponentModel.DataAnnotations;

namespace DealSe.Data.SPModel
{
    public class GetAllCountry
    {
        [Key]
        public int CountryId { get; set; }
        public string Name { get; set; }
        public DateTime AddedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public bool Active { get; set; }
    }
}
