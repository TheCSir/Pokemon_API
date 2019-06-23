using Microsoft.AspNetCore.Mvc;
using PokemonViewer.Services.ModelPopulators.Interfaces;

namespace PokemonViewer.Controllers
{
    public class HomeController : Controller
    {
        private IPokemonServer _pokemon;
        private ISimplifiedPokemonServer _simplifiedPokemon;

        public HomeController(IPokemonServer pokemonServer, ISimplifiedPokemonServer simplifiedPokemonServer)
        {
            _pokemon = pokemonServer;
            _simplifiedPokemon = simplifiedPokemonServer;
        }

        public IActionResult Index(int? id)
        {
            _simplifiedPokemon.SetPokemons(id??1);
            var model = _simplifiedPokemon.GetPokemons();

            return View(model);
        }

        public IActionResult Details(int id)
        {
            _pokemon.SetPokemon(id);
            var model = _pokemon.GetPokemon();
            return View(model);
        }
    }
}