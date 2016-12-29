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
        public Panel Panel { get; set; }

        public PanelFactory()
        {
            Panel = new Panel();
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
            var panelFactory = new PanelFactory<T>();
            Panel.Elementy.Add(panelFactory.Panel);

            panel(panelFactory);
            return this;
        }

        public DataFormFactory<T> AddDataForm(Action<DataFormFactory<T>> panel)
        {
            var formFactory = new DataFormFactory<T>();
            Panel.Elementy.Add(formFactory.Panel);

            panel(formFactory);
            return formFactory;
        }

        public PanelFactory<T2> AddDataForm<T2>(T2 dataContext, Action<DataFormFactory<T2>> panel)
        {
            var formFactory = new DataFormFactory<T2>();
            formFactory.DataContext(dataContext);
            Panel.Elementy.Add(formFactory.Panel);

            panel(formFactory);
            return formFactory;
        }

    }
}
