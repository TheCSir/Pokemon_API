using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PokemonViewer.Models
{
    public interface IPokemonList
    {
        Pokemon GetPokemon(int id);

        IEnumerable<Pokemon> GetAllPokemon();
    }
}
