using GymUniverse.Data;
using GymUniverse.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;


namespace GymUniverse.Controllers
{
    public class HomeController : Controller
    {

        private readonly GymUniverseDbContext _context;

        public HomeController(GymUniverseDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            ErrorViewModel model = new ErrorViewModel();
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult AboutUs()
        {
            return View();
        }

        public IActionResult Careers()
        {
            return View();
        }

        public IActionResult Prices()
        {
            return View();
        }

        public IActionResult ContactUs()
        {
            return View();
        }
    }
}
