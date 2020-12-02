using System;
using System.ComponentModel.DataAnnotations;

namespace DealSe.Areas.Admin.FormModels
{
    //Event ticket type viewModel
    public class CountryFormModel
    {
        [Key]
        public int CountryId { get; set; }
        [Required(ErrorMessage = "This field is required.")]
        [StringLength(150, ErrorMessage = "The name must be a maximum length of 150.")]
        public string Name { get; set; }
        public bool Active { get; set; }
        public DateTime AddedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
       
    }
}
