using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading;
using AbcPos.Core.Models;
using AbcPos.Core.Repository;

namespace AbcPos.Web
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "SyncService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select SyncService.svc or SyncService.svc.cs at the Solution Explorer and start debugging.
    public class SyncService : ISyncService
    {
        public string Hello()
        {
            return "Hello";
        }

        public JedinicaMere[] JediniceMere()
        {
            using (var repo = new Repository())
            {
                return repo.JediniceMere();
            }
        }

        public Pdv[] Pdv()
        {
            using (var repo = new Repository())
            {
                return repo.Pdv().ToArray();
            }
        }

        public Artikal[] VratiArtikle(string idRadnje)
        {
            int id;
            if (Int32.TryParse(idRadnje, out id))
            {
                using (var repo = new Repository())
                {
                    var artikli = repo.Artikli().ToDictionary(x => x.ID);
                    //repo.RecycleContext();
                    var zalihe = repo.Zalihe(id);
                    foreach (var zaliha in zalihe)
                    {
                        artikli[zaliha.ArtikalID].Zalihe.Add(zaliha);
                    }
                    return artikli.Values.ToArray();
                }
            }
            return new Artikal[0];
        }

        public Radnja VratiRadnju(string id)
        {
            using (var repo = new Repository())
            {
                int idRadnje;
                return int.TryParse(id, out idRadnje) ? repo.VratiRadnju(idRadnje) : null;
            }
        }

        public Zaliha[] VratiZalihe(string idRadnje)
        {
            int id;
            if (Int32.TryParse(idRadnje, out id))
            {
                using (var repo = new Repository())
                {
                    return repo.Zalihe(id);
                }    
            }
            return new Zaliha[0];
        }

        public Racun[] VratiRacune(string idRadnje)
        {
            int id;
            if (Int32.TryParse(idRadnje, out id))
            {
                using (var repo = new Repository())
                {
                    return repo.Racuni(id);
                }
            }
            return new Racun[0];
        }

        public void SinhronizujRacune(Racun[] racuni)
        {
            using (var repo = new Repository())
            {
                foreach (var racun in racuni)
                {
                    SacuvajRacun(repo, racun);
                }
                repo.Submit();
            }
        }

        public void SacuvajRacun(Racun racun)
        {
            using (var repo = new Repository())
            {
                SacuvajRacun(repo, racun);
                repo.Submit();
            }
        }

        private void SacuvajRacun(Repository repository, Racun racun)
        {
            var postoji = repository.PostojiRacun(racun.UID);
            if (postoji) return;
            var r = new Racun()
            {
                TipDokumenta = (int)TipDokumenta.Prodaja,
                RadnjaID = racun.RadnjaID,
                Datum = DateTime.Now,
                Oznaka = racun.Oznaka,
                Zakljucen = true,
                Gotovina = racun.Gotovina,
                Kartica = racun.Kartica,
                Cek = racun.Cek,
                IznosRacuna = racun.IznosRacuna,
                Sinhronizovan = true
            };
            repository.SacuvajRacun(r);
            foreach (var stavkaRacuna in racun.Stavke)
            {
                var stavka = new StavkaDokumenta
                {
                    ArtikalID = stavkaRacuna.ArtikalID,
                    Kolicina = stavkaRacuna.Kolicina,
                    ProdajnaCena = stavkaRacuna.ProdajnaCena,
                    DokumentID = r.ID
                };
                repository.InsertStavkaDokumenta(stavka);
                var zaliha = repository.VratiZalihuArtikla(stavkaRacuna.ArtikalID.Value, r.RadnjaID.Value);
                zaliha.TrenutnaZaliha -= stavkaRacuna.Kolicina;
                if (zaliha.TrenutnaZaliha < 0) throw new Exception("Zaliha artikla je negativna");
            }
        }
    }
}
