using GymUniverse.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace GymUniverse.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}
