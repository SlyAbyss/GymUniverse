using GymUniverse.Data;
using GymUniverse.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GymUniverse.Controllers
{
    public class TrainerController : Controller
    {
        private readonly GymUniverseDbContext _context;

        public TrainerController(GymUniverseDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Authorize(Roles = "Administrator")]
        public IActionResult CreateTrainer(int locationId)
        {
            var room = new Room
            {
                LocationId = locationId,
            };

            ViewBag.LocationId = locationId;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateTrainer(Trainer trainer)
        {
            ModelState.Remove(nameof(trainer.Location));
            if (ModelState.IsValid)
            {
                _context.Trainers.Add(trainer);
                await _context.SaveChangesAsync();
                return RedirectToAction("LocationDetails", "Location", new { id = trainer.LocationId });
            }

            return View(trainer);
        }

        [HttpGet]
        public async Task<IActionResult> TrainerDetails(int id)
        {
            var trainer = await _context.Trainers
                .Include(t => t.Location)
                .Include(t => t.Courses)
                .FirstOrDefaultAsync(t => t.Id == id);

            if (trainer == null)
            {
                return NotFound("Trainer not found.");
            }

            return View(trainer);
        }
    }
}
