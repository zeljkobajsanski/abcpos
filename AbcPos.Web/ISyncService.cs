using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Web.Services;
using AbcPos.Core.Models;

namespace AbcPos.Web
{
    [ServiceContract]
    public interface ISyncService
    {
        [OperationContract]
        [WebGet(UriTemplate = "hello", ResponseFormat = WebMessageFormat.Json)]
        string Hello();

        [OperationContract]
        [WebGet(UriTemplate = "JediniceMere", ResponseFormat = WebMessageFormat.Json)]
        JedinicaMere[] JediniceMere();

        [OperationContract]
        [WebGet(UriTemplate = "Pdv", ResponseFormat = WebMessageFormat.Json)]
        Pdv[] Pdv();

        [OperationContract]
        [WebGet(UriTemplate = "artikli/{idRadnje}", ResponseFormat = WebMessageFormat.Json)]
        Artikal[] VratiArtikle(string idRadnje);

        [OperationContract]
        [WebGet(UriTemplate = "radnja/{id}", ResponseFormat = WebMessageFormat.Json)]
        Radnja VratiRadnju(string id);

        [OperationContract]
        [WebGet(UriTemplate = "zalihe/{idRadnje}", ResponseFormat = WebMessageFormat.Json)]
        Zaliha[] VratiZalihe(string idRadnje);

        [OperationContract]
        [WebGet(UriTemplate = "racuni/{idRadnje}", ResponseFormat = WebMessageFormat.Json)]
        Racun[] VratiRacune(string idRadnje);

        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, UriTemplate = "SinhronizujRacune")]
        void SinhronizujRacune(Racun[] racuni);

        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, UriTemplate = "SacuvajRacun")]
        void SacuvajRacun(Racun racun);
    }
}
