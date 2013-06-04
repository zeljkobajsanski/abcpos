using AbcPos.BackOffice.Win.Models.Validation;

namespace AbcPos.BackOffice.Win.Models.Entities
{
    public class Dobavljac : Entity
    {
        private string fSifra;
        private string fNaziv;

        public Dobavljac()
        {
            Validator = new DobavljacValidator();
        }

        public string Sifra
        {
            get { return fSifra; }
            set
            {
                if (Sifra == value) return;
                fSifra = value;
                OnPropertyChanged("Sifra");
            }
        }

        public string Naziv
        {
            get { return fNaziv; }
            set
            {
                if (Naziv == value) return;
                fNaziv = value;
                OnPropertyChanged("Naziv");
            }
        }


    }
}