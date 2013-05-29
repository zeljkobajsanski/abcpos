using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace AbcPos.Core.Models
{
    public class Dokument : Entity
    {
        public Dokument()
        {
            Datum = DateTime.Now;
            Stavke = new List<StavkaDokumenta>();
            UID = Guid.NewGuid();
        }

        public int TipDokumenta { get; set; }
        public string Oznaka { get; set; }
        public DateTime Datum { get; set; }
        [Required(ErrorMessage = "Prodavnica nije izabrana")]
        public int? RadnjaID { get; set; }
        public Radnja Radnja { get; set; }
        public int? KomitentID { get; set; }
        public Komitent Komitent { get; set; }
        public Guid UID { get; set; }
        public bool Zakljucen { get; set; }
        public IList<StavkaDokumenta> Stavke { get; set; }
        public bool Sinhronizovan { get; set; }
        public decimal Ukupno
        {
            get
            {
                if (!Stavke.Any()) return 0;
                switch ((TipDokumenta)TipDokumenta)
                {
                    case Models.TipDokumenta.Nabavka:
                        return Stavke.Sum(x => x.NabavnaNetoVrednost);
                    case Models.TipDokumenta.Prodaja:
                        return Stavke.Sum(x => x.ProdajnaVrednost);
                    default:
                        return 0;
                }

            }
        }

        public void AktivirajDokument()
        {
            Zakljucen = true;
            foreach (var stavkaDokumenta in Stavke)
            {
                var zaliha = stavkaDokumenta.Artikal.Zalihe.Single(x => x.RadnjaID == RadnjaID);
                switch ((TipDokumenta)TipDokumenta)
                {
                        case Models.TipDokumenta.Nabavka:
                        zaliha.TrenutnaZaliha += stavkaDokumenta.Kolicina;
                        zaliha.UkupnaZaliha += stavkaDokumenta.Kolicina;
                        zaliha.NabavnaCena = stavkaDokumenta.NabavnaCena;
                        zaliha.ProdajnaCena = stavkaDokumenta.ProdajnaCena;
                        break;
                }
            }
        }
    }
}