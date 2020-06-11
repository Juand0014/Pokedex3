using System;
using System.Collections.Generic;

namespace Pokedex3.Models
{
    public partial class Region
    {
        public Region()
        {
            Pokemon = new HashSet<Pokemon>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }

        public virtual ICollection<Pokemon> Pokemon { get; set; }
    }
}
