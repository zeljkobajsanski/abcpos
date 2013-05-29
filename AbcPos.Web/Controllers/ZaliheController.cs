using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using AbcPos.Core.Models;
using AbcPos.Core.Repository;
using AbcPos.Web.ViewModels;

namespace AbcPos.Web.Controllers
{
    public class ZaliheController : Controller
    {
        public ActionResult Index(int? id, int? idRadnje, bool? fromCache)
        {
            //var model = Session["ZaliheCriteria"] as ZaliheViewModel;
            //if (model == null)
            //{
            //    model = new ZaliheViewModel();
            //    Session["ZaliheCriteria"] = model;
            //}
            var model = new ZaliheViewModel();
            if (Request.IsAjaxRequest())
            {
                model.IdZalihe = id;
                if (idRadnje.HasValue)
                {
                    model.IdRadnje = idRadnje.Value;
                    if (fromCache.HasValue && fromCache.Value)
                    {
                        model.Zalihe = HttpContext.Application.Get("Zalihe") as IEnumerable<Zaliha>;
                    }
                    else
                    {
                        model.Pretrazi();
                        HttpContext.Application.Add("Zalihe", model.Zalihe);    
                    }
                    
                }
                model.IdZalihe = null;
                return PartialView("_ZaliheGrid", model.Zalihe);
            }
            return View(model);
        }

        public ActionResult SacuvajIzmene(Zaliha zaliha)
        {
            var model = new ZaliheViewModel() {IdRadnje = zaliha.RadnjaID};
            model.SacuvajZalihu(zaliha);
            model.Pretrazi();
            return PartialView("_ZaliheGrid", model.Zalihe);
        }

        public PartialViewResult VratiDijagram(string args)
        {
            
            var model = new ZaliheViewModel() { IdRadnje = 1 };
            if (args != null)
            {
                var jss = new JavaScriptSerializer();
                model.IdZaliha = jss.Deserialize<int[]>(args);
                model.Pretrazi();
            }
            return PartialView("_Chart", model.Zalihe.Take(20).ToArray());
        }

    }
}
