using Microsoft.AspNetCore.Mvc;

namespace GymUniverse.Controllers
{
    public class ErrorController : Controller
    {
        [Route("Error/Error")]
        public IActionResult Error()
        {
            return View("Error500");
        }

        [Route("Error/HandleStatusCode/{statusCode}")]
        public IActionResult HandleStatusCode(int statusCode)
        {
            if (statusCode == 404)
            {
                return View("Error404");
            }
            return View("Error500");
        }
    }
}
