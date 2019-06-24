using System.Collections.Generic;
using PokemonViewer.Domain.Models;

namespace PokemonViewer.Services.ModelPopulator.Interfaces
{
    public interface ISimplifiedPokemonServer
    {
        void SetPokemons(int offset, int limit);

        List<SimplifiedPokemon> GetPokemons();

        int GetTotal();
    }
}