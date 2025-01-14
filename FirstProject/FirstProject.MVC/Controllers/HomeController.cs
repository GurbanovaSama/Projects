using FirstProject.BL.Services.Implementations;
using FirstProject.DAL.Models;
using Microsoft.AspNetCore.Mvc;

namespace FirstProject.MVC.Controllers
{
    public class HomeController : Controller
    {
        

        public  ActionResult Index()
        {
         
            return View();
        }
    }
}
