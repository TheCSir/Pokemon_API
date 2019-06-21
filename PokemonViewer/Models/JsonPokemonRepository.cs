using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace PokemonViewer.Models
{
    public class JsonPokemonRepository : IPokemonList
    {
        private List<Pokemon> _pokemonList;

        public JsonPokemonRepository()
        {
            _pokemonList = new List<Pokemon>()
            {
                new Pokemon()
                {
                    Id = 1, Name = "Pikachu", BaseExperience = 10, Height = 10, Order = 10, Weight = 10, StatSpeed = 10, StatHp = 100,StatAttack = 10, StatDefence = 100, StatSpecialAttack = 1000, StatSpecialDefence = 10000,
                    Types = new List<string>(){"Water","Fire"},
                    Image = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/1.png"
                },
                new Pokemon()
                {

                    Id = 2,
                    Name = "NotPikachu",
                    BaseExperience = 10,
                    Height = 10,
                    Order = 10,
                    Weight = 10,
                    StatSpeed = 10, StatHp = 100,StatAttack = 10, StatDefence = 100, StatSpecialAttack = 1000, StatSpecialDefence = 10000,
                    Types = new List<string>(){"Water","Fire"},
                    Image = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/2.png"
                }
            };
        }

        public IEnumerable<Pokemon> GetAllPokemon()
        {
            return _pokemonList;
        }

        public Pokemon GetPokemon(int id)
        {
            return _pokemonList.FirstOrDefault(p => p.Id == id);
        }
    }
}
