using GymUniverse.Data;
using GymUniverse.Models;
using Microsoft.AspNetCore.Mvc;

namespace GymUniverse.Controllers
{
    public class EquipmentController : Controller
    {
        private readonly GymUniverseDbContext _context;

        public EquipmentController(GymUniverseDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult CreateEquipment()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateEquipment(Equipment equipment)
        {
            ModelState.Remove(nameof(equipment.RoomEquipments));
            if (ModelState.IsValid)
            {
                _context.Equipment.Add(equipment);
                await _context.SaveChangesAsync();
                return RedirectToAction("AddEquipment", "Room");
            }
            return View(equipment);
        }
    }

}
