using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Media;

namespace Pokedex3.Models
{
    public partial class Pokemon
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Ataque1 { get; set; }
        public string Ataque2 { get; set; }
        public string Ataque3 { get; set; }
        public string Ataque4 { get; set; }
        public int? Region { get; set; }
        public int? Tipo { get; set; }

        public virtual Region RegionNavigation { get; set; }
        public virtual Tipo TipoNavigation { get; set; }

    }
}
