using System;
using System.Collections.Generic;

namespace PokemonViewer.Models
{
    public class Pokemon
    {
        public int Id { get; set; }

        public string Name { get; set; }
        
        public int BaseExperience { get; set; }

        public int Height { get; set; }

        public int Order { get; set; }

        public int Weight { get; set; }

        public int StatSpeed { get; set; }

        public int StatSpecialDefence { get; set; }

        public int StatSpecialAttack { get; set; }

        public int StatDefence { get; set; }

        public int StatAttack { get; set; }

        public int StatHp { get; set; }

        public Dictionary<string,string> Types { get; set; }

        public Dictionary<string,string> Abilities { get; set; }
        public Uri Image { get; set; }
    }
}
