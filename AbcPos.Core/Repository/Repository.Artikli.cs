using System.Collections.Generic;
using System.Data;
using System.Linq;
using AbcPos.Core.Models;

namespace AbcPos.Core.Repository
{
  public partial class Repository
  {
      public Artikal[] Artikli()
      {
          return DataContext.Artikli.ToArray();
      }

      public Artikal[] VraiArtikleZaSinhronizaciju()
      {
          return DataContext.Artikli.ToArray();
      }

      public int SledeciIdArtikla()
      {
          return DataContext.Artikli.Any() ?  DataContext.Artikli.Max(i => i.ID) + 1 : 1;
      }

      public void Insert(Artikal artikal)
      {
          DataContext.Artikli.Add(artikal);
      }

      public void SacuvajArtikal(Artikal artikal, params int[] radnje)
      {
          if (artikal.ID == 0)
          {
              DataContext.Artikli.Add(artikal);
              foreach (var radnja in radnje)
              {
                  var zaliha = new Zaliha { Artikal = artikal, RadnjaID = radnja };
                  DataContext.Zalihe.Add(zaliha);
              }
          }
          else
          {
              DataContext.Entry(artikal).State = EntityState.Modified;
          }
      }

      public Artikal VratiArtikalPoSifriIliBarKodu(string sifraIliBarKod)
      {
          return DataContext.Artikli.SingleOrDefault(x => x.Sifra == sifraIliBarKod || x.Barkod == sifraIliBarKod);
      }

      public IEnumerable<Artikal> PretraziArtikle(string sifraIliBarKd, string deoNaziva)
      {
          var artikli = DataContext.Artikli.Include("JedinicaMere").AsQueryable();
          if (!string.IsNullOrEmpty(sifraIliBarKd))
          {
              artikli = artikli.Where(x => x.Sifra == sifraIliBarKd || x.Barkod == sifraIliBarKd);
          } 
          if (!string.IsNullOrEmpty(deoNaziva))
          {
              artikli = artikli.Where(x => x.Naziv.Contains(deoNaziva));
          }
          return artikli.ToArray();
      }

      public bool PostojiSifraArtikla(string sifra)
      {
          return DataContext.Artikli.Any(x => x.Sifra == sifra);
      }

      public bool PostojiNazivArtikla(string naziv)
      {
          return DataContext.Artikli.Any(x => x.Naziv == naziv);
      }

      public int UkupanBrojArtikala()
      {
          return DataContext.Artikli.Count();
      }

      public IEnumerable<Artikal> PretraziArtikleIZalihu(string sifra, string naziv)
      {
          var artikli = DataContext.Artikli.Include("JedinicaMere").Include("Zalihe").AsQueryable();
          if (!string.IsNullOrEmpty(sifra))
          {
              artikli = artikli.Where(x => x.Sifra == sifra);
          }
          if (!string.IsNullOrEmpty(naziv))
          {
              artikli = artikli.Where(x => x.Naziv.Contains(naziv));
          }
          return artikli.ToArray();
      }

      public Artikal VratiArtikalIZalihu(string sifraIliBarKod)
      {
          return DataContext.Artikli.Include("JedinicaMere").Include("Zalihe").SingleOrDefault(x => x.Sifra == sifraIliBarKod || x.Barkod == sifraIliBarKod);
      }
  }
}