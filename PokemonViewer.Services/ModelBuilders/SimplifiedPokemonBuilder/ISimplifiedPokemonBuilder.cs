using System.Collections.Generic;
using PokemonViewer.Domain.Models;

namespace PokemonViewer.Services.ModelBuilders.SimplifiedPokemonBuilder
{
    /// <summary>
    ///     Builder interface for Simplified Pokemon
    /// </summary>
    public interface ISimplifiedPokemonBuilder
    {
        /// <summary>
        ///     Setup pokemon list according to parameters
        /// </summary>
        /// <param name="offset"> Starting id </param>
        /// <param name="limit"> Number of pokemon in list </param>
        void SetPokemons(int offset, int limit);


        /// <summary>
        ///     Get pokemon list of current implementation
        /// </summary>
        /// <returns>
        ///     list of pokemon / null if no data
        /// </returns>
        List<SimplifiedPokemon> GetPokemons();


        /// <summary>
        ///     Get Total number of pokemon in current implementation
        /// </summary>
        /// <returns>
        ///     int total / int 0 if no data
        /// </returns>
        int GetTotal();
    }
}