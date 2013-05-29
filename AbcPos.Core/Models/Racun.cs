using System.ComponentModel;
using System.Linq;

namespace AbcPos.Core.Models
{
    public class Racun : Dokument
    {
        private decimal? fGotovina;
        private decimal? fCek;
        private decimal? fKartica;
        private decimal fIznosRacuna;

        public Racun()
        {
            StavkeRacuna = new BindingList<StavkaRacuna>();
            StavkeRacuna.ListChanged += (s, e) =>
                                            {
                                                IznosRacuna = StavkeRacuna.Sum(x => x.Iznos);
                                            };
        }

        public BindingList<StavkaRacuna> StavkeRacuna { get; set; }

        public decimal? Gotovina
        {
            get { return fGotovina; }
            set
            {
                if (Gotovina != value)
                {
                    fGotovina = value;
                    OnPropertyChanged("Kusur");
                }
            }
        }

        public decimal? Cek
        {
            get { return fCek; }
            set
            {
                //if (value > IznosRacuna) value = IznosRacuna;
                if (Cek != value)
                {
                    fCek = value;
                    OnPropertyChanged("Kusur");
                }
            }
        }

        public decimal? Kartica
        {
            get { return fKartica; }
            set
            {
                //if (value > IznosRacuna) value = IznosRacuna;
                if (Kartica != value)
                {
                    fKartica = value;
                    OnPropertyChanged("Kusur");
                }
            }
        }

        public decimal Kusur
        {
            get
            {
                return IznosRacuna >= UkupnaUplata ? 0 : UkupnaUplata - IznosRacuna;
            }
        }

        public decimal UkupnaUplata
        {
            get { return (Gotovina ?? 0) + (Kartica ?? 0) + (Cek ?? 0); }
        }

        public decimal IznosRacuna
        {
            get { return fIznosRacuna; }
            set
            {
                if (IznosRacuna != value)
                {
                    fIznosRacuna = value;
                    OnPropertyChanged("IznosRacuna");
                }
            }
        }

        public void UplatiGotovinom()
        {
            Kartica = null;
            Cek = null;
            Gotovina = IznosRacuna;
        }

        public void UplatiKarticom()
        {
            Kartica = IznosRacuna;
            Cek = null;
            Gotovina = null;
        }

        public void UplatiCekom()
        {
            Kartica = null;
            Gotovina = null;
            Cek = IznosRacuna;
        }

        public void PopuniStavke()
        {
            foreach (var stavkaDokumenta in Stavke)
            {
                StavkeRacuna.Add(new StavkaRacuna()
                {
                    ArtikalID = stavkaDokumenta.ArtikalID,
                    Artikal = stavkaDokumenta.Artikal,
                    Kolicina = stavkaDokumenta.Kolicina,
                    ProdajnaCena = stavkaDokumenta.ProdajnaCena,
                });
            }
        }
    }
}