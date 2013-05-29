using System;
using System.Web.Mvc;
using AbcPos.Core.Kriterijumi;
using AbcPos.Core.Models;
using AbcPos.Core.Repository;
using AbcPos.Web.ViewModels;
using System.Linq;

namespace AbcPos.Web.Controllers
{
    public class NabavkaController : Controller
    {
        private readonly Repository fRepository = new Repository();

        public ActionResult Index(int? idRadnje, DateTime? odDatuma, DateTime? doDatuma)
        {
            var vm = new PregledDokumenataViewModel(){Kriterijumi = {TipDokumenta = TipDokumenta.Nabavka}};
            var kriterijum = Session["KriterijumPretrage"] as KriterijumPretrageDokumenata;
            if (kriterijum == null)
            {
                kriterijum = vm.Kriterijumi;
                Session["KriterijumPretrage"] = kriterijum;
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
                return PartialView("PregledDokumenata/_DokumentiGrid", vm);
            }
            return View("PregledDokumenata/Index", vm);
        }

        public ActionResult NovaNabavka()
        {
            var vm = new NabavkaViewModel
            {
                Dokument = new Dokument(),
                StavkaDokumenta = new StavkaDokumenta(){},
            };
            return View("Nabavka", vm);
        }

        public ActionResult SacuvajZaglavlje(Dokument dokument)
        {
            if (ModelState.IsValid)
            {
                dokument.TipDokumenta = (int)TipDokumenta.Nabavka;
                fRepository.SacuvajZaglavljeDokumenta(dokument);
            }
            return Json(dokument.ID);
        }

        public ActionResult SacuvajStavku([Bind(Prefix = "StavkaDokumenta")]StavkaDokumenta stavka)
        {
            if (ModelState.IsValid)
            {
                var dokument = fRepository.VratiDokumentSaStavkama(stavka.DokumentID);
                if (stavka.ID == 0)
                {
                    dokument.Stavke.Add(stavka);
                }
                else
                {
                    var stavkaDokumenta = dokument.Stavke.Single(x => x.ID == stavka.ID);
                    stavkaDokumenta.ArtikalID = stavka.ArtikalID;
                    stavkaDokumenta.Kolicina = stavka.Kolicina;
                    stavkaDokumenta.NabavnaCena = stavka.NabavnaCena;
                    stavkaDokumenta.ProdajnaCena = stavka.ProdajnaCena;
                }
                fRepository.Submit();
            }
            
            return new EmptyResult();
        }

        public PartialViewResult VratiStavkeDokumenta(int? idDokumenta)
        {
            var vm = new NabavkaViewModel
            {
                Dokument = new Dokument()
            };
            if (idDokumenta.HasValue && idDokumenta.Value > 0)
            {
                vm.Dokument = fRepository.VratiDokumentSaStavkama(idDokumenta.Value);
            }
            return PartialView("_StavkeGrid", vm);
        }

        public void DodajArtikle(int idDokumenta, int[] idArtikala)
        {
            var dokument = fRepository.VratiDokumentSaStavkama(idDokumenta);
            foreach (var idArtikla in idArtikala)
            {
                dokument.Stavke.Add(new StavkaDokumenta(){ArtikalID = idArtikla});
            }
            fRepository.Submit();
        }

        public JsonResult VratiStavkuDokumenta(int id)
        {
            var stavka = fRepository.VratiStavkuDokumenta(id);
            return Json(stavka, JsonRequestBehavior.AllowGet);
        }

        public void ObrisiStavku(int id)
        {
            fRepository.ObrisiStavku(id);

        }

        public ActionResult IzmeniDokument(int id)
        {
            var vm = new NabavkaViewModel();
            vm.UcitajDokument(id);
            return View("Nabavka", vm);
        }

        [HttpPost]
        public ActionResult Aktiviraj(int id)
        {
            var vm = new NabavkaViewModel();
            vm.AktivirajDokument(id);
            return RedirectToAction("Index");
        }
    }
}
