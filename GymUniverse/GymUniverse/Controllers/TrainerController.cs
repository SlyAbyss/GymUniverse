using Microsoft.AspNetCore.Mvc;

namespace GymUniverse.Controllers
{
    public class TrainerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
