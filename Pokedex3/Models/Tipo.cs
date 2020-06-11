using System;
using System.Collections.Generic;

namespace Pokedex3.Models
{
    public partial class Tipo
    {
        public Tipo()
        {
            Pokemon = new HashSet<Pokemon>();
        }

        public int Id { get; set; }
        public string Tipo1 { get; set; }

        public virtual ICollection<Pokemon> Pokemon { get; set; }
    }
}
