﻿using Microsoft.AspNetCore.Mvc;
using GymUniverse.Data;
using GymUniverse.Models;
using Microsoft.EntityFrameworkCore;
using GymUniverse.ViewModels.EquipmentViewModels;
using Microsoft.AspNetCore.Authorization;

namespace GymUniverse.Controllers
{
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

        [HttpPost]
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
