namespace AbcPos.BackOffice.Models
{
    public class Artikal
    {
        public int ID { get; set; }
        public string Sifra { get; set; }
        public string Naziv { get; set; }
        public int JedinicaMereID { get; set; }
        public int PdvID { get; set; }
        public string Barkod { get; set; }
    }
}