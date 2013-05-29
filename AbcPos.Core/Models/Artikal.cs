using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace AbcPos.Core.Models
{
    public class Artikal : Entity
    {
        public Artikal()
        {
            Zalihe = new List<Zaliha>();
        }

        [DataMember]
        [Required(ErrorMessage = "Šifra artikla nije uneta")]
        [StringLength(20, ErrorMessage = "Šifra je predugačka")]
        public string Sifra { get; set; }

        [DataMember]
        [Required(ErrorMessage = "Naziv artikla nije unet")]
        [StringLength(255, ErrorMessage = "Naziv artikla je predugačak")]
        public string Naziv { get; set; }

        
        public int JedinicaMereID { get; set; }
        public JedinicaMere JedinicaMere { get; set; }

        public decimal Cena { get; set; }
        
        public int PdvID { get; set; }
        public Pdv Pdv { get; set; }

        public string Barkod { get; set; }

        public IList<Zaliha> Zalihe { get; set; }

        public decimal Zaliha { get; set; }

        public void IzjednaciZalihu()
        {
            foreach (var zaliha in Zalihe)
            {
                zaliha.UkupnaZaliha = zaliha.TrenutnaZaliha;
            }
        }

        public override string ToString()
        {
            return Naziv;
        }
    }
}