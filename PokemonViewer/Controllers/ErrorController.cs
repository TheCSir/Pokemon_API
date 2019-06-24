using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace PokemonViewer.Controllers
{
    public class ErrorController : Controller
    {
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

        [Route("Error")]
        public IActionResult ServerError()
        {
            ViewBag.ErrorMessage = "We have some internal conflicts among pokemon right now ";
            return View("ServerError");
        }
    }
}