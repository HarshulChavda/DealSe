using System;
using System.ComponentModel.DataAnnotations;

namespace DealSe.Areas.Admin.FormModels
{
    public class SiteSettingFormModel
    {
        public int SiteSettingId { get; set; }    
        public string SiteSettingName { get; set; }       
        public string SiteSettingType { get; set; }
        public string SiteSettingValue { get; set; }
        public bool EnforceValidation { get; set; }
        public DateTime AddedDate { get; set; }
        public string EmailTypeSiteSettingValue { get; set; }
        public string DomainTypeSiteSettingValue { get; set; }
        public string TextTypeSiteSettingValue { get; set; }
        public string NumberTypeSiteSettingValue { get; set; }
        public bool BooleanTypeSiteSettingValue { get; set; }
        [DataType(DataType.Html)]
        public string HtmlTypeSiteSettingValue { get; set; }
    }
}
