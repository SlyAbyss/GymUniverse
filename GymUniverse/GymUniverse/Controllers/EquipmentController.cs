using GymUniverse.Data;
using GymUniverse.Models;
using GymUniverse.ViewModels.EquipmentViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace GymUniverse.Controllers
{
    [AutoValidateAntiforgeryToken]
    public class EquipmentController : Controller
    {
        private readonly GymUniverseDbContext _context;

        public EquipmentController(GymUniverseDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Authorize(Roles = "Administrator")]
        public IActionResult CreateEquipment(int roomId)
        {
            var model = new CreateEquipmentViewModel()
            {
                RoomId = roomId
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> CreateEquipment(CreateEquipmentViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var equipment = new Equipment
            {
                Name = model.Name,
                ImageUrl = model.ImageUrl,
                Description = model.Description
            };

            _context.Equipment.Add(equipment);
            await _context.SaveChangesAsync();

            return RedirectToAction("AddEquipment", "Equipment", new { roomId = model.RoomId });
        }

        [HttpPost]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> DeleteEquipment(int id, int? roomId = null)
        {
            var equipment = await _context.Equipment.FindAsync(id);
            if (equipment == null)
            {
                return NotFound("Equipment not found.");
            }

            _context.Equipment.Remove(equipment);
            await _context.SaveChangesAsync();

            if (roomId.HasValue)
            {
                return RedirectToAction("AddEquipment", "Equipment", new { roomId = roomId.Value });
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        [Authorize(Roles = "Administrator")]
        public IActionResult AddEquipment(int roomId, int page = 1, int pageSize = 6)
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
            var paginatedEquipments = allEquipments
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            var totalEquipments = allEquipments.Count;

            var model = new EquipmentRoomViewModel
            {
                RoomId = roomId,
                RoomName = room.Name,
                Equipment = paginatedEquipments,
                SelectedEquipment = room.RoomsEquipments.Select(re => re.EquipmentId).ToList(),
                CurrentPage = page,
                TotalPages = (int)Math.Ceiling(totalEquipments / (double)pageSize)
            };

            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> AddEquipment(int RoomId, int EquipmentId)
        {
            var room = await _context.Rooms.Include(r => r.RoomsEquipments).FirstOrDefaultAsync(r => r.Id == RoomId);
            var equipment = await _context.Equipment.FindAsync(EquipmentId);

            if (room == null || equipment == null)
            {
                return NotFound();
            }

            if (!room.RoomsEquipments.Any(re => re.EquipmentId == EquipmentId))
            {
                _context.RoomsEquipments.Add(new RoomEquipment
                {
                    RoomId = RoomId,
                    EquipmentId = EquipmentId
                });
                await _context.SaveChangesAsync();
            }

            return RedirectToAction("AddEquipment", new { roomId = RoomId });
        }

        [HttpPost]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> RemoveEquipment(int RoomId, int EquipmentId)
        {
            var roomEquipment = _context.RoomsEquipments
                .FirstOrDefault(re => re.RoomId == RoomId && re.EquipmentId == EquipmentId);

            if (roomEquipment != null)
            {
                _context.RoomsEquipments.Remove(roomEquipment);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction("AddEquipment", new { roomId = RoomId });
        }
    }
}
