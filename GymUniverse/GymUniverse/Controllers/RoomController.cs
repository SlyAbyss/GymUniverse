using Microsoft.AspNetCore.Mvc;
using GymUniverse.Data;
using GymUniverse.Models;
using Microsoft.EntityFrameworkCore;
using GymUniverse.ViewModels;

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

        [HttpGet]
        public IActionResult AddEquipment(int roomId)
        {
            var room = _context.Rooms
                .Include(r => r.RoomsEquipments)                                    
                .ThenInclude(re => re.Equipment)                                     
                .FirstOrDefault(r => r.Id == roomId);

            if (room == null)
            {
                return NotFound();
            }

            var allEquipments = _context.Equipment.ToList();

            var model = new EquipmentRoomViewModel
            {
                RoomId = roomId,
                RoomName = room.Name,
                Equipment = allEquipments,
                SelectedEquipment = room.RoomsEquipments.Select(re => re.EquipmentId).ToList()
            };

            return View(model);
        }

        // POST: Room/AddEquipment/{roomId}
        [HttpPost]
        public async Task<IActionResult> AddEquipment(EquipmentRoomViewModel model)
        {
            if (ModelState.IsValid)
            {
                var room = await _context.Rooms.Include(r => r.RoomsEquipments).FirstOrDefaultAsync(r => r.Id == model.RoomId);

                if (room == null)
                {
                    return NotFound();
                }

                // Remove existing associations
                var existingAssociations = _context.RoomsEquipments.Where(re => re.RoomId == model.RoomId).ToList();
                _context.RoomsEquipments.RemoveRange(existingAssociations);

                // Add new associations
                foreach (var equipmentId in model.SelectedEquipment)
                {
                    _context.RoomsEquipments.Add(new RoomEquipment
                    {
                        RoomId = model.RoomId,
                        EquipmentId = equipmentId
                    });
                }

                await _context.SaveChangesAsync();
                return RedirectToAction("RoomDetails", new { id = model.RoomId });
            }

            return View(model);
        }
    }
}
