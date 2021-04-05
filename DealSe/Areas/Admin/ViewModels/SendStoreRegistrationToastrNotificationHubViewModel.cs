using System.ComponentModel.DataAnnotations;

namespace DealSe.Areas.Admin.ViewModels
{
    public class SendStoreRegistrationToastrNotificationHubViewModel
    {
        public int StoreId { get; set; }
        [StringLength(100)]
        public string Name { get; set; }
        [StringLength(250)]
        public string AreaName { get; set; }
        [StringLength(10)]
        public string OwnerMobileNo { get; set; }
        public string BaseUrl { get; set; }
    }
}
