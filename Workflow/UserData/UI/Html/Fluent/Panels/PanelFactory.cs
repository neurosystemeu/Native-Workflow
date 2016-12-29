using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using NeuroSystem.Workflow.UserData.UI.Html.Widget.Panels;

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

        public PanelFactory(ViewFactory<T> viewFactory)
        {
            this.viewFactory = viewFactory;
            Elementy = new List<WidgetFactory>();
        }

        public PanelFactory(PanelFactory<T> panelFactory)
        {
            this.panelFactory = panelFactory;
            Elementy = new List<WidgetFactory>();
        }

        

        public PanelFactory<T> Pole<TD>(Expression<Func<T, TD>> nazwaPola)
        {
            var member = (nazwaPola.Body as MemberExpression).Member as System.Reflection.PropertyInfo;
            var nazwa = member.Name;
            
            Elementy.Add(new WidgetFactory() {Label = nazwa});
            return this;
        }

        public PanelFactory<T> DodajPanel(Action<PanelFactory<T>> panels)
        {
            PanelFactory<T> gridColumnFactory = new PanelFactory<T>(this);
            Elementy.Add(gridColumnFactory);

            panels(gridColumnFactory);
            
            return this;
        }
    }
}
