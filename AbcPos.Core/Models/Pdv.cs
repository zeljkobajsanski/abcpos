namespace AbcPos.Core.Models
{
    public class Pdv : Entity
    {
        public string Naziv { get; set; }
        public decimal Stopa { get; set; }
        public bool Default { get; set; }
    }
}