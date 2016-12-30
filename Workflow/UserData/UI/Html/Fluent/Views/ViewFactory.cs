using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NeuroSystem.Workflow.UserData.UI.Html.Fluent.Panels;
using NeuroSystem.Workflow.UserData.UI.Html.Views;
using NeuroSystem.Workflow.UserData.UI.Html.Widget;
using NeuroSystem.Workflow.UserData.UI.Html.Widget.Panels;
using NeuroSystem.Workflow.UserData.UI.Html.Widgets.Panels;

namespace NeuroSystem.Workflow.UserData.UI.Html.Fluent
{
    public class ViewFactory<T> : WidgetFactory<T>
    {
        public ViewFactory()
        {
            Widget = new Panel();
        }

        private Panel panel => Widget as Panel;

        public ViewBase GetView()
        {
            return new ViewBase() {Panel = panel };
        }

        public ViewFactory<T> AddPanel(Action<PanelFactory<T>> _panel)
        {
            var factory = new PanelFactory<T>();
            _panel(factory);
            panel.Elementy.Add(factory.Panel);
            return this;
        }

        public ViewFactory<T> AddDataForm(Action<DataFormFactory<T>> _panel)
        {
            var factory = new DataFormFactory<T>();
            _panel(factory);
            panel.Elementy.Add(factory.Panel);
            return this;
        }
    }
}
