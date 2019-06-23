using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PokemonViewer.Domain.Models;
using PokemonViewer.ModelHelpers.HelperFunctions;
using PokemonViewer.ModelHelpers.HelperModels;
using PokemonViewer.Services.ModelPopulators.Interfaces;

namespace PokemonViewer.Services.ModelPopulator.Instances
{
    public class PokemonServer: IPokemonServer
    {
        private Pokemon _pokemonModel;

        public void SetPokemon(int id)
        {
            var tempPokemonJson = new PokemonJson();
            Uri uri = new Uri("https://pokeapi.co/api/v2/pokemon/"+id+"/");

            tempPokemonJson = (PokemonJson)MapToObject.MapJsonToModel(uri, tempPokemonJson);
            _pokemonModel = MapModels(tempPokemonJson);
            //System.Diagnostics.Debug.WriteLine("===================NEW==========================");
            //System.Diagnostics.Debug.WriteLine(_pokemonModel.Image);
        }

        public Pokemon GetPokemon()
        {
            return _pokemonModel;
        }

        public Pokemon MapModels(PokemonJson jPokemon)
        {
            Pokemon pokemon = new Pokemon();

            pokemon.Id = jPokemon.Id;
            pokemon.Name = jPokemon.Name;
            
            if (pokemon.Name == null)
                return null;

            pokemon.Weight = jPokemon.Height;
            pokemon.Height = jPokemon.Height;
            pokemon.Order = jPokemon.Order;
            pokemon.BaseExperience = jPokemon.BaseExperience;
            MapStats(pokemon, jPokemon);
            pokemon.Image = jPokemon.Sprites.FrontDefault;
            pokemon.Types = MapTypes(jPokemon);
            pokemon.Abilities = MapAbility(jPokemon);


            return pokemon;
        }

        public Dictionary<string, string> MapAbility(PokemonJson jPokemon)
        {
            var tempAbilityDictionary = new Dictionary<string, string>();
            foreach (var ability in jPokemon.Abilities)
            {
                var abilityUri = ability.AbilityAbility.Url;
                tempAbilityDictionary.Add(GetAbilityTuple(abilityUri).Item1,
                    GetAbilityTuple(abilityUri).Item2);
            }

            return tempAbilityDictionary;
        }

        public Tuple<string, string> GetAbilityTuple(Uri abilityUri)
        {
            var tempAbilityJson = new AbilityJson();
            tempAbilityJson = (AbilityJson)MapToObject.MapJsonToModel(abilityUri, tempAbilityJson);
            var name = tempAbilityJson.Name;
            var desc = tempAbilityJson.EffectEntries.First().ShortEffect;

            return Tuple.Create(name, desc);
        }

        public void MapStats(Pokemon pokemon, PokemonJson jPokemon)
        {
            foreach (var stat in jPokemon.Stats)
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

        public Dictionary<string, string> MapTypes(PokemonJson jPokemon)
        {
            var tempTypes = new Dictionary<string, string>();

            foreach (var types in jPokemon.Types)
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

            return tempTypes;
        }
    }
}
