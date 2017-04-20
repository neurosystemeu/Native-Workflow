using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Kendo.Mvc.Infrastructure;
using NeuroSystem.Workflow.UserData.UI.Html.ASP.UI.Html.Version2.Widgets;
using NeuroSystem.Workflow.UserData.UI.Html.Mvc.UI;

namespace NeuroSystem.Workflow.UserData.UI.Html.ASP.UI.Html.Mvc.Extensions
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
