using System.ComponentModel.DataAnnotations;

namespace DealSe.API.v1.APIModel
{
    public class UserParamApiFormModel
    {
        [StringLength(50)]
        public string FirstName { get; set; }
        [StringLength(50)]
        public string LastName { get; set; }
        [StringLength(12)]
        public string MobileNo { get; set; }
        [StringLength(100)]
        public string Email { get; set; }
        public string Image { get; set; }
        [StringLength(255)]
        public string Password { get; set; }
        public string FacebookId { get; set; }
        public string GooglePlusId { get; set; }
        [Required]
        public int RegistrationType { get; set; }
        public string DeviceID { get; set; }
    }

    public class UserApiModel
    {
        public int UserId { get; set; }
    }
}
