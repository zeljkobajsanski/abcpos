using AbcPos.BackOffice.Win.Models.Validation;

namespace AbcPos.BackOffice.Win.Models.Entities
{
    public class Artikal : Entity
    {
        private string m_Sifra;
        private string m_Naziv;
        private int? m_JedinicaMereID;
        private string m_OznakaJediniceMere;
        private decimal m_Cena;
        private int? m_PdvID;
        private string m_PdvStopa;
        private string m_Barkod;

        public Artikal()
        {
            Validator = new ArtikalValidator();
        }

        public string Sifra
        {
            get { return m_Sifra; }
            set
            {
                if (value == m_Sifra)
                {
                    return;
                }
                m_Sifra = value;
                OnPropertyChanged("Sifra");
            }
        }

        public string Naziv
        {
            get { return m_Naziv; }
            set
            {
                if (value == m_Naziv)
                {
                    return;
                }
                m_Naziv = value;
                OnPropertyChanged("Naziv");
            }
        }

        public int? JedinicaMereID
        {
            get { return m_JedinicaMereID; }
            set
            {
                if (value == m_JedinicaMereID)
                {
                    return;
                }
                m_JedinicaMereID = value;
                OnPropertyChanged("JedinicaMereID");
            }
        }

        public string OznakaJediniceMere
        {
            get { return m_OznakaJediniceMere; }
            set
            {
                if (value == m_OznakaJediniceMere)
                {
                    return;
                }
                m_OznakaJediniceMere = value;
                OnPropertyChanged("OznakaJediniceMere");
            }
        }

        public decimal Cena
        {
            get { return m_Cena; }
            set
            {
                if (value == m_Cena)
                {
                    return;
                }
                m_Cena = value;
                OnPropertyChanged("Cena");
            }
        }

        public int? PdvID
        {
            get { return m_PdvID; }
            set
            {
                if (value == m_PdvID)
                {
                    return;
                }
                m_PdvID = value;
                OnPropertyChanged("PdvID");
            }
        }

        public string PdvStopa
        {
            get { return m_PdvStopa; }
            set
            {
                if (value == m_PdvStopa)
                {
                    return;
                }
                m_PdvStopa = value;
                OnPropertyChanged("PdvStopa");
            }
        }

        public string Barkod
        {
            get { return m_Barkod; }
            set
            {
                if (value == m_Barkod)
                {
                    return;
                }
                m_Barkod = value;
                OnPropertyChanged("Barkod");
            }
        }
    }
}