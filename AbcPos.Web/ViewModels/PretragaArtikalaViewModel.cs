using System.Collections.Generic;
using AbcPos.Core.Models;
using AbcPos.Core.Repository;

namespace AbcPos.Web.ViewModels
{
    public class PretragaArtikalaViewModel
    {
        public IEnumerable<Artikal> Artikli { get; set; } 

        public void Pretrazi(string sifraIliBarKd, string deoNaziva)
        {
            Artikli = new Repository().PretraziArtikle(sifraIliBarKd, deoNaziva);
        }
    }
}