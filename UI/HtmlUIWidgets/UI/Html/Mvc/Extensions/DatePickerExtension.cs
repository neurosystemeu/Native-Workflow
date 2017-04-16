using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Kendo.Mvc.Infrastructure;
using NeuroSystem.Workflow.UserData.UI.Html.Mvc.UI;

namespace NeuroSystem.Workflow.UserData.UI.Html.ASP.UI.Html.Mvc.Extensions
{
    public static class DatePickerExtensions
    {
        public static Kendo.Mvc.UI.WidgetBase ToKendoWidget(this DatePicker widget, ViewContext viewContext,
            IJavaScriptInitializer initializer, ViewDataDictionary viewData)
        {
            var control = new Kendo.Mvc.UI.DatePicker(viewContext, initializer, viewData);
            control.Name = widget.Name;
            control.Value = widget.Value;
            return control;
        }
        
    }
}
