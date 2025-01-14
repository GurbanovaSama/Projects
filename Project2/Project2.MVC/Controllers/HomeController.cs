using Microsoft.AspNetCore.Mvc;

namespace Project2.MVC.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
