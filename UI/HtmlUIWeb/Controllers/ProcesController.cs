using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Kendo.Mvc.Extensions;
using NeuroSystem.Workflow.UserData.UI.Html.ASP.UI.Html.Version2.TestViews;
using Kendo.Mvc.UI;

namespace HtmlUIWeb.Controllers
{
    public class ProcesController : Controller
    {
        // GET: Proces
        public ActionResult Index()
        {
            return View("Index", new ProcesMW(this));
        }

        public ActionResult PracownikTestModel_Read([DataSourceRequest] DataSourceRequest request)
        {
            var lista = listaPracownikow();
            var filtr = "k";
            var result = lista.Where(p=>p.Nazwa.Contains(filtr)).ToDataSourceResult(request);
            return Json(result, JsonRequestBehavior.AllowGet);
            //using (var kontekst = UtworzKontekstWykonania())
            //{
            //    var projektId = PobierzParametrGuid(nameof(ZapytaniaOfertoweMW.ProjektId));
            //    var jednostkaOrgId = PobierzParametrGuid(nameof(ZapytaniaOfertoweMW.JednostkaOrganizacyjnaId));
            //    var logika = kontekst.Logika<FakturaBL>();
            //    var zapytanie = logika.PobierzFaktury(projektId, jednostkaOrgId);
            //    var result = zapytanie.ToDataSourceResult(request, o => new FakturaMW(o));
            //    return Json(result);
            //}
            return null;
        }


        private List<PracownikTest> listaPracownikow()
        {
            var lista = new List<PracownikTest>();
            var imiona = "Michał;Paweł;Łukasz;Jan;Tomek;Krzysiek;Robert;Kuba;Wojtek;Marcin".Split(';');
            var nazwiska = "Kowalski;Nowak;Cich;Ciech".Split(';');

            int i = 1;
            foreach (var nazwisko in nazwiska)
            {
                foreach (var imie in imiona)
                {
                    lista.Add(new PracownikTest() { Nazwisko = nazwisko, Imie = imie, Id = i });
                    i++;
                }
            }

            return lista;
        }
    }
}