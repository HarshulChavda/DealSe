using Microsoft.AspNetCore.Mvc;

namespace DealSe.Controllers
{
    public class PrivacyPolicyController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
