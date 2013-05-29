namespace AbcPos.Core.Models
{
    public class KonfiguracijaKase : Entity
    {
        public bool DozvoljeneNegativneZalihe { get; set; }
        public int BrojDecimalaZaKolicinu { get; set; }
        public int ProdavnicaID { get; set; }
        public string Web { get; set; }
    }
}