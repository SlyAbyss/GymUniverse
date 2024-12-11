using Microsoft.AspNetCore.Mvc;
using GymUniverse.Data;
using GymUniverse.Models;
using Microsoft.EntityFrameworkCore;
using GymUniverse.ViewModels.EquipmentViewModels;
using Microsoft.AspNetCore.Authorization;
using GymUniverse.ViewModels.RoomViewModels;

namespace GymUniverse.Controllers
{
    [AutoValidateAntiforgeryToken]
    public class RoomController : Controller
    {
        private readonly GymUniverseDbContext _context;

        public RoomController(GymUniverseDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Authorize(Roles = "Administrator")]
        public IActionResult CreateRoom(int locationId)
        {
            var room = new Room
            {
                LocationId = locationId,
            };

            return View(room);
        }

        [HttpPost]
        public async Task<IActionResult> CreateRoom(Room room)
        {
            ViewBag.LocationId = room.LocationId;
            ModelState.Remove(nameof(room.Location));
            ModelState.Remove(nameof(room.RoomsEquipments));
            if (ModelState.IsValid)
            {
                _context.Rooms.Add(room);
                await _context.SaveChangesAsync();
                return RedirectToAction("LocationDetails", "Location", new { id = room.LocationId });
            }
            return View(room);
        }

        public async Task<IActionResult> RoomDetails(int id)
        {
            var room = await _context.Rooms
                .Include(r => r.RoomsEquipments)
                .ThenInclude(re => re.Equipment)
                .FirstOrDefaultAsync(r => r.Id == id);

            if (room == null)
            {
                return NotFound("Room not found.");
            }

            return View(room);
        }

        [HttpGet]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> EditRoom(int id)
        {

            var room = await _context.Rooms.FindAsync(id);
            if (room == null)
            {
                return NotFound();
            }

            RoomEditViewModel roomView = new RoomEditViewModel()
            {
               Id = id,
               Name = room.Name,
               Description = room.Description,
               ImageUrl = room.ImageUrl,
            };

            return View(roomView);
        }

        [HttpPost]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> EditRoom(RoomEditViewModel room)
        {
            var roomToEdit = await _context.Rooms.FindAsync(room.Id);

            if (roomToEdit == null)
            {
                return NotFound();
            }

            roomToEdit.Name = room.Name;
            roomToEdit.Description = room.Description;
            roomToEdit.ImageUrl = room.ImageUrl;

            if (ModelState.IsValid)
            {
                 _context.Update(roomToEdit);
                await _context.SaveChangesAsync();
                return RedirectToAction("RoomDetails", new { id = room.Id });
            }

            return View(room);
        }

        [HttpPost]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> DeleteRoom(int id)
        {
            var room = await _context.Rooms
                .Include(r => r.RoomsEquipments)
                .FirstOrDefaultAsync(r => r.Id == id);

            if (room == null)
            {
                return NotFound();
            }

            _context.RoomsEquipments.RemoveRange(room.RoomsEquipments);
            _context.Rooms.Remove(room);
            await _context.SaveChangesAsync();

            return RedirectToAction("LocationDetails", "Location", new { id = room.LocationId });
        }
    }
}
