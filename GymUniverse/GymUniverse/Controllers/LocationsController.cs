using GymUniverse.Models;
using Microsoft.AspNetCore.Mvc;

namespace GymUniverse.Controllers
{
    public class LocationsController : Controller
    {
        private static List<Location> locations = new List<Location>();


        public IActionResult Index()
        {
            return View(locations);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        
        [HttpPost]
        public IActionResult Create(Location location)
        {
            return View();
        }
    }
}
