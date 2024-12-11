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

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Privacy()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AboutUs()
        {
            return View();
        }
    }
}
