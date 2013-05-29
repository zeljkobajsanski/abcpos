using System;
using AbcPos.Core.Models;

namespace AbcPos.Core.Kriterijumi
{
    public class KriterijumPretrageDokumenata
    {
        public TipDokumenta TipDokumenta { get; set; }
        public int? IdRadnje { get; set; }
        public int? IdKomitenta { get; set; }
        public DateTime OdDatuma { get; set; }
        public DateTime DoDatuma { get; set; }
    }
}