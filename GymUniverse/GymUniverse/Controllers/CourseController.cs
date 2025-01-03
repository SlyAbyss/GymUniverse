﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using GymUniverse.Models;
using GymUniverse.Data;
using Microsoft.AspNetCore.Identity;
using GymUniverse.ViewModels.CourseViewModels;

namespace GymUniverse.Controllers
{
    [AutoValidateAntiforgeryToken]
    public class CourseController : Controller
    {
        private readonly GymUniverseDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public CourseController(GymUniverseDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
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

            var viewModel = new CreateCourseViewModel
            {
                TrainerId = trainerId,
            };

            return View(viewModel);
        }


        [HttpPost]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> CreateCourse(CreateCourseViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var course = new Course
            {
                TrainerId = model.TrainerId,
                Name = model.Name,
                Price = model.Price,
                Schedule = model.Schedule,
                Description = model.Description
            };

            _context.Courses.Add(course);
            await _context.SaveChangesAsync();
            return RedirectToAction("TrainerDetails", "Trainer", new { id = course.TrainerId });
        }


        [HttpPost]
        [Authorize(Roles = "User")]
        public async Task<IActionResult> AddToMyCourses(int courseId)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return Unauthorized();
            }

            var course = await _context.Courses.FirstOrDefaultAsync(c => c.Id == courseId);
            if (course == null)
            {
                return NotFound();
            }

            var isAlreadyAdded = await _context.UsersCourses
                .AnyAsync(uc => uc.UserId == user.Id && uc.CourseId == courseId);

            if (!isAlreadyAdded)
            {
                _context.UsersCourses.Add(new UserCourse
                {
                    UserId = user.Id,
                    CourseId = courseId
                });

                await _context.SaveChangesAsync();
            }

            return RedirectToAction("Index", "MyCourses");
        }

        [HttpPost]
        [Authorize(Roles = "User")]
        public async Task<IActionResult> RemoveFromMyCourses(int courseId)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return Unauthorized();
            }

            var userCourse = await _context.UsersCourses
                .FirstOrDefaultAsync(uc => uc.UserId == user.Id && uc.CourseId == courseId);

            if (userCourse != null)
            {
                _context.UsersCourses.Remove(userCourse);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction("Index", "MyCourses");
        }

        [HttpPost]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> DeleteCourse(int id)
        {
            var course = await _context.Courses
                .Include(c => c.UserCourses)
                .FirstOrDefaultAsync(c => c.Id == id);

            if (course == null)
            {
                return NotFound();
            }

            _context.UsersCourses.RemoveRange(course.UserCourses);

            _context.Courses.Remove(course);

            await _context.SaveChangesAsync();

            return RedirectToAction("TrainerDetails", "Trainer", new { id = course.TrainerId });
        }
    }
}
