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
        private ViewFactory<T> viewFactory;
        private PanelFactory<T> panelFactory;

        public List<WidgetFactory> Elementy { get; set; }
        public Panel Panel { get; set; }

        public PanelFactory()
        {
            Panel = new Panel();
        }

        public PanelFactory(ViewFactory<T> viewFactory)
        {
            this.viewFactory = viewFactory;
            Elementy = new List<WidgetFactory>();
            Panel = new Panel();
        }

        public PanelFactory(PanelFactory<T> panelFactory)
        {
            this.panelFactory = panelFactory;
            Elementy = new List<WidgetFactory>();
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
            PanelFactory<T> gridColumnFactory = new PanelFactory<T>(this);
            Elementy.Add(gridColumnFactory);

            panel(gridColumnFactory);
            
            return this;
        }

        public PanelFactory<T> DodajDataForm(Action<DataFormFactory<T>> panel)
        {
            DataFormFactory<T> gridColumnFactory = new DataFormFactory<T>();
            Elementy.Add(gridColumnFactory);

            panel(gridColumnFactory);

            return this;
        }

    }
}
