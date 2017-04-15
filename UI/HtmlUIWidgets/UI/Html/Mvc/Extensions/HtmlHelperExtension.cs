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
using NeuroSystem.Workflow.UserData.UI.Html.Mvc.Builders;

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
            var panel = html.Panel();
            

            var tb = html.TextBox<string>();
            panel.AddItem(tb);

            var grid = html.Grid<PracownikTestModel>();
            grid.Name("grid");
            grid.DataSource(ds => ds
                .Ajax()
                .Model(m=> m.Id("Id"))
                .Read("Read", "Home")
                );
            panel.AddItem(grid);


            var kontrolka = panel.ToComponent().ToKendoWidget(viewContext, initializer, helper.ViewData, urlGenerator);

            return new MvcHtmlString(kontrolka.ToHtmlString());
        }
    }
}
