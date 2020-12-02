using DealSe.ActionFilter;
using Microsoft.AspNetCore.Mvc;

namespace DealSe.Areas.Admin.Controllers
{
    [Area("Admin")]
    [AdminAuthorizeFilter]
    public class ErrorController : Controller
    {
        public IActionResult Index(int id)
        {
            if(id == 400)
            {
               
            }
            else
            {

            }
            return View();
        }
    }
}