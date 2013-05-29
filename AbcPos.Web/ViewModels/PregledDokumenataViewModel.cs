using System;
using System.Collections.Generic;
using AbcPos.Core.Kriterijumi;
using AbcPos.Core.Models;

namespace AbcPos.Web.ViewModels
{
    public class PregledDokumenataViewModel : ViewModelBase
    {
        public PregledDokumenataViewModel()
        {
            Kriterijumi = new KriterijumPretrageDokumenata
            {
                OdDatuma = DateTime.Now,
                DoDatuma = DateTime.Now
            };
        }

        public KriterijumPretrageDokumenata Kriterijumi { get; set; }

        public IEnumerable<Radnja> Radnje
        {
            get { return fRepository.Radnje(); }
        }

        public IEnumerable<Dokument> Dokumenti { get; private set; }

        public IEnumerable<Racun> Racuni { get; private set; }

        public void PretraziDokumente()
        {
            if (Kriterijumi.TipDokumenta == TipDokumenta.Nabavka)
            {
                Dokumenti = fRepository.VratiDokumente(Kriterijumi);
            }
            else if (Kriterijumi.TipDokumenta == TipDokumenta.Prodaja)
            {
                Racuni = fRepository.VratiRacune(Kriterijumi);
            }
        }
    }
}