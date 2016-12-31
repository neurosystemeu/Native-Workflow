using System;
using NeuroSystem.Workflow.UserData.UI.Html.Fluent.Widgets.Panels;
using NeuroSystem.Workflow.UserData.UI.Html.Views;
using NeuroSystem.Workflow.UserData.UI.Html.Widgets.Panels;

namespace NeuroSystem.Workflow.UserData.UI.Html.Fluent.Views
{
    public class ViewFactory<T> : ViewFaktoryBase
    {
        public ViewFactory()
        {
            Widget = new Panel();
        }

        private Panel panel => Widget as Panel;

        public override ViewBase GetView()
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

        public ViewFactory<T> AddDataForm(Action<Widgets.Panels.DataFormFactory<T>> _panel)
        {
            var factory = new Widgets.Panels.DataFormFactory<T>();
            _panel(factory);
            panel.Elementy.Add(factory.Panel);
            return this;
        }
    }
}
