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

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error(int statusCode)
        {
            return statusCode switch
            {
                404 => View("Error404"),
                500 => View("Error500"),
                _ => View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier })
            };
        }
    }
}
