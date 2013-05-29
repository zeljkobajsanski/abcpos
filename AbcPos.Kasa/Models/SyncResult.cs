using System.Collections.Generic;
using AbcPos.Core.Models;

namespace AbcPos.Kasa.Models
{
    public class SyncResult
    {
        public Pdv[] Pdv { get; set; }
        public JedinicaMere[] JediniceMere { get; set; }
        public Radnja Radnja { get; set; }
        public Artikal[] Artikli { get; set; }
        public IList<Racun> Racuni { get; set; }
    }
}