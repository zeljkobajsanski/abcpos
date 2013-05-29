using System.Data.Entity;
using AbcPos.Core.Models;
using AbcPos.Core.Repository;

namespace AbcPos.Core.Utils
{
    public class CreateDatabase : DbInit
    {
        public CreateDatabase()
        {
            
        }

        protected override void Seed(DataContext context)
        {
            base.Seed(context);
            // PDV
            context.Pdv.Add(new Pdv() {Naziv = "20%", Stopa = 20, Default = true});
            context.Pdv.Add(new Pdv() {Naziv = "8%", Stopa = 8, Default = false});
            context.SaveChanges();
            
            // JM
            var kom = new JedinicaMere {Oznaka = "kom", Default = true};
            var kg = new JedinicaMere {Oznaka = "kg"};
            context.JediniceMere.Add(kom);
            context.JediniceMere.Add(kg);

            // Radnje
            var r1 = new Radnja {Naziv = "Prodavnica 1"};
            var r2 = new Radnja {Naziv = "Prodavnica 2"};
            context.Radnje.Add(r1);
            context.Radnje.Add(r2);
            context.SaveChanges();

            // Artikli i zalihe
            //var artikal1 = new Artikal() {Naziv = "Hleb", PdvID = 2, Cena = 40, Sifra = "1", JedinicaMere = kom};
            //var artikal2 = new Artikal() { Naziv = "Mleko", PdvID = 2, Cena = 96, Sifra = "2", JedinicaMere = kom };
            //var zaliha11 = new Zaliha {Artikal = artikal1, RadnjaID = 1, UkupnaZaliha = 10, TrenutnaZaliha = 6};
            //var zaliha12 = new Zaliha {Artikal = artikal1, RadnjaID = 2, UkupnaZaliha = 50, TrenutnaZaliha = 24};
            //var zaliha21 = new Zaliha { Artikal = artikal2, RadnjaID = 1, UkupnaZaliha = 14, TrenutnaZaliha = 14 };
            //var zaliha22 = new Zaliha { Artikal = artikal2, RadnjaID = 2, UkupnaZaliha = 80, TrenutnaZaliha = 66 };
            //context.Artikli.Add(artikal1);
            //context.Artikli.Add(artikal2);
            //context.Zalihe.Add(zaliha11);
            //context.Zalihe.Add(zaliha12);
            //context.Zalihe.Add(zaliha21);
            //context.Zalihe.Add(zaliha22);
            //context.SaveChanges();

            // Dobavljaci
            context.Komitenti.Add(new Dobavljac {Naziv = "Univerexport", Sifra = "2001"});
            context.Komitenti.Add(new Dobavljac {Naziv = "Tempo", Sifra = "2002"});
            context.Komitenti.Add(new Dobavljac {Naziv = "Rodić", Sifra = "2003"});
            context.Komitenti.Add(new Dobavljac {Naziv = "Merkator", Sifra = "2004"});
            context.SaveChanges();
        }
    }
}