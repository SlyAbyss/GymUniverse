using GymUniverse.Data;
using GymUniverse.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GymUniverse.Controllers
{
    public class ContactUsController : Controller
    {
        private readonly GymUniverseDbContext _context;

        public ContactUsController(GymUniverseDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.Username = User.Identity.IsAuthenticated ? User.Identity.Name : string.Empty;
            return View(new ContactMessage());
        }

        [HttpPost]
        public async Task<IActionResult> Submit(ContactMessage contactMessage)
        {
            if (ModelState.IsValid)
            {
                contactMessage.SubmittedAt = DateTime.Now;
                _context.ContactMessages.Add(contactMessage);
                await _context.SaveChangesAsync();
                TempData["Success"] = "Your message has been sent successfully!";
                return RedirectToAction("Index");
            }

            TempData["Error"] = "Please correct the errors and try again.";
            return View("Index", contactMessage);
        }

        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> UserMassages()
        {
            var messages = await _context.ContactMessages.ToListAsync();
            return View(messages);
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

            return RedirectToAction(nameof(UserMassages));
        }
    }
}
