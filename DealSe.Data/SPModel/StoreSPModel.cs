using System;
using System.ComponentModel.DataAnnotations;

namespace DealSe.Data.SPModel
{
    public class GetAllStore
    {
        [Key]
        public int StoreId { get; set; }
        public int StoreTypeId { get; set; }
        public int AreaId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string OwnerName { get; set; }
        public string OwnerMobileNo { get; set; }
        public DateTime AddedDate { get; set; }
        public bool Active { get; set; }
        public bool Approved { get; set; }
    }
}
