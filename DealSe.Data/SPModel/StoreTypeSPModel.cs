using System;
using System.ComponentModel.DataAnnotations;

namespace DealSe.Data.SPModel
{
    public class GetAllStoreType
    {
        [Key]
        public int StoreTypeId { get; set; }
        public string Name { get; set; }
        public DateTime AddedDate { get; set; }
        public bool Active { get; set; }
    }
}
