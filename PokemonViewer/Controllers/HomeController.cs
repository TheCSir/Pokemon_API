using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PokemonViewer.Models;

namespace PokemonViewer.Controllers
{
    public class HomeController : Controller
    {
        private IPokemonList _pokemonList;

        public HomeController(IPokemonList pokemonList)
        {
            _pokemonList = pokemonList;
        }
        public IActionResult Index(int? id)
        {
            _pokemonList.SetPokemonPortion(id??1);
            var model = _pokemonList.GetAllPokemon();
            
            return View(model);
        }

        public IActionResult Details(int id)
        {
            var model = _pokemonList.GetPokemon(id);
            return View(model);
        }
    }
}