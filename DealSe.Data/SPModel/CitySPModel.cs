using System;
using System.ComponentModel.DataAnnotations;

namespace DealSe.Data.SPModel
{
    public class GetAllCity
    {
        [Key]
        public int CityId { get; set; }
        public string Name { get; set; }
        public DateTime AddedDate { get; set; }
        public bool Active { get; set; }
    }
}
