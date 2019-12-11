using System;
using System.Collections.Generic;

namespace Puistoon.Models
{
    public partial class Tapahtumat
    {
        public int TapahtumanId { get; set; }
        public string Nimi { get; set; }
        public DateTime Pvm { get; set; }
        public TimeSpan? Alkaa { get; set; }
        public TimeSpan? Loppuu { get; set; }
        public string Kuvaus { get; set; }
        public int? LikeButton { get; set; }
        public int PuistonId { get; set; }
        public int KategorianId { get; set; }
        public int KäyttäjänId { get; set; }

        public virtual Kategoriat Kategorian { get; set; }
        public virtual Käyttäjät Käyttäjän { get; set; }
        public virtual Puistot Puiston { get; set; }
    }
}
