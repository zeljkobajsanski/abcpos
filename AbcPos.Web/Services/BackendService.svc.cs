using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using AbcPos.Core.Repository;
using AbcPos.Web.Models;

namespace AbcPos.Web.Services
{
    [ServiceContract]
    public class BackendService
    {
        [OperationContract]
        void Ping() { }

        [OperationContract]
        public IEnumerable<Artikal> VratiArtikle()
        {
            var artikli = new Repository().VratiArtikleSaPdvIJedinicamaMere().ToArray().Select(Mapper.Map);
            return artikli;
        }

        [OperationContract]
        public IEnumerable<KeyValue> VratiJediniceMera()
        {
            return new Repository().JediniceMere().Select(Mapper.Map);
        }

        [OperationContract]
        public IEnumerable<KeyValue> VratiPdv()
        {
            return new Repository().Pdv().Select(Mapper.Map);
        }

        [OperationContract]
        public int SacuvajArtikal(Artikal artikal)
        {
            var a = Mapper.Map(artikal);
            var r = new Repository();
            r.SacuvajArtikal(a, r.Radnje().Select(x => x.ID).ToArray());
            r.Submit();
            return a.ID;
        }

        [OperationContract]
        public IEnumerable<Dobavljac> VratiDobavljace()
        {
            var dobavljaci = new Repository().Dobavljaci();
            return dobavljaci.Select(Mapper.Map);
        }

        [OperationContract]
        public int SacuvajDobavljaca(Dobavljac dobavljac)
        {
            var d = Mapper.Map(dobavljac);
            var repos = new Repository();
            repos.SacuvajDobavljaca(d);
            repos.Submit();
            return d.ID;
        }
    }
}
