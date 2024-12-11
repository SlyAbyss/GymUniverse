using GymUniverse.Data;
using GymUniverse.Models;
using GymUniverse.ViewModels.LocationViewModels;
using GymUniverse.ViewModels.RoomViewModels;
using GymUniverse.ViewModels.TrainerViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GymUniverse.Controllers
{
    [AutoValidateAntiforgeryToken]
    public class LocationController : Controller
    {
        private readonly GymUniverseDbContext _context;

        public LocationController(GymUniverseDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var locations = await _context.Locations
                .Select(l => new LocationViewModel
                {
                    Id = l.Id,
                    Name = l.Name,
                    Address = l.Address,
                    ImageUrl = l.ImageUrl
                })
                .ToListAsync();

            return View(locations);
        }

        [HttpGet]
        [Authorize(Roles = "Administrator")]
        public IActionResult CreateLocation()
        {
            return View(new CreateLocationViewModel());
        }

        [HttpPost]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> CreateLocation(CreateLocationViewModel model)
        {
            if (ModelState.IsValid)
            {
                var location = new Location
                {
                    Name = model.Name,
                    Address = model.Address,
                    ImageUrl = model.ImageUrl,
                    Description = model.Description
                };

                _context.Locations.Add(location);
                await _context.SaveChangesAsync();

                return RedirectToAction("Index");
            }

            return View(model);
        }


        [HttpGet]
        public async Task<IActionResult> LocationDetails(int id)
        {
            var location = await _context.Locations
                .Include(l => l.Rooms)
                .Include(l => l.Trainers)
                .FirstOrDefaultAsync(l => l.Id == id);

            if (location == null)
            {
                return NotFound();
            }

            var viewModel = new LocationDetailsViewModel
            {
                Id = location.Id,
                Name = location.Name,
                Address = location.Address,
                Description = location.Description,
                ImageUrl = location.ImageUrl,
                Rooms = location.Rooms.Select(room => new RoomViewModel
                {
                    Id = room.Id,
                    Name = room.Name,
                    ImageUrl = room.ImageUrl
                }).ToList(),
                Trainers = location.Trainers.Select(trainer => new TrainerViewModel
                {
                    Id = trainer.Id,
                    Name = trainer.Name,
                    ImageUrl = trainer.ImageUrl
                }).ToList()
            };

            return View(viewModel);
        }

        [HttpPost]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Delete(int id)
        {
            var location = await _context.Locations.FindAsync(id);

            if (location == null)
            {
                return NotFound();
            }

            _context.Locations.Remove(location);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        [HttpGet]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> EditLocation(int id)
        {
            var location = await _context.Locations.FindAsync(id);
            if (location == null)
            {
                return NotFound();
            }

            var model = new EditLocationViewModel
            {
                Id = location.Id,
                Name = location.Name,
                Address = location.Address,
                ImageUrl = location.ImageUrl,
                Description = location.Description
            };

            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> EditLocation(EditLocationViewModel model)
        {
            if (ModelState.IsValid)
            {
                var location = await _context.Locations.FindAsync(model.Id);
                if (location == null)
                {
                    return NotFound();
                }

                location.Name = model.Name;
                location.Address = model.Address;
                location.ImageUrl = model.ImageUrl;
                location.Description = model.Description;

                _context.Locations.Update(location);
                await _context.SaveChangesAsync();

                return RedirectToAction("Index");
            }

            return View(model);
        }
    }
}
