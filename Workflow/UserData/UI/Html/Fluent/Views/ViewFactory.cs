using System;
using NeuroSystem.Workflow.UserData.UI.Html.Fluent.Widgets.Actions;
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
            menuPanel = new Panel();
            mainPanel.Elementy.Add(menuPanel);
        }

        protected Panel menuPanel;
        protected Panel mainPanel => Widget as Panel;

        public override ViewBase GetView()
        {
            return new ViewBase() {Panel = mainPanel };
        }

        public ViewFactory<T> AddPanel(Action<PanelFactory<T>> _panel)
        {
            var factory = new PanelFactory<T>();
            _panel(factory);
            mainPanel.Elementy.Add(factory.Panel);
            return this;
        }

        public Widgets.Panels.DataFormFactory<T> AddDataForm()
        {
            var factory = new Widgets.Panels.DataFormFactory<T>();
            mainPanel.Elementy.Add(factory.Panel);
            return factory;
        }

        public ViewFactory<T> AddDataForm(Action<Widgets.Panels.DataFormFactory<T>> _panel)
        {
            var factory = new Widgets.Panels.DataFormFactory<T>();
            _panel(factory);
            mainPanel.Elementy.Add(factory.Panel);
            return this;
        }

        public ActionFactory<T> AddAction(string actionName)
        {
            var factory = new ActionFactory<T>();
            factory.Action.Name = actionName;
            factory.Action.Label = actionName;
            menuPanel.Elementy.Add(factory.Action);

            return factory;
        }
    }
}
