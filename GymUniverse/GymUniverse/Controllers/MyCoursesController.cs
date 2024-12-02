using GymUniverse.Data;
using GymUniverse.Models;
using GymUniverse.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GymUniverse.Controllers
{
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

            return View(courses);
        }
    }
}
