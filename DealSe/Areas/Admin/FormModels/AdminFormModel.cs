using System;
using System.ComponentModel.DataAnnotations;

namespace DealSe.Areas.Admin.FormModels
{
    public class AdminFormModel
    {
        public int AdminID { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "The First Name must be a maximum length of 50.")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "The Last Name must be a maximum length of 50.")]
        public string LastName { get; set; }

        [Required]
        [DataType(DataType.EmailAddress, ErrorMessage = "Invalid Email Address.")]
        [EmailAddress(ErrorMessage = "Invalid Email Address.")]
        [StringLength(100, ErrorMessage = "The Email must be a maximum length of 100.")]
        public string Email { get; set; }
        public string Logo { get; set; }

        [MinLength(8, ErrorMessage = "The Password minimum length of 8 characters.")]
        public string NewPassword { get; set; }

        public string Password { get; set; }

        
        [StringLength(50, ErrorMessage = "The Phone must be a maximum length of 50.")]
        public string MobileNo { get; set; }

        public bool Active { get; set; }
        public Guid? PasswordResetToken { get; set; }
        public TimeSpan ServiceHourStartTime { get; set; }
        public TimeSpan ServiceHourEndTime { get; set; }        
        public DateTime AddedDate { get; set; }        
        public DateTime? UpdatedDate { get; set; }                
        public DateTime? DeletedDate { get; set; }
    }
}
