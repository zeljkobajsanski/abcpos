using System.Collections.Generic;
using AbcPos.Core.Models;

namespace AbcPos.Web.ViewModels
{
    public class ArtikliViewModel
    {
        public ArtikliViewModel()
        {
            PrototipArtikla = new Artikal();
        }

        public IEnumerable<Pdv> Pdv { get; set; }
        public IEnumerable<JedinicaMere> JediniceMere { get; set; }
        public IEnumerable<Artikal> Artikli { get; set; }
        public string Greska { get; set; }
        public Artikal PrototipArtikla { get; set; }
    }
}