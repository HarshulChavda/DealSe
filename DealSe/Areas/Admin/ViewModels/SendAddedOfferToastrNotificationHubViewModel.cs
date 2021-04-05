using System.ComponentModel.DataAnnotations;

namespace DealSe.Areas.Admin.ViewModels
{
    public class SendAddedOfferToastrNotificationHubViewModel
    {
        public int OfferId { get; set; }
        [StringLength(250)]
        public string Name { get; set; }
        [StringLength(100)]
        public string StoreName { get; set; }
        public string BaseUrl { get; set; }
    }
}
