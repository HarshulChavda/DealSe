using Microsoft.AspNetCore.Mvc;

namespace DealSe.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
