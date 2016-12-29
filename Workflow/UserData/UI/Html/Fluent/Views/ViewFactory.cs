using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NeuroSystem.Workflow.UserData.UI.Html.Fluent.Panels;
using NeuroSystem.Workflow.UserData.UI.Html.Widget;

namespace NeuroSystem.Workflow.UserData.UI.Html.Fluent
{
    public class ViewFactory<T> : WidgetFactory<T>
    {
        public ViewFactory()
        {
            Panele = new List<WidgetBase>();
            Widget = new WidgetBase();
        }

        public List<WidgetBase> Panele { get; set; }

        public ViewFactory<T> AddPanel(Action<PanelFactory<T>> panel)
        {
            var factory = new PanelFactory<T>();
            panel(factory);
            Panele.Add(factory.Panel);
            return this;
        }

        public ViewFactory<T> AddDataForm(Action<DataFormFactory<T>> panel)
        {
            var factory = new DataFormFactory<T>();
            panel(factory);
            Panele.Add(factory.Panel);
            return this;
        }
    }
}
