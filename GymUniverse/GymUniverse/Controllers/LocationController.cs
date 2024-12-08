using GymUniverse.Data;
using GymUniverse.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GymUniverse.Controllers
{
    public class LocationController : Controller
    {
        private readonly GymUniverseDbContext _context;

        public LocationController(GymUniverseDbContext context)
        {
            _context = context;
        }

        // Action to display all of the registered locations
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var locations = await _context.Locations.ToListAsync();
            return View(locations);
        }

        // Action to display form for creating a new location
        [HttpGet]
        [Authorize(Roles = "Administrator")]
        public IActionResult CreateLocation()
        {
            return View();
        }

        // Action to handle form submission for creating a new location
        [HttpPost]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> CreateLocation(Location location)
        {
            if (ModelState.IsValid)
            {
                _context.Locations.Add(location);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(location);
        }

        // Action to display details of a specific location
        [HttpGet]
        public async Task<IActionResult> LocationDetails(int id)
        {
            var location = await _context.Locations
                .Include(l => l.Rooms)
                .Include(l => l.Trainers)
                .FirstOrDefaultAsync(l => l.Id == id);

            if (location == null)
            {
                return NotFound(); // Returns 404 Not Found
            }

            return View(location);
        }

        // Action to delete a location permanently from the database
        [HttpPost]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Delete(int id)
        {
            var location = await _context.Locations.FindAsync(id);

            if (location == null)
            {
                return NotFound(); // Location not found
            }

            _context.Locations.Remove(location);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        // Action to display form for editing a location
        [HttpGet]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> EditLocation(int id)
        {
            var location = await _context.Locations.FindAsync(id);
            if (location == null)
            {
                return NotFound();
            }

            return View(location);
        }

        // Action to handle form submission for editing a location
        [HttpPost]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> EditLocation(int id, Location location)
        {
            if (id != location.Id)
            {
                return BadRequest(); // IDs do not match
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Locations.Update(location);
                    await _context.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await LocationExists(location.Id))
                    {
                        return NotFound(); // Location no longer exists
                    }
                    else
                    {
                        throw;
                    }
                }
            }

            return View(location);
        }

        private async Task<bool> LocationExists(int id)
        {
            return await _context.Locations.AnyAsync(e => e.Id == id);
        }
    }
}
