using System.Web.Mvc;
using Kendo.Mvc.Infrastructure;
using Kendo.Mvc.UI;
using NeuroSystem.Workflow.UserData.UI.Html.Mvc.UI;

namespace NeuroSystem.Workflow.UserData.UI.Html.Mvc.Extensions
{
    public static class TabsExtension
    {
        public static Kendo.Mvc.UI.WidgetBase ToKendoWidget(this Tabs tabs, HtmlHelper helper,
            IJavaScriptInitializer initializer, Kendo.Mvc.IUrlGenerator urlGenerator)
        {
            var tabsBuilder = helper.Kendo().TabStrip().Name(tabs.Name);
            var selected = true;
            foreach (var tab in tabs.Items)
            {
                var control = tab.Panel.ToKendoWidget(helper, initializer, urlGenerator);
                var html = control.ToHtmlString();
                tabsBuilder.Items(a => { a.Add().Text(tab.Name).Content(html).Selected(selected); });
                selected = false;
            }

            var tabsControl = tabsBuilder.ToComponent();
            
            return tabsControl;
        }
    }
}
