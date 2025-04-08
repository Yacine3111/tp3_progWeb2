using Microsoft.AspNetCore.Mvc;

namespace TP3.Controllers
{
    public class ErreurController : Controller
    {
        [Route("Error/{statusCode}")]
        public IActionResult CustomError(int statusCode)
        {
            switch (statusCode)
            {
                case 404:
                    return View("NotFound");
                default:
                    return View("UnknownError");
            }
        }
    }
}