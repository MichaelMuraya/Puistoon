using System;
using System.Collections.Generic;

namespace Puistoon.Models
{
    public partial class Kategoriat
    {
        public Kategoriat()
        {
            Tapahtumat = new HashSet<Tapahtumat>();
        }

        public int KategorianId { get; set; }
        public string KategorianNimi { get; set; }

        public virtual ICollection<Tapahtumat> Tapahtumat { get; set; }
    }
}
