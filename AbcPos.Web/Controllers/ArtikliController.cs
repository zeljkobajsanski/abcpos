using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AbcPos.Core.Models;
using AbcPos.Core.Repository;
using AbcPos.Web.ViewModels;

namespace AbcPos.Web.Controllers
{
    public class ArtikliController : Controller
    {
        private readonly Repository fRepository = new Repository();

        public ActionResult Index()
        {
            var vm = new ArtikliViewModel
            {
                Pdv = fRepository.Pdv(),
                JediniceMere = fRepository.JediniceMere(),
                Artikli = fRepository.Artikli(),
                PrototipArtikla = new Artikal
                {
                    Sifra = fRepository.SledeciIdArtikla().ToString(),
                    JedinicaMereID = fRepository.DefaultJedinicaMere(),
                    PdvID = fRepository.DefaultPdv()
                }
            };
            if (Request.IsAjaxRequest())
            {
                return PartialView("_ArtikliGrid", vm);
            }
            return View(vm);
        }

        public ActionResult SacuvajArtikal(Artikal artikal)
        {
            var vm = new ArtikliViewModel
            {
                Pdv = fRepository.Pdv(),
                JediniceMere = fRepository.JediniceMere(),
            };
            if (!ModelState.IsValid)
            {
                vm.Greska = "Ispravite greške pre snimanja";
            }
            else
            {
                if (fRepository.PostojiSifraArtikla(artikal.Sifra) && artikal.ID == 0)
                {
                    throw new Exception("Izabrana šifra artikla već postoji");
                }
                if (fRepository.PostojiNazivArtikla(artikal.Naziv) && artikal.ID == 0)
                {
                    throw new Exception("Artikal sa istim nazivom već postoji");
                }
                var radnje = fRepository.Radnje().Select(x => x.ID).ToArray();
                fRepository.SacuvajArtikal(artikal, radnje);
                fRepository.Submit();
            }
            vm.Artikli = fRepository.Artikli();
            vm.PrototipArtikla.Sifra = fRepository.SledeciIdArtikla().ToString();
            vm.PrototipArtikla.JedinicaMereID = fRepository.DefaultJedinicaMere();
            vm.PrototipArtikla.PdvID = fRepository.DefaultPdv();
            return PartialView("_ArtikliGrid", vm);
        }
        
        public PartialViewResult Vratizalihe(int idArtikla)
        {
            var vm = new ZaliheArtiklaViewModel
            {
                IdArtikla = idArtikla,
                Radnje = fRepository.Radnje(),
                Zalihe = fRepository.VratiZalihuArtikla(idArtikla)
            };
            return PartialView("_ZaliheGrid", vm);
        }

        public PartialViewResult SacuvajZalihu(int idArtikla, Zaliha zaliha)
        {
            zaliha.ArtikalID = idArtikla;
            return Vratizalihe(zaliha.ArtikalID);
        }

        public JsonResult VratiArtikal(string sifra)
        {
            var artikal = fRepository.VratiArtikalPoSifriIliBarKodu(sifra);
            return Json(artikal, JsonRequestBehavior.AllowGet);
        }

        public PartialViewResult PretraziArtikle(string sifraIliBarKod, string naziv)
        {
            var vm = new PretragaArtikalaViewModel();
            vm.Pretrazi(sifraIliBarKod, naziv);
            return PartialView("PretragaArtikala/_PretragaArtikalaGrid", vm);
        }

    }
}
