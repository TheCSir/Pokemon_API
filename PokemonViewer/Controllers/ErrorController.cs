using Microsoft.AspNetCore.Mvc;

namespace PokemonViewer.Controllers
{
    /// <summary>
    /// General Error controller class
    /// </summary>
    public class ErrorController : Controller
    {
        // Resource not found Error
        [Route("Error/{statusCode}")]
        public IActionResult HttpStatusCodeHandler(int statusCode)
        {
            switch (statusCode)
            {
                case 404:
                    ViewBag.ErrorMessage = "Can't seem to find what you are looking for";
                    break;
            }

            return View("ServerError");
        }

        //Unhandled Exception Error
        [Route("Error")]
        public IActionResult ServerError()
        {
            ViewBag.ErrorMessage = "We have some internal conflicts among pokemon right now ";
            return View("ServerError");
        }
    }
}