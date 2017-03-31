using System;
using NeuroSystem.Workflow.UserData.UI.Html.Version1.Fluent.Widgets.Actions;
using NeuroSystem.Workflow.UserData.UI.Html.Version1.Widgets.DataForms;
using NeuroSystem.Workflow.UserData.UI.Html.Version1.Widgets.Panels;

namespace NeuroSystem.Workflow.UserData.UI.Html.Version1.Fluent.Widgets.Panels
{
    public class PanelFactory<T> : WidgetFactory<T>
    {
        public Panel Panel => Widget as Panel;

        public PanelFactory()
        {
            Widget = new Panel();
        }

        public PanelFactory<T> Float(EnumPanelFloat f)
        {
            Panel.Float = f;
            return this;
        }

        public PanelFactory<T> Clear(EnumPanelClear f)
        {
            Panel.Clear = f;
            return this;
        }

        public PanelFactory<T> AddPanel()
        {
            var factory = new PanelFactory<T>();
            Panel.Elementy.Add(factory.Panel);
            
            return factory;
        }

        public PanelFactory<T> AddPanel(Action<PanelFactory<T>> panel)
        {
            var factory = new PanelFactory<T>();
            Panel.Elementy.Add(factory.Panel);
            panel(factory);
            return this;
        }

        public DataFormFactory<T> AddDataForm(Action<DataFormFactory<T>> panel = null)
        {
            var factory = new DataFormFactory<T>();

            Panel.Elementy.Add(factory.Panel);
            if (panel != null)
            {
                panel(factory);
            }
            return factory;
        }

        public TabsFactory<T> AddTabs()
        {
            var factory = new TabsFactory<T>();

            Panel.Elementy.Add(factory.Tabs);
            return factory;
        }

        public PanelFactory<T2> AddDataForm<T2>(T2 dataContext, Action<DataFormFactory<T2>> panel)
        {
            var factory = new DataFormFactory<T2>();
            factory.DataContext(dataContext);
            Panel.Elementy.Add(factory.Panel);

            panel(factory);
            return factory;
        }

        public ActionFactory<T> AddAction(string actionName)
        {
            var factory = new ActionFactory<T>();
            factory.Action.Name = actionName;
            factory.Action.Label = actionName;
            Panel.Elementy.Add(factory.Action);
            
            return factory;
        }

        public PanelFactory<T> AddLabel(string text)
        {
            Panel.Elementy.Add(new Label() {Label = text});
            return this;
        }
    }
}
