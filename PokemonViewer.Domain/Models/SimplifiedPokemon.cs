using System;
using System.Collections.Generic;
using System.Text;

namespace PokemonViewer.Domain.Models
{
    public class SimplifiedPokemon
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Order { get; set; }

        public Uri Image { get; set; }
    }
}
