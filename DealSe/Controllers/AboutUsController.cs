using Microsoft.AspNetCore.Mvc;

namespace DealSe.Controllers
{
    public class AboutUsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
