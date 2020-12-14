using System.ComponentModel.DataAnnotations;

namespace DealSe.Areas.Admin.FormModels
{
    public class ChangePasswordFormModel
    {
        [Required(ErrorMessage = "This field is required")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Invalid Email Address.")]
        [EmailAddress(ErrorMessage = "Invalid Email Address.")]
        [StringLength(100, ErrorMessage = "The Email must be a maximum length of 100.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [StringLength(50, ErrorMessage = "The Password must be a maximum length of 50.")]
        public string Password { get; set; }
        public string VerificationCode { get; set; }
    }
}
