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
        public static Kendo.Mvc.UI.WidgetBase ToKendoWidget(this ComboBox widget, ViewContext viewContext,
            IJavaScriptInitializer initializer, ViewDataDictionary viewData, IUrlGenerator urlGenerator)
        {
            var control = new Kendo.Mvc.UI.ComboBox(viewContext, initializer, viewData, urlGenerator);
            control.Name = widget.Name;
            control.DataValueField = "Id";
            control.DataTextField = "Nazwisko";
            widget.DataSource.SetDataSource(control.DataSource,viewContext,initializer,viewData, urlGenerator);

            return control;
        }
    }
}
