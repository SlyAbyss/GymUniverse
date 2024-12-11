using GymUniverse.Data;
using GymUniverse.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GymUniverse.Controllers
{
    [AutoValidateAntiforgeryToken]
    public class LocationController : Controller
    {
        private readonly GymUniverseDbContext _context;

        public LocationController(GymUniverseDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var locations = await _context.Locations.ToListAsync();
            return View(locations);
        }

        [HttpGet]
        [Authorize(Roles = "Administrator")]
        public IActionResult CreateLocation()
        {
            return View();
        }

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

        [HttpGet]
        public async Task<IActionResult> LocationDetails(int id)
        {
            var location = await _context.Locations
                .Include(l => l.Rooms)
                .Include(l => l.Trainers)
                .FirstOrDefaultAsync(l => l.Id == id);

            if (location == null)
            {
                return NotFound();
            }

            return View(location);
        }

        [HttpPost]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Delete(int id)
        {
            var location = await _context.Locations.FindAsync(id);

            if (location == null)
            {
                return NotFound();
            }

            _context.Locations.Remove(location);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }

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

        [HttpPost]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> EditLocation(int id, Location location)
        {
            if (id != location.Id)
            {
                return BadRequest();
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
                        return NotFound();
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
