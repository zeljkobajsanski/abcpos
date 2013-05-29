using System;
using System.Collections.Generic;
using AbcPos.Core.Models;
using AbcPos.Core.Repository;
using AbcPos.Web.Settings;
using DevExpress.Web.ASPxEditors;
using DevExpress.Web.Mvc;
using System.Linq;

namespace AbcPos.Web.ViewModels
{
    public class NabavkaViewModel : ViewModelBase
    {
        public NabavkaViewModel()
        {
            Dokument = new Dokument();
            StavkaDokumenta = new StavkaDokumenta();
        }

        public Dokument Dokument { get; set; }
        public StavkaDokumenta StavkaDokumenta { get; set; }
        public decimal? Marza { get; set; }

        public object FiltrirajDobavljace(ListEditItemsRequestedByFilterConditionEventArgs args)
        {
            return fRepository.VratiDobavljace(args.Filter, args.BeginIndex, args.EndIndex);
        }

        public object VratiDobavljaca(ListEditItemRequestedByValueEventArgs args)
        {
            var id = Convert.ToInt32(args.Value);
            return fRepository.VratiDobavljaca(id);
        }

        
        public IEnumerable<Radnja> Radnje
        {
            get { return fRepository.Radnje(); }
        } 

        public void UcitajDokument(int id)
        {
            Dokument = fRepository.VratiDokument(id);
            StavkaDokumenta.DokumentID = Dokument.ID;
        }

        public void AktivirajDokument(int id)
        {
            Dokument = fRepository.VratiDokumentSaZalihama(id);
            Dokument.AktivirajDokument();
            fRepository.Submit();
        }
    }
}