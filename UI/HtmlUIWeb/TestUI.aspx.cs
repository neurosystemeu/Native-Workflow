using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NeuroSystem.UI.HtmlUIWidgets.AspUI.Html;
using NeuroSystem.Workflow.UserData.UI.Html.DataSources;
using NeuroSystem.Workflow.UserData.UI.Html.Fluent;
using NeuroSystem.Workflow.UserData.UI.Html.Views;

namespace HtmlUIWeb
{
    public class Pracownik
    {
        public  string Nazwisko { get; set; }
        public string Imie { get; set; }
        public string IloscLat { get; set; }
        public Guid ProjektId { get; set; }
    }

    public partial class TestUI : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var mw = new Pracownik();
            mw.IloscLat = "30";
            mw.Nazwisko = "Kowalski";
            mw.Imie = "Jan";

            var view = new ViewFactory<Pracownik>();
            view.DataContext(mw);
            view.AddPanel(pan =>
            {
                pan.AddDataForm(p =>
                {
                    p.AddField(pp => pp.Nazwisko);
                    p.AddField(pp => pp.IloscLat);
                    //p.AddComboBox(pp => pp.ProjektId)
                    //.DataTextField("Name")
                    //.DataSource(new NeuroSystem.Workflow.UserData.UI.Html.DataSources.ObjectDataSource(mw));
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