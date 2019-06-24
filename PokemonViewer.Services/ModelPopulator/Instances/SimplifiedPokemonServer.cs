﻿using System;
using System.Collections.Generic;
using PokemonViewer.Domain.Models;
using PokemonViewer.ModelHelpers.HelperFunctions;
using PokemonViewer.ModelHelpers.HelperModels;
using PokemonViewer.Services.ModelPopulator.Interfaces;

namespace PokemonViewer.Services.ModelPopulator.Instances
{
    public class SimplifiedPokemonServer : ISimplifiedPokemonServer
    {
        private List<SimplifiedPokemon> _pokemonListModel = new List<SimplifiedPokemon>();
        private int? _totalCount;

        public List<SimplifiedPokemon> GetPokemons()
        {
            return _pokemonListModel;
        }

        public void SetPokemons(int offset, int limit)
        {
            var simplifiedPokemonJson = new SimplifiedPokemonJson();
            var newPokemonList = new PokemonListJson();
            var uriList = new List<Uri>();

            var uri = new Uri("https://pokeapi.co/api/v2/pokemon?offset=" + offset + "&limit=" + limit);


            newPokemonList = (PokemonListJson) MapToObject.MapJsonToModel(uri, newPokemonList);

            if (newPokemonList == null) return;
            _totalCount = newPokemonList.Count;

            foreach (var result in newPokemonList.Results) uriList.Add(result.Url);

            _pokemonListModel = new List<SimplifiedPokemon>();

            foreach (var tempUri in uriList) _pokemonListModel.Add(GeneratePokemon(tempUri));
        }

        public int GetTotal()
        {
            if (_totalCount.HasValue)
                return (int) _totalCount;
            return 0;
        }

        public SimplifiedPokemon GeneratePokemon(Uri pokemonUri)
        {
            var tempPokemonJson = new SimplifiedPokemonJson();
            SimplifiedPokemon newPokemon;

            tempPokemonJson = (SimplifiedPokemonJson) MapToObject.MapJsonToModel(pokemonUri, tempPokemonJson);
            newPokemon = MapModels(tempPokemonJson);
            return newPokemon;
        }

        public SimplifiedPokemon MapModels(SimplifiedPokemonJson jPokemon)
        {
            var temPokemon = new SimplifiedPokemon {Id = jPokemon.Id, Name = jPokemon.Name};


            if (temPokemon.Name == null)
                return null;

            temPokemon.Order = jPokemon.Order;
            temPokemon.Image = jPokemon.Sprites.FrontDefault;

            return temPokemon;
        }
    }
}