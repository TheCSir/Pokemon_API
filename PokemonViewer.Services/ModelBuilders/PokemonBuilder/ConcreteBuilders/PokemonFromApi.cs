using System;
using System.Collections.Generic;
using System.Linq;
using PokemonViewer.Domain.Models;
using PokemonViewer.ModelHelpers.HelperFunctions;
using PokemonViewer.ModelHelpers.HelperModels;

namespace PokemonViewer.Services.ModelBuilders.PokemonBuilder.ConcreteBuilders
{
    public class PokemonFromApi : IPokemonBuilder
    {
        // current pokemon
        private Pokemon _pokemonModel;

        public void SetPokemon(int id)
        {
            var tempPokemonJson = new PokemonJson();
            var uri = new Uri("https://pokeapi.co/api/v2/pokemon/" + id + "/");

            tempPokemonJson = (PokemonJson) MapToObject.MapJsonToModel(uri, tempPokemonJson);
            _pokemonModel = MapModels(tempPokemonJson);
        }

        public Pokemon GetPokemon()
        {
            return _pokemonModel;
        }

        /// <summary>
        ///     This method will match each attribute form PokemonJson to Pokemon model
        /// </summary>
        /// <param name="jPokemon"> generated PokemonJson model </param>
        /// <returns>
        ///     A SimplifiedPokemon or null of no data form in input model
        /// </returns>
        private Pokemon MapModels(PokemonJson jPokemon)
        {
            // if input is null
            if (jPokemon == null)
                return null;

            var pokemon = new Pokemon
            {
                Id = jPokemon.Id,
                Name = jPokemon.Name,
                Weight = jPokemon.Height,
                Height = jPokemon.Height,
                Order = jPokemon.Order,
                BaseExperience = jPokemon.BaseExperience,
                Image = jPokemon.Sprites.FrontDefault
            };
            // call MapStats method to map stat data
            MapStats(pokemon, jPokemon);
            // call MapTypes method ot map Type data
            pokemon.Types = MapTypes(jPokemon);
            // call MapAbilities method to map Ability data
            pokemon.Abilities = MapAbility(jPokemon);

            return pokemon;
        }

        /// <summary>
        ///     This helper function will get Ability data of helper model jPokemon
        /// </summary>
        /// <param name="jPokemon">generated PokemonJson model</param>
        /// <returns>
        ///     Ability data dictionary
        /// </returns>
        private Dictionary<string, string> MapAbility(PokemonJson jPokemon)
        {
            var tempAbilityDictionary = new Dictionary<string, string>();

            // loop-through Ability model
            foreach (var ability in jPokemon.Abilities)
            {
                // get ability uri for Api endpoint
                var abilityUri = ability.AbilityAbility.Url;

                // get ability data from ability uri my calling GetAbilityTuple helper method
                tempAbilityDictionary.Add(GetAbilityTuple(abilityUri).Item1,
                    GetAbilityTuple(abilityUri).Item2);
            }

            return tempAbilityDictionary;
        }

        /// <summary>
        ///     This helper function get ability data from given api endpoint
        /// </summary>
        /// <param name="abilityUri"> Api endpoint of ability data</param>
        /// <returns>
        ///     tuple with (ability name, ability description)
        /// </returns>
        private Tuple<string, string> GetAbilityTuple(Uri abilityUri)
        {
            var tempAbilityJson = new AbilityJson();
            // get Json helper model of AbilityJson from uri
            tempAbilityJson = (AbilityJson) MapToObject.MapJsonToModel(abilityUri, tempAbilityJson);
            // get values
            var name = tempAbilityJson.Name;
            var desc = tempAbilityJson.EffectEntries.First().ShortEffect;

            return Tuple.Create(name, desc);
        }

        /// <summary>
        ///     This helper method will match get required stat attribute form PokemonJson to SimplifiedPokemon
        /// </summary>
        /// <param name="pokemon">input Pokemon object </param>
        /// <param name="jPokemon">input helper pokemon object </param>
        private void MapStats(Pokemon pokemon, PokemonJson jPokemon)
        {
            foreach (var stat in jPokemon.Stats)
                switch (stat.StatStat.Name)
                {
                    // the switch status conditions are from Pokemon Api documentation 
                    // from url https://pokeapi.co/docs/v2.html#stats
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

        /// <summary>
        ///     This helper method will get type data from helper pokemon model
        ///     then create a dictionary according to it.
        ///     The dictionary contains Type name and color code for the type
        ///     The color codes are from the web reference https://bulbapedia.bulbagarden.net/wiki/Type
        /// </summary>
        /// <param name="jPokemon"> input helper pokemon object </param>
        /// <returns>
        ///     A dictionary with (String:Type name, Hexadecimal:Type color code)
        /// </returns>
        private Dictionary<string, string> MapTypes(PokemonJson jPokemon)
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