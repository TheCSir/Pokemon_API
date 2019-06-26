using PokemonViewer.Domain.Models;

namespace PokemonViewer.Services.ModelBuilders.PokemonBuilder
{
    /// <summary>
    ///     Builder interface for Pokemon
    /// </summary>
    public interface IPokemonBuilder
    {
        /// <summary>
        /// Setup pokemon according to parameters
        /// </summary>
        /// <param name="id">id of the pokemon </param>
        void SetPokemon(int id);

        Pokemon GetPokemon();
    }
}