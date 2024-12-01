using GymUniverse.Data;
using GymUniverse.Models;
using GymUniverse.ViewModels.EquipmentViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

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
        [Authorize(Roles = "Administrator")]
        public IActionResult CreateEquipment(int roomId)
        {
            var equipment = new Equipment();
            var viewModel = new CreateEquipmentViewModel()
            {
                Equipment = equipment,
                RoomId = roomId
            };
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> CreateEquipment(CreateEquipmentViewModel viewModel)
        {
            ModelState.Remove("Equipment.RoomEquipments");
            if (ModelState.IsValid)
            {
                _context.Equipment.Add(viewModel.Equipment);
                await _context.SaveChangesAsync();
                return RedirectToAction("AddEquipment", "Room", new {roomId = viewModel.RoomId });
            }
            return View(viewModel.Equipment);
        }
    }

}
