using System;
using System.ComponentModel.DataAnnotations;

namespace DealSe.Data.SPModel
{
    public class UsersSPModel
    {
        [Key]
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string MobileNo { get; set; }
        public string FacebookId { get; set; }
        public string GooglePlusId { get; set; }
        public bool Active { get; set; }
        public DateTime AddedDate { get; set; }
    }
}