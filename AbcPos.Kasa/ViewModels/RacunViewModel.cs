using System;
using System.Text;
using System.Transactions;
using AbcPos.Core.Interfaces;
using AbcPos.Core.Models;
using AbcPos.Kasa.Forms;
using AbcPos.Kasa.Models;
using AbcPos.Kasa.SyncService;
using Racun = AbcPos.Core.Models.Racun;
using System.Linq;
using ISyncService = AbcPos.Kasa.Services.ISyncService;

namespace AbcPos.Kasa.ViewModels
{
    public class RacunViewModel : Notifiable
    {
        private readonly ILocalRepository fRepository;
        private string fSifra;
        private decimal? fKolicina;
        private Artikal fArtikal;
        private StavkaRacuna fStavkaRacuna;
        private Racun fRacun;
        private readonly ISyncService fSyncService;


        public RacunViewModel(ILocalRepository repository, ISyncService syncService)
        {
            fRepository = repository;
            fSyncService = syncService;
            Racun = new Racun();
        }
        

        public KonfiguracijaKase KonfiguracijaKase
        {
            get { return fRepository.VratiKonfiguracijuKase(); }
        }

        public Racun Racun
        {
            get { return fRacun; }
            set
            {
                fRacun = value;
                Racun.RadnjaID = KonfiguracijaKase.ProdavnicaID;
            }
        }

        public string Sifra
        {
            get { return fSifra; }
            set
            {
                if (Sifra != value)
                {
                    fSifra = value;
                    OnPropertyChanged("Sifra");
                }
                
            }
        }

        public decimal? Kolicina
        {
            get { return fKolicina; }
            set
            {
                if (Kolicina != value)
                {
                    fKolicina = value;
                    OnPropertyChanged("Kolicina");
                }
            }
        }

        public StavkaRacuna StavkaRacuna
        {
            get { return fStavkaRacuna; }
            set
            {
                if (StavkaRacuna != (value))
                {
                    fStavkaRacuna = value;
                    Artikal = StavkaRacuna != null ? StavkaRacuna.Artikal : null;
                }
            }
        }

        public Artikal Artikal
        {
            get { return fArtikal; }
            set
            {
                if (Artikal != (value))
                {
                    fArtikal = value;
                    Sifra = Artikal != null ? Artikal.Sifra : null;
                    Kolicina = null;
                    OnPropertyChanged("NazivArtikla");
                    OnPropertyChanged("Artikal");
                }
            }
        }

        public string NazivArtikla
        {
            get
            {
                if (Artikal == null) return string.Empty;
                return Artikal.Naziv;
            }
        }

        

        public void PretraziArtikal()
        {
            Artikal = fRepository.VratiArtikalIZalihu(Sifra);
        }

        public void PrihvatiKolicinu()
        {
            if (!Kolicina.HasValue || Kolicina == 0) return;
            if (StavkaRacuna != null)
            {
                if (Artikal != null && !StavkaRacuna.Artikal.Equals(Artikal))
                {
                    StavkaRacuna.Artikal = Artikal;
                    var zaliha = fRepository.VratiZalihuArtikla(StavkaRacuna.Artikal.ID, KonfiguracijaKase.ProdavnicaID);
                    zaliha.TrenutnaZaliha += StavkaRacuna.Kolicina;
                    fRepository.SacuvajZalihu(zaliha);
                }
                if (Kolicina < 0 || ProveriKolicinu(StavkaRacuna))
                {
                    var zaliha = fRepository.VratiZalihuArtikla(StavkaRacuna.Artikal.ID, KonfiguracijaKase.ProdavnicaID);
                    zaliha.TrenutnaZaliha += StavkaRacuna.Kolicina;
                    zaliha.TrenutnaZaliha -= Kolicina.Value;
                    fRepository.SacuvajZalihu(zaliha);
                    StavkaRacuna.Kolicina = Kolicina.Value;
                    Artikal = null;
                    StavkaRacuna = null;
                }
                else throw new Exception("Nedovoljna zaliha artikla");
            }
            else
            {
                if (Artikal != null)
                {
                    var stavka = new StavkaRacuna {Artikal = Artikal, Rbr = Racun.StavkeRacuna.Any() ? Racun.StavkeRacuna.Max(x => x.Rbr) + 1 : 1};
                    if (Kolicina < 0 || ProveriKolicinu(stavka))
                    {
                        var zaliha = fRepository.VratiZalihuArtikla(stavka.Artikal.ID, KonfiguracijaKase.ProdavnicaID);
                        zaliha.TrenutnaZaliha -= Kolicina.Value;
                        fRepository.SacuvajZalihu(zaliha);
                        stavka.Kolicina = Kolicina.Value;
                        Racun.StavkeRacuna.Add(stavka);
                        Artikal = null;
                        StavkaRacuna = null;
                    }
                    else throw new Exception("Nedovoljna zaliha artikla");
                }
            }
        }

