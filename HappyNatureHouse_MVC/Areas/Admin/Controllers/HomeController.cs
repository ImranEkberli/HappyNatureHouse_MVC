using Microsoft.AspNetCore.Mvc;

namespace HappyNatureHouse_MVC.Areas.Admin.Controllers
{
    [Area("admin")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
