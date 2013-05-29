namespace AbcPos.Core.Models
{
    public class StavkaRacuna : StavkaDokumenta
    {
        private string m_Sifra;
        public string Sifra
        {
            get { return m_Sifra; }
            set
            {
                if (Sifra != value)
                {
                    m_Sifra = value;
                    OnPropertyChanged("Sifra");
                }
            }
        }

        public string NazivArtikla {
            get { return Artikal != null ? Artikal.Naziv : null; }
        }

        public string JM { get { return Artikal.JedinicaMere.Oznaka; }}
        
        public decimal Cena { get { return Artikal.Cena; }}

        public decimal Iznos { get { return Cena * Kolicina; }}

        public int Rbr { get; set; }

        public StavkaRacuna Kopiraj()
        {
            return new StavkaRacuna
            {
                Artikal = Artikal,
                Sifra = Artikal.Sifra,
                Kolicina = Kolicina
            };
        }

        protected override void OnPropertyChanged(string propertyName)
        {
            base.OnPropertyChanged(propertyName);
            switch (propertyName)
            {
                case "Artikal":
                    Sifra = Artikal.Sifra;
                    OnPropertyChanged("NazivArtikla");
                    break;
            }
        }
    }
}