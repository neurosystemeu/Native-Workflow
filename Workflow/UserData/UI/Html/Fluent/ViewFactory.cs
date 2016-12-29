using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NeuroSystem.Workflow.UserData.UI.Html.Fluent.Panels;

namespace NeuroSystem.Workflow.UserData.UI.Html.Fluent
{
    //Opisuje widok
    public class ViewFactory : WidgetFactory
    {

    }

    public class ViewFactory<T> : ViewFactory
    {
        public ViewFactory()
        {
            Panele = new List<WidgetFactory>();
        }

        public List<WidgetFactory> Panele { get; set; }

        public ViewFactory<T> Panels(Action<PanelFactory<T>> panel)
        {
            PanelFactory<T> gridColumnFactory = new PanelFactory<T>(this);
            panel(gridColumnFactory);
            Panele.Add(gridColumnFactory);
            return this;
        }
    }
}
