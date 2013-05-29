using System;
using System.Collections.Generic;
using System.Data;
using AbcPos.Core.Kriterijumi;
using AbcPos.Core.Models;
using System.Linq;

namespace AbcPos.Core.Repository
{
    public partial class Repository
    {
        public int SacuvajZaglavljeDokumenta(Dokument dokument)
        {
            if (dokument.ID == 0)
            {
                DataContext.Dokumenti.Add(dokument);
            }
            else
            {
                DataContext.Entry(dokument).State = EntityState.Modified;
            }
            DataContext.SaveChanges();
            return dokument.ID;
        }

        public Dokument VratiDokument(int id)
        {
            return DataContext.Dokumenti.Single(x => x.ID == id);
        }

        public void IzmeniStavku(StavkaDokumenta stavka)
        {
            DataContext.Entry(stavka).State = EntityState.Modified;
        }

        public Dokument VratiDokumentSaStavkama(int id)
        {
            return DataContext.Dokumenti.Include("Stavke").Include("Stavke.Artikal").Single(x => x.ID == id);
        }

        public StavkaDokumenta VratiStavkuDokumenta(int id)
        {
            return DataContext.StavkeDokumenta.Include("Artikal").Single(x => x.ID == id);
        }

        public void ObrisiStavku(int id)
        {
            DataContext.Entry(new StavkaDokumenta{ID = id}).State = EntityState.Deleted;
            Submit();
        }

        public IEnumerable<Dokument> VratiDokumente(KriterijumPretrageDokumenata kriterijumi)
        {
            var query = from d in DataContext.Dokumenti.Include("Komitent").Include("Radnja").Include("Stavke").AsEnumerable()
                        where d.TipDokumenta == (int)kriterijumi.TipDokumenta &&
                              kriterijumi.OdDatuma.Date <= d.Datum.Date && d.Datum.Date <= kriterijumi.DoDatuma.Date &&
                              (!kriterijumi.IdRadnje.HasValue || kriterijumi.IdRadnje == d.RadnjaID)
                        select d;

            return query.ToArray();
        }

        public IEnumerable<Racun> VratiRacune(KriterijumPretrageDokumenata kriterijumi)
        {
            var query = from d in DataContext.Racuni.Include("Radnja").AsEnumerable()
                        where d.TipDokumenta == (int)kriterijumi.TipDokumenta &&
                              kriterijumi.OdDatuma.Date <= d.Datum.Date && d.Datum.Date <= kriterijumi.DoDatuma.Date &&
                              (!kriterijumi.IdRadnje.HasValue || kriterijumi.IdRadnje == d.RadnjaID)
                        select d;

            return query.OrderByDescending(x => x.Datum).ToArray();
        }

        public Dokument VratiDokumentSaZalihama(int id)
        {
            return DataContext.Dokumenti.Include("Stavke.Artikal.Zalihe").Single(x => x.ID == id);
        }

        public virtual void SacuvajRacun(Racun racun)
        {
            DataContext.Racuni.Add(racun);
            DataContext.SaveChanges();
        }

        public void InsertStavkaDokumenta(StavkaDokumenta stavka)
        {
            DataContext.StavkeDokumenta.Add(stavka);
        }

        public Racun[] Racuni(int idRadnje)
        {
            return DataContext.Racuni.Include("Stavke").Where(x => x.RadnjaID == idRadnje).ToArray();
        }

        public bool PostojiRacun(Guid uid)
        {
            return DataContext.Racuni.Any(x => x.UID == uid);
        }

        public IEnumerable<StavkaDokumenta> VratiStavkeDokumenta(int idDokumenta)
        {
            return DataContext.StavkeDokumenta.Include("Artikal").Where(x => x.DokumentID == idDokumenta).ToArray();
        }
    }
}