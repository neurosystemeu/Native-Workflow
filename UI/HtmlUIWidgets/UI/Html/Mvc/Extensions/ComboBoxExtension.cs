using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Kendo.Mvc;
using Kendo.Mvc.Infrastructure;
using NeuroSystem.Workflow.UserData.UI.Html.Mvc.UI;

namespace NeuroSystem.Workflow.UserData.UI.Html.ASP.UI.Html.Mvc.Extensions
{
    public static class ComboBoxExtension
    {
        public static Kendo.Mvc.UI.WidgetBase ToKendoWidget(this ComboBox widget, HtmlHelper helper,
            IJavaScriptInitializer initializer, IUrlGenerator urlGenerator)
        {
            var control = new Kendo.Mvc.UI.ComboBox(helper.ViewContext, initializer, helper.ViewData, urlGenerator);
            control.Name = widget.Name;
            control.DataValueField = "Id";
            control.DataTextField = "Nazwisko";
            widget.DataSource.SetDataSource(control.DataSource,helper.ViewContext,initializer,helper.ViewData, urlGenerator);

            return control;
        }
    }
}
