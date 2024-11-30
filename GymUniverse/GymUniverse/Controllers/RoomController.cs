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
        [HttpGet]
        public IActionResult CreateRoom(int locationId)
        {
            var room = new Room
            {
                LocationId = locationId,
            };

            return View(room);
        }

        // POST: Room/Create
        [HttpPost]
        public async Task<IActionResult> CreateRoom(Room room)
        {
            ViewBag.LocationId = room.LocationId;
            ModelState.Remove(nameof(room.Location));
            if (ModelState.IsValid)
            {
                _context.Rooms.Add(room);
                await _context.SaveChangesAsync();
                return RedirectToAction("LocationDetails", "Location", new { id = room.LocationId });
            }
            return View(room);
        }

        // GET: Room/Details/{id}
        public async Task<IActionResult> RoomDetails(int id)
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
