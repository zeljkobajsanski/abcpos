namespace AbcPos.Web.Models
{
    public class Artikal
    {
        public int ID { get; set; }
        
        public string Sifra { get; set; }
        
        public string Naziv { get; set; }

        public int JedinicaMereID { get; set; }

        public string OznakaJediniceMere { get; set; }

        public decimal Cena { get; set; }

        public int PdvID { get; set; }
        
        public string PdvStopa { get; set; }

        public string Barkod { get; set; } 
    }
}