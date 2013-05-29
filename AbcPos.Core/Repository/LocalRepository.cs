using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using AbcPos.Core.Interfaces;
using AbcPos.Core.Models;

namespace AbcPos.Core.Repository
{
    public class LocalRepository : Repository, ILocalRepository
    {
        private readonly LocalDataContext fLocalDataContext;

        public LocalRepository() : this("local")
        {
        }

        public LocalRepository(string connectionStringOrName) : base(connectionStringOrName)
        {
            fLocalDataContext = new LocalDataContext(connectionStringOrName);
            DataContext = fLocalDataContext;
        }

        public static LocalRepository GetRepository(string connectionOrName)
        {
            return new LocalRepository(connectionOrName);
        }

        public override void SacuvajRacun(Racun racun)
        {
            fLocalDataContext.Racuni.Add(racun);
            fLocalDataContext.SaveChanges();
        }

        public KonfiguracijaKase VratiKonfiguracijuKase()
        {
            return (fLocalDataContext).KonfiguracijaKase.Single();
        }

        public Sinhronizacija VratiSinhronizaciju(int idRadnje)
        {
            var sinhronizacija = fLocalDataContext.Sinhronizacija.SingleOrDefault(x => x.RadnjaID == idRadnje);
            if (sinhronizacija == null) return null;
            sinhronizacija.BrojArtikala = fLocalDataContext.Artikli.Count();
            sinhronizacija.BrojRacuna = fLocalDataContext.Racuni.Count(x => !x.Sinhronizovan);
            return sinhronizacija;
        }

        public void SacuvajSinhronizaciju(Sinhronizacija sinhronizacija)
        {
            if (sinhronizacija.ID == 0)
            {
                fLocalDataContext.Sinhronizacija.Add(sinhronizacija);
            }
            else
            {
                fLocalDataContext.Entry(sinhronizacija).State = EntityState.Modified;
            }
            Submit();
        }

        public Racun VratiRacun(int idRacuna)
        {
            return fLocalDataContext.Racuni.SingleOrDefault(x => x.ID == idRacuna);
        }

        public IEnumerable<Racun> VratiRacune(DateTime odDana, DateTime doDana, int prodavnicaID)
        {
            var query = from x in fLocalDataContext.Racuni.Include("Stavke")
                                                          .Include("Stavke.Artikal")
                                                          .Include("Stavke.Artikal.JedinicaMere").AsEnumerable()
                        where x.RadnjaID == prodavnicaID &&
                        odDana.Date <= x.Datum && x.Datum.Date <= doDana.Date
                        select x;
            return query.ToArray();
        }

        public IEnumerable<Racun> VratiNesinhronizovaneRacune()
        {
            return fLocalDataContext.Racuni.Include("Stavke").Where(x => !x.Sinhronizovan).ToArray();
        }

        public Racun VratiPosledjiRacun()
        {
            if (!fLocalDataContext.Racuni.Any()) return null;
            var id = fLocalDataContext.Racuni.Max(x => x.ID);
            return fLocalDataContext.Racuni.SingleOrDefault(x => x.ID == id);
        }

        public IEnumerable<Racun> VratiDanasnjeRacune()
        {
            var danas = DateTime.Now.Date;
            var sutra = danas.AddDays(1);
            return fLocalDataContext.Racuni.Where(x => danas <= x.Datum && x.Datum <= sutra).ToArray();
        }

        public void InsertKonfiguracija(KonfiguracijaKase konfiguracija)
        {
            fLocalDataContext.KonfiguracijaKase.Add(konfiguracija);
        }
    }
}