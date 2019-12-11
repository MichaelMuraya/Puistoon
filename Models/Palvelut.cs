using System;
using System.Collections.Generic;

namespace Puistoon.Models
{
    public partial class Palvelut
    {
        public int PalvelutId { get; set; }
        public int TyyppiId { get; set; }
        public double Lat { get; set; }
        public double Long { get; set; }
        public string Kuvaus { get; set; }
        public string Lisätietoja { get; set; }
    }
}
