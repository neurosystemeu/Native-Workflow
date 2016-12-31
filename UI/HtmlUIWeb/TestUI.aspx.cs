using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NeuroSystem.Workflow.UserData.UI.Html.ASP.UI.Html;
using NeuroSystem.Workflow.UserData.UI.Html.DataSources;
using NeuroSystem.Workflow.UserData.UI.Html.Fluent;
using NeuroSystem.Workflow.UserData.UI.Html.Fluent.Views;
using NeuroSystem.Workflow.UserData.UI.Html.Views;

namespace HtmlUIWeb
{
    public class Pracownik
    {
        public string Id { get; set; }
        public  string Nazwisko { get; set; }
        public string Imie { get; set; }
        public string IloscLat { get; set; }
        public string ProjektId { get; set; }
    }

    public partial class TestUI : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var p1 = new Pracownik();
            p1.Id = "1";
            p1.IloscLat = "30";
            p1.Nazwisko = "Kowalski";
            p1.Imie = "Jan";

            var p2 = new Pracownik();
            p2.Id = "2";
            p2.IloscLat = "33";
            p2.Nazwisko = "Nowak";
            p2.Imie = "Krzysztof";

            var listaPracownikow = new List<Pracownik>() {p1,p2};
            
            var view = new ViewFactory<Pracownik>();
            view.DataContext(p1);
            view.AddPanel(pan =>
            {
                pan.AddDataForm(p =>
                {
                    p.AddField(pp => pp.Nazwisko);
                    p.AddField(pp => pp.IloscLat);
                    p.AddComboBox(pp => pp.ProjektId)
                    .DataTextField("Name")
                    .DataSource(new NeuroSystem.Workflow.UserData.UI.Html.DataSources.ObjectDataSource(listaPracownikow));
                });
                pan.AddDataForm(p =>
                {
                    p.AddField(pp => pp.IloscLat).Height("400px").Width("50%");
                    //p.AddGridView(grid =>
                    //{
                    //    grid.Column(k => k.Nazwisko);
                    //    grid.Column(k => k.IloscLat).Width("50%");
                    //});
                });
                pan.AddAction("Test");
            });

            var builder = new WidgetBuilder();
            builder.GenerateView(panel, view.GetView());
            panel.WczytajDoKontrolkiZMW();

        }

    }
}