using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using AbcPos.Core.Interfaces;
using AbcPos.Core.Models;
using AbcPos.Kasa.Models;
using AbcPos.Kasa.SyncService;

namespace AbcPos.Kasa.Services
{
    public class SyncService : ISyncService
    {
        private readonly ILocalRepository m_Repository;

        public SyncService(ILocalRepository repository)
        {
            m_Repository = repository;
        }

        public SyncResult SinhronizujKasu(string idProdavnice, IEnumerable<Racun> racuni)
        {
            var result = new SyncResult();
            using (var svc = GetService())
            {
                svc.SinhronizujRacune(racuni.ToList());
                result.Radnja = svc.VratiRadnju(idProdavnice);
                result.JediniceMere = svc.JediniceMere().ToArray();
                result.Pdv = svc.Pdv().ToArray();
                result.Artikli = svc.VratiArtikle(idProdavnice).ToArray();
                result.Racuni = svc.VratiRacune(idProdavnice);
            }
            return result;
        }

        public void SacuvajRacun(Racun racun)
        {
            using (var svc = GetService())
            {
                svc.SacuvajRacun(racun);
            }
        }

        private SyncServiceClient GetService()
        {
            var web = m_Repository.VratiKonfiguracijuKase().Web;
            if (string.IsNullOrEmpty(web)) throw new Exception("Web adresa servisa nije podešena");
            return new SyncServiceClient(new BasicHttpBinding("http"), new EndpointAddress(web));
        }
    }
}