using System;
using System.ComponentModel.DataAnnotations;

namespace AbcPos.Core.Models
{
    public class StavkaDokumenta : Entity
    {
        private decimal m_Kolicina;
        private Artikal m_Artikal;
        public int DokumentID { get; set; }
        public Dokument Dokument { get; set; }
        [Required(ErrorMessage = "Artikal nije izabran")]
        public int? ArtikalID { get; set; }
        public Artikal Artikal
        {
            get { return m_Artikal; }
            set
            {
                if (Artikal != value)
                {
                    m_Artikal = value;
                    OnPropertyChanged("Artikal");
                }
            }
        }

        public decimal Kolicina
        {
            get { return m_Kolicina; }
            set
            {
                if (Kolicina != value)
                {
                    m_Kolicina = value;
                    OnPropertyChanged("Kolicina");
                }
            }
        }

        public decimal NabavnaCena { get; set; }
        public decimal ProdajnaCena { get; set; }
        public decimal ProcenatRabata { get; set; }
        public decimal IznosRabata { get { return NabavnaCena * ProcenatRabata/100 * Kolicina; } }
        public decimal NabavnaBrutoVrednost { get { return Kolicina * NabavnaCena; } }
        public decimal NabavnaNetoVrednost { get { return Kolicina * NabavnaCena * (1 - ProcenatRabata / 100); } }
        public decimal ProdajnaVrednost { get { return Kolicina * ProdajnaCena; } }
    }
}