using System;
using System.Collections.Generic;
using System.Text;
using PokemonViewer.Domain.Models;

namespace PokemonViewer.Services.ModelPopulators.Interfaces
{
    public interface ISimplifiedPokemonServer
    {
        void SetPokemons(int offset);

        List<SimplifiedPokemon> GetPokemons();
    }
}
