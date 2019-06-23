﻿using System;
using System.Collections.Generic;
using System.Text;
using PokemonViewer.Domain.Models;
using PokemonViewer.ModelHelpers.HelperFunctions;
using PokemonViewer.ModelHelpers.HelperModels;
using PokemonViewer.Services.ModelPopulators.Interfaces;

namespace PokemonViewer.Services.ModelPopulator.Instances
{
    public class SimplifiedPokemonServer : ISimplifiedPokemonServer
    {
        private List<SimplifiedPokemon> _pokemonListModel;

        public List<SimplifiedPokemon> GetPokemons()
        {
            return _pokemonListModel;
        }

        public void SetPokemons(int offset)
        {
            var simplifiedPokemonJson = new SimplifiedPokemonJson();
            var newPokemonList = new PokemonListJson();
            List<Uri> uriList = new List<Uri>();

            Uri uri = new Uri("https://pokeapi.co/api/v2/pokemon?offset=" + offset + "&limit=20");


            newPokemonList = (PokemonListJson)MapToObject.MapJsonToModel(uri, newPokemonList);

            foreach (var result in newPokemonList.Results)
            {
                uriList.Add(result.Url);
            }

            _pokemonListModel = new List<SimplifiedPokemon>();

            foreach (var tempUri in uriList)
            {
                _pokemonListModel.Add(GeneratePokemon(tempUri));
            }
        }

        public SimplifiedPokemon GeneratePokemon(Uri pokemonUri)
        {
            var tempPokemonJson = new SimplifiedPokemonJson();
            SimplifiedPokemon newPokemon;

            tempPokemonJson = (SimplifiedPokemonJson)MapToObject.MapJsonToModel(pokemonUri, tempPokemonJson);
            newPokemon = MapModels(tempPokemonJson);
            return newPokemon;
        }

        public SimplifiedPokemon MapModels(SimplifiedPokemonJson jPokemon)
        {
            SimplifiedPokemon temPokemon = new SimplifiedPokemon();

            temPokemon.Id = jPokemon.Id;
            temPokemon.Name = jPokemon.Name;

            if (temPokemon.Name == null)
                return null;

            temPokemon.Order = jPokemon.Order;
            temPokemon.Image = jPokemon.Sprites.FrontDefault;

            return temPokemon;
        }
    }
}
