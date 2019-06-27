using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using PokemonViewer.Services.ModelBuilders.PokemonBuilder;
using PokemonViewer.Services.ModelBuilders.SimplifiedPokemonBuilder;

namespace PokemonViewer.Controllers
{
    public class HomeController : Controller
    {
        // Default size of in page result count
        private const int DefaultSize = 10;

        private readonly IConfiguration _configuration;

        // Single pokemon Model services builder
        private readonly IPokemonBuilder _pokemon;

        // Simplified pokemon model list services builder
        private readonly ISimplifiedPokemonBuilder _simplifiedPokemon;

        public HomeController(IPokemonBuilder pokemonServer, ISimplifiedPokemonBuilder simplifiedPokemonServer,
            IConfiguration configuration)
        {
            // register injected objects to home controller
            _configuration = configuration;
            _pokemon = pokemonServer;
            _simplifiedPokemon = simplifiedPokemonServer;
        }

        public IActionResult Index(int? id)
        {
            // try and get page size from configuration
            var isResultFound = int.TryParse(_configuration["Pagination:ResultSize"], out var currentResultSize);

            // validate and set page size
            currentResultSize = isResultFound && currentResultSize > 0 ? currentResultSize : DefaultSize;

            // set offset by input id
            var currentIndex = id ?? 0;
            var currentOffset = currentIndex * currentResultSize;

            // set pokemon list with input
            _simplifiedPokemon.SetPokemons(currentOffset, currentResultSize);

            // validate results
            // 1. check if list is not empty
            // 2. check if user input is in valid range
            if (_simplifiedPokemon.GetTotal() != 0 && currentIndex >= 0 &&
                currentIndex <= CalcMaxPage(_simplifiedPokemon.GetTotal()))
            {
                // set model for view
                var model = _simplifiedPokemon.GetPokemons();

                // set relevant view data 
                ViewBag.ActivePage = currentIndex;
                ViewBag.IsNext = CalcIsNext();
                ViewBag.IsPrevious = currentIndex > 0;

                return View(model);
            }

            // if model failed to populate ( error with Api services/ connection)
            if (_simplifiedPokemon.GetTotal() == 0)
                return View("Error");

            // if user validations fail 
            ViewBag.ErrorMessage = "Can't seem to find pokemons you are looking for";
            return View("ServerError");


            // helper function to calculate next index for pagination
            bool CalcIsNext()
            {
                return currentIndex != CalcMaxPage(_simplifiedPokemon.GetTotal());
            }

            // helper function to calculate max pages possible
            int CalcMaxPage(int total)
            {
                var maxIndex = total / currentResultSize;
                return total % maxIndex != 0 ? maxIndex : maxIndex - 1;
            }
        }

        public IActionResult Details(int id)
        {
            // set pokemon model with input id
            _pokemon.SetPokemon(id);

            // if pokemon id is valid and model is returned
            if (_pokemon.GetPokemon().Name != null)
            {
                var model = _pokemon.GetPokemon();
                return View(model);
            }

            ViewBag.ErrorMessage = "Can't seem to find the pokemon you are looking for";
            return View("ServerError");
        }
    }
}