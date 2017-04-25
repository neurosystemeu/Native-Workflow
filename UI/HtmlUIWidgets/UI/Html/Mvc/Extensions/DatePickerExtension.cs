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
        public static Kendo.Mvc.UI.WidgetBase ToKendoWidget(this DatePicker widget, HtmlHelper helper,
            IJavaScriptInitializer initializer)
        {
            var control = new Kendo.Mvc.UI.DatePicker(helper.ViewContext, initializer, helper.ViewData);
            control.Name = widget.Name;
            control.Value = widget.Value;
            control.Enabled = !widget.IsReadOnly;
            return control;
        }
        
    }
}
