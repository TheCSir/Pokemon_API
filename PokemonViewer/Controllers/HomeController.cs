using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using PokemonViewer.Services.ModelPopulator.Instances;
using PokemonViewer.Services.ModelPopulators.Interfaces;

namespace PokemonViewer.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPokemonServer _pokemon;
        private readonly ISimplifiedPokemonServer _simplifiedPokemon;
        private readonly IConfiguration _configuration;
        private const int DefaultSize = 10;

        public HomeController(IPokemonServer pokemonServer, ISimplifiedPokemonServer simplifiedPokemonServer, IConfiguration configuration)
        {
            _configuration = configuration;
            _pokemon = pokemonServer;
            _simplifiedPokemon = simplifiedPokemonServer;
        }

        public IActionResult Index(int? id)
        {
            var isResultFound = int.TryParse(_configuration["Pagination:ResultSize"], out var currentResultSize) &&
                                currentResultSize > 0;

            currentResultSize = isResultFound ? currentResultSize : DefaultSize;
            var currentIndex = id ?? 0;
            var currentOffset = currentIndex * currentResultSize;

            _simplifiedPokemon.SetPokemons(currentOffset, currentResultSize);
            
            if (_simplifiedPokemon.GetTotal() != 0 && currentIndex >= 0 && currentIndex <= CalcMaxPage(_simplifiedPokemon.GetTotal()))
            {
                var model = _simplifiedPokemon.GetPokemons();
                ViewBag.ActivePage = currentIndex;
                ViewBag.IsNext = CalcIsNext();
                ViewBag.IsPrevious = currentIndex > 0;
                return View(model);
            }
            else if (_simplifiedPokemon.GetTotal() == 0)
            {
                return View("Error");
            }
            else
            {
                ViewBag.ErrorMessage = "Can't seem to find pokemons you are looking for";
                return View("ServerError");
            }

            bool CalcIsNext()
            {
                return currentIndex != CalcMaxPage(_simplifiedPokemon.GetTotal());
            }
            int CalcMaxPage(int total)
            {
                int maxIndex = total / currentResultSize;

                return total % maxIndex != 0 ? maxIndex : maxIndex - 1;
            }
        }

        public IActionResult Details(int id)
        {
            _pokemon.SetPokemon(id);
            if (_pokemon.GetPokemon() != null)
            {
                var model = _pokemon.GetPokemon();
                return View(model);
            }
            else
            {
                ViewBag.ErrorMessage = "Can't seem to find the pokemon you are looking for";
                return View("ServerError");
            }
        }
    }
}