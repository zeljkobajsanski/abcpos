using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AbcPos.Core.Kriterijumi;
using AbcPos.Core.Models;
using AbcPos.Core.Repository;
using AbcPos.Web.ViewModels;

namespace AbcPos.Web.Controllers
{
    public class ProdajaController : Controller
    {
        private Repository m_Repository = new Repository();

        public ActionResult Index(int? idRadnje, DateTime? odDatuma, DateTime? doDatuma)
        {
            var vm = new PregledDokumenataViewModel();
            vm.Kriterijumi.TipDokumenta = TipDokumenta.Prodaja;
            var kriterijum = Session["KriterijumPretrageProdaje"] as KriterijumPretrageDokumenata;
            if (kriterijum == null)
            {
                kriterijum = vm.Kriterijumi;
                Session["KriterijumPretrageProdaje"] = kriterijum;
            }
            else
            {
                vm.Kriterijumi = kriterijum;
            }

            if (odDatuma.HasValue && doDatuma.HasValue)
            {
                vm.Kriterijumi.IdRadnje = idRadnje;
                vm.Kriterijumi.OdDatuma = odDatuma.Value;
                vm.Kriterijumi.DoDatuma = doDatuma.Value;
                vm.PretraziDokumente();
            }
            if (Request.IsAjaxRequest())
            {
                return PartialView("_DokumentiGrid", vm);
            }
            return View("Index", vm);
        }

        public PartialViewResult VratiStavkeRacuna(int idDokumenta)
        {
            var stavke = m_Repository.VratiStavkeDokumenta(idDokumenta);
            return PartialView("_StavkeGrid", stavke);
        }

    }
}
