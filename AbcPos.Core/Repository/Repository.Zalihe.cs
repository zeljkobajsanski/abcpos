using System.Collections.Generic;
using System.Data;
using System.Linq;
using AbcPos.Core.Models;

namespace AbcPos.Core.Repository
{
    public partial class Repository
    {
        public Zaliha[] Zalihe(int idRadnje)
        {
            return DataContext.Zalihe.Where(x => x.RadnjaID == idRadnje).ToArray();
        }

        public Zaliha[] VratiZaliheArtikala(int idRadnje, int? idZalihe, int[] idZaliha)
        {
            var query = DataContext.Zalihe.Include("Artikal").Where(x => x.RadnjaID == idRadnje);
            if (idZalihe.HasValue)
            {
                query = query.Where(x => x.ID == idZalihe.Value);
            }
            if (idZaliha != null)
            {
                query = query.Where(x => idZaliha.Contains(x.ID));
            }
            return query.ToArray();
        }

        public Zaliha VratiZalihuArtikla(int idArtikla, int idRadnje)
        {
            return DataContext.Zalihe.Include("Artikal").Single(x => x.ArtikalID == idArtikla && x.RadnjaID == idRadnje);
        }

        public Zaliha VratiZalihuArtikla(string oznakaIliBarKod, int idRadnje)
        {
            var zaliha = DataContext.Zalihe.Include("Artikal").SingleOrDefault(x => (x.Artikal.Sifra == oznakaIliBarKod || x.Artikal.Barkod == oznakaIliBarKod) && x.RadnjaID == idRadnje);
            return zaliha;
        }

        public IEnumerable<Zaliha> VratiZalihuArtikla(int idArtikla)
        {
            return DataContext.Zalihe.Where(x => x.ArtikalID == idArtikla).ToArray();
        }

        public void SacuvajZalihu(Zaliha zaliha)
        {
            if (zaliha.ID == 0)
            {
                DataContext.Zalihe.Add(zaliha);
            }
            else
            {
                DataContext.Entry(zaliha).State = EntityState.Modified;
            }
            Submit();
        }

        public Zaliha VratiZalihu(int id)
        {
            return DataContext.Zalihe.Single(x => x.ID == id);
        }
    }
}