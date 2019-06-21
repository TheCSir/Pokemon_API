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
            Dictionary<string,string> temp = new Dictionary<string, string>();
            temp.Add("Ability1","descrdtxcfvgf  fycvubu ycvbugvuyv tfvgbuktv gvtubu gvtuv");
            temp.Add("red", "descrdtxcfvgf  fycvubu ycvbugvuyv tfvgbuktv gvtubu gvtuv");
            temp.Add("Ability3", "descrdtxcfvgf  fycvubu ycvbugvuyv tfvgbuktv gvtubu gvtuv");

            Dictionary<string, string> temp2 = new Dictionary<string, string>();
            temp2.Add("Water", "#3281ff");
            temp2.Add("fire", "#ff794c");

            _pokemonList = new List<Pokemon>()
            {

                new Pokemon()
                {
                    Id = 1, Name = "Pikachu", BaseExperience = 10, Height = 10, Order = 10, Weight = 10, StatSpeed = 10, StatHp = 100,StatAttack = 10, StatDefence = 100, StatSpecialAttack = 1000, StatSpecialDefence = 10000,
                    Types = temp2,
                    Abilities = temp,
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
                    Types = temp2,
                    Abilities = temp,
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
