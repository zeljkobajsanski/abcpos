using System.Collections.Generic;
using AbcPos.Core.Models;
using System.Linq;

namespace AbcPos.Web.SampleData
{
    public static class AkordArtikli
    {
        public static IEnumerable<Artikal> UcitajArtikle(int brojArtikala)
        {
            using (var ctx = new AkordDataContext())
            {
                var query = from a in ctx.RM_Artiklis
                            let barKod = a.RM_EanKodovis.FirstOrDefault()
                            where a.IdArtikla > 0 && a.NazivArtikla != null && a.MaticniBroj != "0" 
                            select new Artikal
                                       {
                                           Sifra = a.MaticniBroj,
                                           Naziv = a.NazivArtikla,
                                           Barkod = barKod != null ? barKod.EanKod : (string) null,
                                           PdvID = 1,
                                           JedinicaMereID = 1,
                                       };

                var artikli = query.Take(brojArtikala).ToArray();
                var zalihe = ctx.RM_Zalihes.Where(x => x.Zaliha > 0).Take(brojArtikala).ToArray();
                for (int i = 0; i < artikli.Length; i++)
                {
                    var rmZalihe = zalihe.Length < i ? new RM_Zalihe() : zalihe[i];
                    for (int j = 1; j <= 2; j++)
                    {
                        artikli[i].Zalihe.Add(new Zaliha
                        {
                            TrenutnaZaliha = rmZalihe.Zaliha,
                            UkupnaZaliha = rmZalihe.Zaliha,
                            NabavnaCena = rmZalihe.Zaliha > 0 ? rmZalihe.NabavnaVrednost / rmZalihe.Zaliha : 0,
                            ProdajnaCena = rmZalihe.Zaliha > 0 ? rmZalihe.ProdajnaVrednost / rmZalihe.Zaliha : 0,
                            RadnjaID = j
                        });
                    }
                }
                return artikli;
            }
        } 
    }
}