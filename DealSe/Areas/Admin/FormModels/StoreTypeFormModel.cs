using System;
using System.ComponentModel.DataAnnotations;

namespace DealSe.Areas.Admin.FormModels
{
    //Store Type form model
    public class StoreTypeFormModel
    {
        public int StoreTypeId { get; set; }
        [Required(ErrorMessage = "This field is required.")]
        [StringLength(150, ErrorMessage = "The name must be a maximum length of 150.")]
        public string Name { get; set; }
        public bool Active { get; set; }
        public DateTime AddedDate { get; set; }
    }
}
