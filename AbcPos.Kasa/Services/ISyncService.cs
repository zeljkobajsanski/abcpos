using System.Collections.Generic;
using AbcPos.Core.Models;
using AbcPos.Kasa.Models;

namespace AbcPos.Kasa.Services
{
    public interface ISyncService
    {
        void SacuvajRacun(Racun racun);

        SyncResult SinhronizujKasu(string idProdavnice, IEnumerable<Racun> racuni);
    }
}