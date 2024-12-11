using GymUniverse.Data;
using GymUniverse.Models;
using GymUniverse.ViewModels.RoomViewModels;
using GymUniverse.ViewModels.TrainerViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GymUniverse.Controllers
{
    [AutoValidateAntiforgeryToken]
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
            var viewModel = new CreateTrainerViewModel
            {
                LocationId = locationId
            };

            ViewBag.LocationId = locationId;
            return View(viewModel);
        }

        [HttpPost]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> CreateTrainer(CreateTrainerViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var trainer = new Trainer
                {
                    Name = viewModel.Name,
                    Age = viewModel.Age,
                    ImageUrl = viewModel.ImageUrl,
                    Bio = viewModel.Bio,
                    LocationId = viewModel.LocationId
                };

                _context.Trainers.Add(trainer);
                await _context.SaveChangesAsync();

                return RedirectToAction("LocationDetails", "Location", new { id = trainer.LocationId });
            }

            return View(viewModel);
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

            var trainerViewModel = new TrainerDetailsViewModel
            {
                Id = trainer.Id,
                Name = trainer.Name,
                Age = trainer.Age,
                Bio = trainer.Bio,
                ImageUrl = trainer.ImageUrl,
                Location = trainer.Location,
                Courses = trainer.Courses.ToList()
            };

            return View(trainerViewModel);
        }

        [HttpGet]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> EditTrainer(int id)
        {
            var trainer = await _context.Trainers.FirstOrDefaultAsync(t => t.Id == id);
            if (trainer == null)
            {
                return NotFound("Trainer not found.");
            }

            var trainerView = new TrainerEditViewModel
            {
                Id = trainer.Id,
                Name = trainer.Name,
                Age = trainer.Age,
                Bio = trainer.Bio,
                ImageUrl = trainer.ImageUrl,
            };

            return View(trainerView);
        }

        [HttpPost]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> EditTrainer(TrainerEditViewModel trainer)
        {
            var trainerToEdit = await _context.Trainers.FindAsync(trainer.Id);
            if (trainerToEdit == null)
            {
                return NotFound();
            }

            trainerToEdit.Name = trainer.Name;
            trainerToEdit.Age = trainer.Age;
            trainerToEdit.Bio = trainer.Bio;
            trainerToEdit.ImageUrl = trainer.ImageUrl;

            if (ModelState.IsValid)
            {
                _context.Trainers.Update(trainerToEdit);
                await _context.SaveChangesAsync();
                return RedirectToAction("TrainerDetails", new { id = trainer.Id });
            }

            return View(trainer);
        }

        [HttpPost]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> DeleteTrainer(int id)
        {
            var trainer = await _context.Trainers.FirstOrDefaultAsync(t => t.Id == id);
            if (trainer == null)
            {
                return NotFound("Trainer not found.");
            }

            _context.Trainers.Remove(trainer);
            await _context.SaveChangesAsync();
            return RedirectToAction("LocationDetails", "Location", new { id = trainer.LocationId });
        }
    }
}
