using System;
using System.ComponentModel.DataAnnotations;

namespace DealSe.Areas.Admin.FormModels
{
    public class EmailTemplateFormModel
    {
        public int EmailTemplateId { get; set; }

        [Required(ErrorMessage = "This field is required")]
        public string EmailTemplateName { get; set; }

        [Required(ErrorMessage = "This field is required")]
        public string EmailTemplateSubject { get; set; }

        [Required(ErrorMessage = "This field is required")]
        public string EmailTemplateBody { get; set; }
        public DateTime AddedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
