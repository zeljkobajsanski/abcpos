using System.Collections.Generic;
using AbcPos.Core.Models;

namespace AbcPos.Web.ViewModels
{
    public class ZaliheArtiklaViewModel
    {
        public int IdArtikla { get; set; }
        public IEnumerable<Radnja> Radnje { get; set; }
        public IEnumerable<Zaliha> Zalihe { get; set; }
    }
}