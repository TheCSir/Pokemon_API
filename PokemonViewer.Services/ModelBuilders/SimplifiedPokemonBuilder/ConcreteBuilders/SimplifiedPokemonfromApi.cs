using System;
using System.Collections.Generic;
using PokemonViewer.Domain.Models;
using PokemonViewer.ModelHelpers.HelperFunctions;
using PokemonViewer.ModelHelpers.HelperModels;

namespace PokemonViewer.Services.ModelBuilders.SimplifiedPokemonBuilder.ConcreteBuilders
{
    /// <summary>
    ///     Concrete Builder for ISimplifiedPokemonBuilder
    ///     This builder populate data from A Pokemon Api
    ///     Docs about endpoints found Here https://pokeapi.co/docs/v2.html
    /// </summary>
    public class SimplifiedPokemonFromApi : ISimplifiedPokemonBuilder
    {
        // list of SimplifiedPokemon
        private List<SimplifiedPokemon> _pokemonListModel = new List<SimplifiedPokemon>();
        // total count of SimplifiedPokemon in total (in Api result)
        private int? _totalCount;

        public List<SimplifiedPokemon> GetPokemons()
        {
            return _pokemonListModel;
        }

        public int GetTotal()
        {
            if (_totalCount.HasValue)
                return (int) _totalCount;
            return 0;
        }


        /// <summary>
        ///     This method populate pokemon list by
        ///     generating series of mock models from json data and mapping them to base model
        /// </summary>
        public void SetPokemons(int offset, int limit)
        {
            var newPokemonList = new PokemonListJson();
            var uriList = new List<Uri>();

            // Uri of current APi end point of pokemon list
            var uri = new Uri("https://pokeapi.co/api/v2/pokemon?offset=" + offset + "&limit=" + limit);

            // Mapping and getting json helper model of PokemonListJson
            newPokemonList = (PokemonListJson) MapToObject.MapJsonToModel(uri, newPokemonList);

            // if PokemonListJson is null stop and return (Api or http services not working)
            if (newPokemonList == null) return;

            // setup total count of pokemon for the model
            _totalCount = newPokemonList.Count;

            // loop-through jsonHelper model and get uri of all pokemon
            foreach (var result in newPokemonList.Results) uriList.Add(result.Url);

            // innit empty SimplifiedPokemon list
            _pokemonListModel = new List<SimplifiedPokemon>();

            // loop-through uri list and generate pokemon models using GeneratePokemon method
            foreach (var tempUri in uriList) _pokemonListModel.Add(GeneratePokemon(tempUri));
        }

        /// <summary>
        ///     This method generate a base model SimplifiedPokemon from a given api endpoint
        /// </summary>
        /// <param name="pokemonUri"> Uri of a pokemon </param>
        /// <returns>
        ///     A SimplifiedPokemon or null of no data form Api
        /// </returns>
        private SimplifiedPokemon GeneratePokemon(Uri pokemonUri)
        {
            var tempPokemonJson = new SimplifiedPokemonJson();

            // Mapping and getting json helper model of SimplifiedPokemonJson
            tempPokemonJson = (SimplifiedPokemonJson) MapToObject.MapJsonToModel(pokemonUri, tempPokemonJson);

            var newPokemon = MapModels(tempPokemonJson);

            return newPokemon;
        }

        /// <summary>
        ///     This method will match each attribute form SimplifiedPokemonJson to SimplifiedPokemon
        /// </summary>
        /// <param name="jPokemon"> generated SimplifiedPokemonJson model </param>
        /// <returns>
        ///     A SimplifiedPokemon or null of no data form in input model
        /// </returns>
        private SimplifiedPokemon MapModels(SimplifiedPokemonJson jPokemon)
        {
            // if input is null
            if (jPokemon == null)
                return null;

            var temPokemon = new SimplifiedPokemon {Id = jPokemon.Id, Name = jPokemon.Name};
            temPokemon.Order = jPokemon.Order;
            temPokemon.Image = jPokemon.Sprites.FrontDefault;

            return temPokemon;
        }
    }
}