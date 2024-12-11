using GymUniverse.Data;
using GymUniverse.Models;
using GymUniverse.ViewModels.ContactUsViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GymUniverse.Controllers
{
    [AutoValidateAntiforgeryToken]
    public class ContactUsController : Controller
    {
        private readonly GymUniverseDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public ContactUsController(GymUniverseDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var viewModel = new ContactMessageViewModel
            {
                LoggedInUsername = User.Identity.IsAuthenticated ? User.Identity.Name : string.Empty,
                LoggedInEmail = User.Identity.IsAuthenticated ? (await _userManager.FindByNameAsync(User.Identity.Name))?.Email : string.Empty
            };
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Submit(ContactMessageViewModel model)
        {
            if (ModelState.IsValid)
            {
                var contactMessage = new ContactMessage
                {
                    Name = model.Name,
                    Email = model.Email,
                    Message = model.Message,
                    SubmittedAt = DateTime.Now
                };

                _context.ContactMessages.Add(contactMessage);
                await _context.SaveChangesAsync();

                return RedirectToAction("Index");
            }

            return View("Index", model);
        }

        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> UserMessages()
        {
            var messages = await _context.ContactMessages.ToListAsync();

            var viewModel = new UserMessagesViewModel
            {
                ContactMessages = messages
            };

            return View(viewModel);
        }

        [Authorize(Roles = "Administrator")]
        [HttpPost]
        public async Task<IActionResult> DeleteMessage(int messageId)
        {
            var message = await _context.ContactMessages.FindAsync(messageId);
            if (message != null)
            {
                _context.ContactMessages.Remove(message);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(UserMessages));
        }
    }
}
