using System.Web.Mvc;
using Kendo.Mvc.Infrastructure;
using NeuroSystem.Workflow.UserData.UI.Html.Mvc.UI;

namespace NeuroSystem.Workflow.UserData.UI.Html.Mvc.Extensions
{
    public static class CheckBoxBoxExtension
    {
        public static Kendo.Mvc.UI.WidgetBase ToKendoWidget(this CheckBox widget, HtmlHelper helper,
            IJavaScriptInitializer initializer)
        {
            var control = new Kendo.Mvc.UI.CheckBox(helper.ViewContext, initializer, helper.ViewData);
            control.Name = widget.Name;
            control.Value = widget.Value ?? false;
            control.Enabled = !widget.IsReadOnly;
            return control;
        }
    }
}