        public void VratiZalihe()
        {
            foreach (var stavkaRacuna in Racun.StavkeRacuna)
            {
                var zaliha = fRepository.VratiZalihuArtikla(stavkaRacuna.Artikal.ID, KonfiguracijaKase.ProdavnicaID);
                zaliha.TrenutnaZaliha += stavkaRacuna.Kolicina;
            }
            fRepository.Submit();
        }

        public Racun Sacuvaj()
        {
            
            //var id = fRepository.VratiSledeciIDRacuna();
            var poslednjiRacun = fRepository.VratiPosledjiRacun();
            var id = 1;
            var oznaka = "";
            if (poslednjiRacun != null)
            {
                id = poslednjiRacun.ID + 1;
                oznaka = poslednjiRacun.Oznaka.Substring(2);
                oznaka = KonfiguracijaKase.ProdavnicaID + "/" + (Int32.Parse(oznaka) + 1);
            }
            var racun = new Racun
            {
                ID = id,
                TipDokumenta = (int)TipDokumenta.Prodaja,
                RadnjaID = Racun.RadnjaID,
                Oznaka = oznaka,
                Datum = DateTime.Now,
                Zakljucen = true,
                Gotovina = Racun.Gotovina - Racun.Kusur,
                Kartica = Racun.Kartica,
                Cek = Racun.Cek,
                IznosRacuna = Racun.IznosRacuna,
            };
            fRepository.SacuvajRacun(racun);
            foreach (var stavkaRacuna in Racun.StavkeRacuna)
            {
                var stavka = new StavkaDokumenta()
                {
                    ArtikalID = stavkaRacuna.Artikal.ID,
                    Kolicina = stavkaRacuna.Kolicina,
                    ProdajnaCena = stavkaRacuna.Artikal.Cena,
                    DokumentID = racun.ID
                };
                racun.Stavke.Add(stavka);
                fRepository.InsertStavkaDokumenta(stavka);
                var zaliha = fRepository.VratiZalihuArtikla(stavkaRacuna.Artikal.ID, Racun.RadnjaID.Value);
                zaliha.UkupnaZaliha -= stavkaRacuna.Kolicina;
                zaliha.TrenutnaZaliha = zaliha.UkupnaZaliha;
            }
            
            fRepository.Submit();
            
            return racun;
        }

        private bool ProveriKolicinu(StavkaRacuna stavka)
        {
            if (KonfiguracijaKase.DozvoljeneNegativneZalihe) return true;
            var idArtikla = stavka.Artikal.ID;
            var zaliha = fRepository.VratiZalihuArtikla(idArtikla, KonfiguracijaKase.ProdavnicaID);
            var ukupnaKolicina = zaliha.TrenutnaZaliha + stavka.Kolicina;
            return ukupnaKolicina >= Kolicina;
        }

        public void ObrisiStavku(StavkaRacuna stavka)
        {
            var zaliha = fRepository.VratiZalihuArtikla(stavka.Artikal.ID, KonfiguracijaKase.ProdavnicaID);
            zaliha.TrenutnaZaliha += stavka.Kolicina;
            fRepository.Submit();
            Racun.StavkeRacuna.Remove(stavka);
        }

        public void SinhronizujRacun(Racun racun)
        {
            fSyncService.SacuvajRacun(racun);
        }

        public void OznaciSinhronizovanRacun(Racun racun)
        {
            if (racun == null) return;
            racun = fRepository.VratiRacun(racun.ID);
            if (racun != null)
            {
                racun.Sinhronizovan = true;
                fRepository.Submit();
            }
        }
    }

    
}