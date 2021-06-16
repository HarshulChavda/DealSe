using DealSe.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace DealSe.Controllers
{
    public class HomeController : Controller
    {
        private readonly INotificationService notificationService;
        public HomeController(INotificationService notificationService) {
            this.notificationService = notificationService;
        }
        public IActionResult Index()
        {
            //notificationService.SendMobileNotification(0, "", "dwLFSHHKR86ncGfqBEcz2-:APA91bFFKvCjAbelntUfkA8O4ssG2OTgLvu6XmrFWeZcz7hx334WNg1hJhjGVUiZDTOVOqedccz8lkmpEhYGtB_y9qZm1ODtaKzrly4URmHL4n4OQJWGvRPgdrGIJOCHzfduwAKeQCWM", "", "", "2");
            return View();
        }
        public IActionResult PrivacyPolicy()
        {
            return View();
        }
    }
}
