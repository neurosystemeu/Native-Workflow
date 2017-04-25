using System.Web.Mvc;
using Kendo.Mvc.Infrastructure;
using NeuroSystem.Workflow.UserData.UI.Html.Mvc.UI;
using NeuroSystem.Workflow.UserData.UI.Html.Mvc.Widgets;

namespace NeuroSystem.Workflow.UserData.UI.Html.Mvc.Extensions
{
    public static class PanelExtension
    {
        public static NsPanel ToKendoWidget(this Panel panel, HtmlHelper helper,
            IJavaScriptInitializer initializer, Kendo.Mvc.IUrlGenerator urlGenerator)
        {
            var p = new NsPanel(panel, helper, initializer, urlGenerator);
            
            return p;
        }
    }
}
