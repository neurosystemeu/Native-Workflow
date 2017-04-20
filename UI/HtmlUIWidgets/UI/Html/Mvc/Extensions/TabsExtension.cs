using Kendo.Mvc.Infrastructure;
using Kendo.Mvc.UI;
using NeuroSystem.Workflow.UserData.UI.Html.ASP.UI.Html.Mvc.Extensions;
using NeuroSystem.Workflow.UserData.UI.Html.Mvc.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace NeuroSystem.Workflow.UserData.UI.Html.ASP.UI.Html.Mvc.Extensions
{
    public static class TabsExtension
    {
        public static Kendo.Mvc.UI.WidgetBase ToKendoWidget(this Tabs tabs, HtmlHelper helper,
            IJavaScriptInitializer initializer, Kendo.Mvc.IUrlGenerator urlGenerator)
        {
            var tabsBuilder = helper.Kendo().TabStrip().Name(tabs.Name);
            foreach (var tab in tabs.Items)
            {
                var control = tab.Panel.ToKendoWidget(helper, initializer, urlGenerator);
                var html = control.ToHtmlString();
                tabsBuilder.Items(a => { a.Add().Text(tab.Name).Content(html); });
            }

            var tabsControl = tabsBuilder.ToComponent();
            
            return tabsControl;
        }
    }
}
