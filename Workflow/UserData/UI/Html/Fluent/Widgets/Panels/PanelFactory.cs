using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using NeuroSystem.Workflow.UserData.UI.Html.Widget.Panels;
using NeuroSystem.Workflow.UserData.UI.Html.Widgets.Panels;

namespace NeuroSystem.Workflow.UserData.UI.Html.Fluent.Panels
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


        public PanelFactory<T> AddPanel(Action<PanelFactory<T>> panel)
        {
            var factory = new PanelFactory<T>();
            Panel.Elementy.Add(factory.Panel);

            panel(factory);
            return this;
        }

        public DataFormFactory<T> AddDataForm(Action<DataFormFactory<T>> panel)
        {
            var factory = new DataFormFactory<T>();

            Panel.Elementy.Add(factory.Panel);

            panel(factory);
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

    }
}
