using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.WebPages.Html;
using NeuroSystem.Workflow.UserData.UI.Html.Builders;
using System.Web.Mvc;
using Kendo.Mvc.Infrastructure;
using NeuroSystem.Workflow.UserData.UI.Html.ASP.UI.Html.Version2.TestViews;

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

            var model = new PracownikTestModel();
            model.Imie = "Jan";
            model.Nazwisko = "Kowalski";

            var html = new WidgetFactory();
            var panel = html.Panel();
            

            var tb = html.TextBox<string>();
            panel.AddItem(tb);



            var kontrolka = panel.ToComponent().ToKendoWidget(viewContext, initializer);

            return new MvcHtmlString(kontrolka.ToHtmlString());
        }
    }
}
