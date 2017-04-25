using System.Web.Mvc;
using Kendo.Mvc.Infrastructure;
using NeuroSystem.Workflow.UserData.UI.Html.Mvc.UI;
using NeuroSystem.Workflow.UserData.UI.Html.Mvc.Widgets;

namespace NeuroSystem.Workflow.UserData.UI.Html.Mvc.Extensions
{
    public static class LabelExtension
    {
        public static NsLabel ToKendoWidget(this Label widget, HtmlHelper helper,
            IJavaScriptInitializer initializer)
        {
            var control = new NsLabel(widget, helper, initializer);
            control.Name = widget.Name;
            control.Content = widget.Content;            
            return control;
        }
    }
}
