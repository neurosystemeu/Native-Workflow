using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using NeuroSystem.Workflow.UserData.UI.Html.Mvc.Infrastructure;
using NeuroSystem.Workflow.UserData.UI.Html.Mvc.TestViews;

namespace HtmlUIWeb.Controllers
{
    public class ProcesController : Controller
    {
        // GET: Proces
        public ActionResult Index()
        {
            var pracownik = new PracownikTest();
            pracownik.Nazwisko = "Kowalski";
            pracownik.Imie = "Jan";
            pracownik.DataWaznosciBadan = DateTime.Now;
            pracownik.RodzajPracownika = EnumRodzajPracownika.Biurowy;
            
            return View("Index", new ProcesMW() {Pracownik = pracownik});
        }

        public ActionResult Zapisz(PracownikTest pracownik)
        {
            return View("Index", new ProcesMW() { Pracownik = pracownik });
        }

        public ActionResult PracownikTest_Read([DataSourceRequest] DataSourceRequest request, string id)
        {
            var lista = listaPracownikow();
            var result = lista.ToDataSourceResult(request);
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
            //return null;
        }

        public ActionResult PracownikTest_ReadList(string text)
        {
            var lista = listaPracownikow();
            var wynik = lista.Where(l => l.Nazwa.Contains(text ?? "")).Select(
                e=> new {Id = e.Id, Nazwa = e.Nazwa}).ToList();
            return Json(wynik, JsonRequestBehavior.AllowGet);
            //var result = lista.ToDataSourceResult(request);
            //return Json(result, JsonRequestBehavior.AllowGet);

            //using (var kontekst = UtworzKontekstWykonania())
            //{
            //    var projektId = PobierzParametrGuid(nameof(ZapytaniaOfertoweMW.ProjektId));
            //    var jednostkaOrgId = PobierzParametrGuid(nameof(ZapytaniaOfertoweMW.JednostkaOrganizacyjnaId));
            //    var logika = kontekst.Logika<FakturaBL>();
            //    var zapytanie = logika.PobierzFaktury(projektId, jednostkaOrgId);
            //    var result = zapytanie.ToDataSourceResult(request, o => new FakturaMW(o));
            //    return Json(result);
            //}
            //return null;
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
                    lista.Add(new PracownikTest() { Nazwisko = nazwisko, Imie = imie, Id = Guid.NewGuid() });
                    i++;
                }
            }

            return lista;
        }
    }
    
}