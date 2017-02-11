using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NeuroSystem.Workflow.UserData.UI.Html.Widgets.Panels;

namespace NeuroSystem.Workflow.UserData.UI.Html.Fluent.Widgets.Panels
{
    public class TabsFactory<T> : WidgetFactory<T>
    {
        public TabsFactory()
        {
            Widget = new TabsWidget();
        }

        public TabsWidget Tabs => Widget as TabsWidget;

        public TabFactory<T> AddTab(string tabName)
        {
            var factory = new TabFactory<T>();
            factory.Tab.Name = tabName;

            Tabs.Tabs.Add(factory.Tab);

            return factory;
        }
    }
}
