using GymUniverse.Models;
using Microsoft.AspNetCore.Mvc;

namespace GymUniverse.Controllers
{
    public class LocationController : Controller
    {
        private static List<Location> locations = new List<Location>();

        //Action to display all of the registered locations
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View(locations);
        }

        //Action to display from for creating a new location
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }
        
        //Action to handle from submission for creating a new location
        [HttpPost]
        public IActionResult Create(Location location)
        {
            location.Id = locations.Count + 1;

            locations.Add(location);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            Location location = locations.Find(l => l.Id == id);

            if (location == null)
            {
                return NotFound(); //Returns 404 Not Found
            }

            return View(location);
        }
    }
}
