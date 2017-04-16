using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.WebPages.Html;
using System.Web.Mvc;
using Kendo.Mvc;
using Kendo.Mvc.Infrastructure;
using Kendo.Mvc.UI.Html;
using NeuroSystem.Workflow.UserData.UI.Html.ASP.UI.Html.Mvc.Extensions;
using NeuroSystem.Workflow.UserData.UI.Html.ASP.UI.Html.Version2.TestViews;
using NeuroSystem.Workflow.UserData.UI.Html.Mvc.Fluent;

namespace NeuroSystem.Workflow.UserData.UI.Html.ASP.UI.Html.Version2.Extensions
{
    public static class HtmlHelperExtension
    {
        public static WidgetFactory Ns(this System.Web.Mvc.HtmlHelper helper)
        {
            return new WidgetFactory(helper);
        }

        public static object Ns<TModel>(this HtmlHelper<TModel> helper)
        {
            var viewContext = helper.ViewContext;
            var initializer = DI.Current.Resolve<IJavaScriptInitializer>();
            var urlGenerator = DI.Current.Resolve<IUrlGenerator>();

            var model = new PracownikTestModel();
            model.Imie = "Jan";
            model.Nazwisko = "Kowalski";

            var html = new WidgetFactory();
            var panelGlwony = html.Panel();

            var g1 = html.Panel();
            g1.Class("form-horizontal form-widgets col-sm-6");

            var tb = html.TextBox<string>();
            tb.Name("Imie");
            g1.AddItem(tb);

            var b2 = html.TextBox<string>();
            b2.Name("Nazwisko");
            g1.AddItem(b2);
            panelGlwony.AddItem(g1);

            var dp = html.DatePicker();
            dp.Value(DateTime.Now);
            dp.Name("Data");
            g1.AddItem(dp);

            var cb = html.ComboBox();
            cb.Name("cb");

            cb.DataSource(ds => ds.Read("PracownikTestModel_Read", "Proces")
                );
            g1.AddItem(cb);


            var grid = html.Grid<PracownikTestModel>();
            grid.Name("grid");
            grid.DataSource(ds => ds
                .Ajax()
                .Model(m => m.Id("Id"))
                .Read("PracownikTestModel_Read", "Proces")
                );
            panelGlwony.AddItem(grid);




            var kontrolka = panelGlwony.ToComponent().ToKendoWidget(viewContext, initializer, helper.ViewData, urlGenerator);

            return new MvcHtmlString(kontrolka.ToHtmlString());
        }
    }
}
