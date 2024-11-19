using GymUniverse.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;


namespace GymUniverse.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            ErrorViewModel model = new ErrorViewModel();
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}
