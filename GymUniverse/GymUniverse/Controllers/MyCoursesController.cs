using Microsoft.AspNetCore.Mvc;

namespace GymUniverse.Controllers
{
    public class MyCoursesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
