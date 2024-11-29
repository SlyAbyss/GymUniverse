using Microsoft.AspNetCore.Mvc;

namespace GymUniverse.Controllers
{
    public class RoomController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
