using Microsoft.AspNetCore.Mvc;
using GymUniverse.Data;
using GymUniverse.Models;
using Microsoft.EntityFrameworkCore;

namespace GymUniverse.Controllers
{
    public class RoomController : Controller
    {
        private readonly GymUniverseDbContext _context;

        public RoomController(GymUniverseDbContext context)
        {
            _context = context;
        }

        // GET: Room/Create
        public IActionResult Create(int locationId)
        {
            ViewBag.LocationId = locationId;
            return View();
        }

        // POST: Room/Create
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Room room)
        {
            if (ModelState.IsValid)
            {
                _context.Rooms.Add(room);
                await _context.SaveChangesAsync();
                return RedirectToAction("Details", "Location", new { id = room.LocationId });
            }
            ViewBag.LocationId = room.LocationId;
            return View(room);
        }

        // GET: Room/Details/{id}
        public async Task<IActionResult> Details(int id)
        {
            var room = await _context.Rooms
                .Include(r => r.Location)
                .FirstOrDefaultAsync(r => r.Id == id);

            if (room == null)
            {
                return NotFound();
            }

            return View(room);
        }
    }
}
