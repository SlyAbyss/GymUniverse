using GymUniverse.Data;
using GymUniverse.Models;
using GymUniverse.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GymUniverse.Controllers
{
    [AutoValidateAntiforgeryToken]
    public class MyCoursesController : Controller
    {
        private readonly GymUniverseDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public MyCoursesController(GymUniverseDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return Unauthorized();
            }

            var courses = await _context.UsersCourses
                .Where(uc => uc.UserId == user.Id)
                .Select(uc => uc.Course)
                .ToListAsync();


            foreach (var course in courses)
            {
                var trainer = await _context.Trainers.FirstOrDefaultAsync(t => t.Id == course.TrainerId);
                var location = await _context.Locations.FirstOrDefaultAsync(l => l.Id == trainer.LocationId);
                trainer.Location = location;
                course.Trainer = trainer;
            }

            return View(courses);
        }
    }
}
