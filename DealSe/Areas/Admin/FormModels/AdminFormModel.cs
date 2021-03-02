using System;
using System.ComponentModel.DataAnnotations;

namespace DealSe.Areas.Admin.FormModels
{
    public class AdminFormModel
    {
        public int AdminID { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "The first name must be a maximum length of 50.")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "The last name must be a maximum length of 50.")]
        public string LastName { get; set; }

        [Required]
        [DataType(DataType.EmailAddress, ErrorMessage = "Invalid email Address.")]
        [EmailAddress(ErrorMessage = "Invalid email Address.")]
        [StringLength(100, ErrorMessage = "The email must be a maximum length of 100.")]
        public string Email { get; set; }
        public string Logo { get; set; }

        [MinLength(8, ErrorMessage = "The password minimum length of 8 characters.")]
        public string NewPassword { get; set; }

        public string Password { get; set; }

        
        [StringLength(50, ErrorMessage = "The mobile no must be a maximum length of 50.")]
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
