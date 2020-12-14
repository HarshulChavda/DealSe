namespace DealSe.Areas.Admin.ViewModels
{
    public class EmailTemplateViewModel
    {
        public int EmailTemplateId { get; set; }
        public string EmailTemplateName { get; set; }
        public string EmailTemplateSubject { get; set; }
        public string EmailTemplateBody { get; set; }
        public string AddedDate { get; set; }
        public string UpdatedDate { get; set; }
    }
}
