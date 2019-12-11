using System;
using System.Collections.Generic;

namespace Puistoon.Models
{
    public partial class Puistot
    {
        public Puistot()
        {
            Tapahtumat = new HashSet<Tapahtumat>();
        }

        public int PuistonId { get; set; }
        public string PuistonNimi { get; set; }
        public double Lat { get; set; }
        public double? Long { get; set; }
        public string PuistonKuvaus { get; set; }
        public string PuistonUrl { get; set; }
        public int? ZoomLevel { get; set; }

        public virtual ICollection<Tapahtumat> Tapahtumat { get; set; }
    }
}
