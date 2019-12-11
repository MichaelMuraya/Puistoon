using System;
using System.Collections.Generic;

namespace Puistoon.Models
{
    public partial class Käyttäjät
    {
        public Käyttäjät()
        {
            Tapahtumat = new HashSet<Tapahtumat>();
        }

        public int KäyttäjänId { get; set; }
        public int KäyttäjänRooli { get; set; }
        public string KäyttäjänTunnus { get; set; }
        public string Sähköposti { get; set; }
        public string Koodi { get; set; }

        public virtual ICollection<Tapahtumat> Tapahtumat { get; set; }
    }
}
