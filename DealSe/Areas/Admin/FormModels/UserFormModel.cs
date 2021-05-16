using System;

namespace DealSe.Areas.Admin.FormModels
{
    //User formModel
    public class UserFormModel
    {
        public int UserId { get; set; }
        public int? AreaId { get; set; }
        public string Name { get; set; }
        public string MobileNo { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Image { get; set; }
        public string Gender { get; set; }
        public string FacebookId { get; set; }
        public string GooglePlusId { get; set; }
        public string RegistrationType { get; set; }
        public string DeviceID { get; set; }
        public string DeviceType { get; set; }
        public bool Active { get; set; }
        public DateTime AddedDate { get; set; }
        public byte InvalidLoginAttemptCount { get; set; }
        public DateTime? LastInvalidLoginAttemptDate { get; set; }
    }
}
