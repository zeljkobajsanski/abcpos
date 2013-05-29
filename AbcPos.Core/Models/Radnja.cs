using System.Collections.Generic;

namespace AbcPos.Core.Models
{
    public class Radnja : Entity
    {
        public string Naziv { get; set; }

        public IList<Zaliha> Zalihe { get; set; }
    }
}