using System;
using System.Collections.Generic;
using System.Text;
using PokemonViewer.Domain.Models;

namespace PokemonViewer.Repository
{
    public interface IRepository
    {
        List<Pokemon> GetAll();

        Pokemon GetSelected(int id);

        void SetList(int size);

    }
}
