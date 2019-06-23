using System;
using System.Collections.Generic;
using System.Text;
using PokemonViewer.Domain.Models;

namespace PokemonViewer.Services.ModelPopulators.Interfaces
{
    public interface IPokemonServer
    {
        void SetPokemon(int id);

        Pokemon GetPokemon();
    }
}
