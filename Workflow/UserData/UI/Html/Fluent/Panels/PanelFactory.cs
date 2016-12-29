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
    public class PanelFactory : WidgetFactory
    {
    }

    public class PanelFactory<T> : PanelFactory
    {
        public Panel Panel { get; set; }

        public PanelFactory()
        {
            Panel = new Panel();
        }

        public PanelFactory<T> Height(string height)
        {
            Panel.Height = height;
            return this;
        }

        public PanelFactory<T> Width(string width)
        {
            Panel.Width = width;
            return this;
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

        public PanelFactory<T> CssClass(string f)
        {
            Panel.CssClass = f;
            return this;
        }


        public PanelFactory<T> DodajPanel(Action<PanelFactory<T>> panel)
        {
            var panelFactory = new PanelFactory<T>();
            Panel.Elementy.Add(panelFactory.Panel);

            panel(panelFactory);
            
            return this;
        }

        public PanelFactory<T> DodajDataForm(Action<DataFormFactory<T>> panel)
        {
            var gridColumnFactory = new DataFormFactory<T>();
            Elementy.Add(gridColumnFactory);

            panel(gridColumnFactory);

            return this;
        }

    }
}
