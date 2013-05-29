using System;
using System.Collections.Generic;
using AbcPos.Core.Models;

namespace AbcPos.Core.Interfaces
{
    public interface ILocalRepository : IRepository
    {
        KonfiguracijaKase VratiKonfiguracijuKase();
        Sinhronizacija VratiSinhronizaciju(int idRadnje);
        void SacuvajSinhronizaciju(Sinhronizacija sinhronizacija);
        Racun VratiRacun(int idRacuna);
        IEnumerable<Racun> VratiRacune(DateTime odDana, DateTime doDana, int prodavnicaID);
        IEnumerable<Racun> VratiNesinhronizovaneRacune();
        Racun VratiPosledjiRacun();
        void InsertKonfiguracija(KonfiguracijaKase konfiguracija);
        IEnumerable<Racun> VratiDanasnjeRacune();
    }
}