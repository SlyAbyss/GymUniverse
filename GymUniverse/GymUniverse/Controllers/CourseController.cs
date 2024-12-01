using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using GymUniverse.Models;
using GymUniverse.Data;
using NuGet.DependencyResolver;

namespace GymUniverse.Controllers
{
    [Authorize]
    public class CourseController : Controller
    {
        private readonly GymUniverseDbContext _context;

        public CourseController(GymUniverseDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> CreateCourse(int trainerId)
        {
            var trainer = await _context.Trainers.FirstOrDefaultAsync(t => t.Id == trainerId);
            if (trainer == null)
            {
                return NotFound();
            }

            ViewBag.TrainerName = trainer.Name;
            ViewBag.TrainerId = trainerId;

            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> CreateCoruse(Course course)
        {
            ModelState.Remove(nameof(course.Trainer));
            if (ModelState.IsValid)
            {
                _context.Courses.Add(course);
                await _context.SaveChangesAsync();
                return RedirectToAction("TrainerDetails", "Trainer", new { id = course.TrainerId });
            }

            return View(course);
        }
    }
}
