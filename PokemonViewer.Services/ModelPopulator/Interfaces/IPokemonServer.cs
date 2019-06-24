using PokemonViewer.Domain.Models;

namespace PokemonViewer.Services.ModelPopulator.Interfaces
{
    public interface IPokemonServer
    {
        void SetPokemon(int id);

        Pokemon GetPokemon();
    }
}