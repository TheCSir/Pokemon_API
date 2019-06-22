using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using PokemonViewer.ModelHelpers.HelperModels;
using PokemonViewer.ModelHelpers.HelperFunctions;

namespace PokemonViewer.Models
{
    public class JsonPokemonRepository : IPokemonList
    {
        private List<Pokemon> _pokemonList;

        public JsonPokemonRepository()
        {
            _pokemonList = new List<Pokemon>();
            _pokemonList.Add(GenataPokemonAsync().Result);
        }

        public IEnumerable<Pokemon> GetAllPokemon()
        {
            return _pokemonList;
        }

        public Pokemon GetPokemon(int id)
        {
            return _pokemonList.FirstOrDefault(p => p.Id == id);
        }

        public async Task<Pokemon> GenataPokemonAsync()
        {
            PokemonJson tempPokemonJson = new PokemonJson();
            Pokemon newPokemon = new Pokemon();

            Uri tempUri = new Uri("https://pokeapi.co/api/v2/pokemon/1/");
            tempPokemonJson = (PokemonJson) await MapToObject.MapJsonToModel(tempUri);
            System.Diagnostics.Debug.WriteLine("--------------------------------------------------------");
            System.Diagnostics.Debug.WriteLine(tempPokemonJson.Types);
            mapData(newPokemon, tempPokemonJson);
            System.Diagnostics.Debug.WriteLine("--------------------------------------------------------");
            System.Diagnostics.Debug.WriteLine(newPokemon.Types);
            return newPokemon;
        }

        public Boolean mapData(Pokemon pokemon, PokemonJson jPokemon)
        {
            pokemon.Id = jPokemon.Id;
            pokemon.Name = jPokemon.Name;
            pokemon.Weight = jPokemon.Height;
            pokemon.Height = jPokemon.Height;
            pokemon.Order = jPokemon.Order;
            pokemon.BaseExperience = jPokemon.BaseExperience;

            foreach (var stat in jPokemon.Stats)
            {
                switch (stat.StatStat.Name)
                {
                    case "speed":
                        pokemon.StatSpeed = stat.BaseStat;
                        break;
                    case "special-defense":
                        pokemon.StatSpecialDefence = stat.BaseStat;
                        break;
                    case "special-attack":
                        pokemon.StatSpecialAttack = stat.BaseStat;
                        break;
                    case "defense":
                        pokemon.StatDefence = stat.BaseStat;
                        break;
                    case "attack":
                        pokemon.StatAttack = stat.BaseStat;
                        break;
                    case "hp":
                        pokemon.StatHp = stat.BaseStat;
                        break;
                }
            }

            pokemon.Image = jPokemon.Sprites.FrontDefault;

            Dictionary<string, string> tempTypes = new Dictionary<string, string>();

            foreach (var types in jPokemon.Types)
            {
                switch (types.Type.Name)
                {
                    case "normal":
                        tempTypes.Add("Normal", "#A8A878");
                        break;
                    case "fire":
                        tempTypes.Add("Fire", "#f08030");
                        break;
                    case "fighting":
                        tempTypes.Add("Fighting", "#c03028");
                        break;
                    case "water":
                        tempTypes.Add("Water", "#6890f0");
                        break;
                    case "flying":
                        tempTypes.Add("Flying", "#a890f0");
                        break;
                    case "grass":
                        tempTypes.Add("Grass", "#78c850");
                        break;
                    case "poison":
                        tempTypes.Add("Poison", "#a040a0");
                        break;
                    case "electric":
                        tempTypes.Add("Electric", "#f8d030");
                        break;
                    case "ground":
                        tempTypes.Add("Ground", "#e0c068");
                        break;
                    case "psychic":
                        tempTypes.Add("Psychic", "#f85888");
                        break;
                    case "rock":
                        tempTypes.Add("Rock", "#b8a038");
                        break;
                    case "ice":
                        tempTypes.Add("Ice", "#98d8d8");
                        break;
                    case "bug":
                        tempTypes.Add("Bug", "#a8b820");
                        break;
                    case "dragon":
                        tempTypes.Add("Dragon", "#7038f8");
                        break;
                    case "ghost":
                        tempTypes.Add("Ghost", "#705898");
                        break;
                    case "dark":
                        tempTypes.Add("Dark", "#705848");
                        break;
                    case "steel":
                        tempTypes.Add("Steel", "#b8b8d0");
                        break;
                    case "fairy":
                        tempTypes.Add("Fairy", "#ee99ac");
                        break;
                    default:
                        tempTypes.Add("Unspecified", "#68a090");
                        break;
                }
            }

            pokemon.Types = tempTypes;

            Dictionary<string,string> tempAbilityDictionary = new Dictionary<string, string>();
            //foreach (var Ability in jPokemon.Abilities)
            //{
            //    Uri ablityUri = Ability.AbilityAbility.Url;
            //    tempAbilityDictionary.Add(GetABilityTuple(ablityUri).Result.Item1, GetABilityTuple(ablityUri).Result.Item2);
            //}

            pokemon.Abilities=tempAbilityDictionary;
            return true;
        }

        //public async Task<Tuple<string, string>> GetABilityTuple(Uri abliltyUri)
        //{
            
        //    AbilityJson tempAbilityJson = (AbilityJson)await MapToObject.MapJsonToModel(abliltyUri);
        //    string name = tempAbilityJson.Name;
        //    String desc = tempAbilityJson.EffectEntries.First().ShortEffect;

        //    return Tuple.Create(name, desc);

        //}
    }
}
