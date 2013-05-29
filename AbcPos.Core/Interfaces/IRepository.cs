using System;
using System.Collections.Generic;
using AbcPos.Core.Kriterijumi;
using AbcPos.Core.Models;

namespace AbcPos.Core.Interfaces
{
    public interface IRepository : IDisposable
    {
        void InitDb();
        Radnja[] Radnje();
        Pdv[] Pdv();
        int DefaultPdv();
        JedinicaMere[] JediniceMere();
        int DefaultJedinicaMere();
        void Submit();
        void DropAndCreateDatabase();
        void RecycleContext();
        Radnja VratiRadnju(int idRadnje);
        void SacuvajRadnju(Radnja radnja);
        void Insert(Pdv pdv);
        void Insert(JedinicaMere jedinicaMere);
        void Insert(Radnja radnja);
        void SetAutoDetectChangesEnabled(bool enable);
        void SetValidateOnSaveEnabled(bool enable);
        int SacuvajZaglavljeDokumenta(Dokument dokument);
        Dokument VratiDokument(int id);
        void IzmeniStavku(StavkaDokumenta stavka);
        Dokument VratiDokumentSaStavkama(int id);
        StavkaDokumenta VratiStavkuDokumenta(int id);
        void ObrisiStavku(int id);
        IEnumerable<Dokument> VratiDokumente(KriterijumPretrageDokumenata kriterijumi);
        Dokument VratiDokumentSaZalihama(int id);
        Artikal[] Artikli();
        Artikal[] VraiArtikleZaSinhronizaciju();
        int SledeciIdArtikla();
        void Insert(Artikal artikal);
        void SacuvajArtikal(Artikal artikal, params int[] radnje);
        Artikal VratiArtikalPoSifriIliBarKodu(string sifraIliBarKod);
        IEnumerable<Artikal> PretraziArtikle(string sifraIliBarKd, string deoNaziva);
        bool PostojiSifraArtikla(string sifra);
        bool PostojiNazivArtikla(string naziv);
        int UkupanBrojArtikala();
        IEnumerable<Artikal> PretraziArtikleIZalihu(string sifra, string naziv);
        Artikal VratiArtikalIZalihu(string sifraIliBarKod);
        IEnumerable<Dobavljac> Dobavljaci();
        IEnumerable<Dobavljac> VratiDobavljace(string filter, int beginIndex, int endIndex);
        Dobavljac VratiDobavljaca(int id);
        Zaliha[] Zalihe(int idRadnje);
        Zaliha VratiZalihuArtikla(int idArtikla, int idRadnje);
        Zaliha VratiZalihuArtikla(string oznakaIliBarKod, int idRadnje);
        IEnumerable<Zaliha> VratiZalihuArtikla(int idArtikla);
        void SacuvajZalihu(Zaliha zaliha);
        void SacuvajRacun(Racun racun);
        void InsertStavkaDokumenta(StavkaDokumenta stavka);
        Zaliha[] VratiZaliheArtikala(int idRadnje, int? idZalihe, int[] idZaliha);
    }
}