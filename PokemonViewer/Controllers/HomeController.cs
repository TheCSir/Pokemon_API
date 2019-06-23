using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PokemonViewer.Domain.Models;
using PokemonViewer.Repository;

namespace PokemonViewer.Controllers
{
    public class HomeController : Controller
    {
        private IRepository _pokmonList;

        public HomeController(IRepository pokemonList)
        {
            _pokmonList = pokemonList;
        }
        public IActionResult Index(int? id)
        {
            _pokmonList.SetList(id??1);
            var model = _pokmonList.GetAll();
            
            return View(model);
        }

        public IActionResult Details(int id)
        {
            var model = _pokmonList.GetSelected(id);
            return View(model);
        }
    }
}