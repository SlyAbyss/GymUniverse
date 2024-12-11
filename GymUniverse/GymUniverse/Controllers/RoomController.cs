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
            var room = new CreateRoomViewModel
            {
                LocationId = locationId
            };

            return View(room);
        }

        [HttpPost]
        public async Task<IActionResult> CreateRoom(CreateRoomViewModel room)
        {
            ViewBag.LocationId = room.LocationId;

            if (ModelState.IsValid)
            {
                var roomEntity = new Room
                {
                    LocationId = room.LocationId,
                    Name = room.Name,
                    ImageUrl = room.ImageUrl,
                    Description = room.Description
                };

                _context.Rooms.Add(roomEntity);
                await _context.SaveChangesAsync();

                return RedirectToAction("LocationDetails", "Location", new { id = room.LocationId });
            }

            return View(room);
        }

        [HttpGet]
        public async Task<IActionResult> RoomDetails(int id)
        {
            var room = await _context.Rooms
                .Include(r => r.Location)
                .Include(r => r.RoomsEquipments)
                .ThenInclude(re => re.Equipment)
                .FirstOrDefaultAsync(r => r.Id == id);

            if (room == null)
            {
                return NotFound("Room not found.");
            }

            var roomDetailsViewModel = new RoomDetailsViewModel
            {
                Id = room.Id,
                Name = room.Name,
                Description = room.Description,
                ImageUrl = room.ImageUrl,
                Location = room.Location,
                RoomsEquipments = room.RoomsEquipments.Select(re => new RoomEquipmentViewModel
                {
                    EquipmentId = re.Equipment.Id,
                    EquipmentName = re.Equipment.Name,
                    EquipmentDescription = re.Equipment.Description,
                    EquipmentImageUrl = re.Equipment.ImageUrl
                }).ToList()
            };

            return View(roomDetailsViewModel);
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
