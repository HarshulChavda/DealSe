using Microsoft.AspNetCore.Mvc;

namespace DealSe.Controllers
{
    public class ErrorController : Controller
    {
        public IActionResult Index(int id)
        {
            if (id == 400)
            {

            }
            else
            {

            }
            return View();
        }
    }
}