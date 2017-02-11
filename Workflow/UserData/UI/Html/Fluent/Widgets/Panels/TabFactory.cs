using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NeuroSystem.Workflow.UserData.UI.Html.Widgets.Panels;

namespace NeuroSystem.Workflow.UserData.UI.Html.Fluent.Widgets.Panels
{
    public class TabFactory<T> : PanelFactory<T>
    {
        public TabFactory()
        {
            Widget = new Tab();
        }

        public Tab Tab => Panel as Tab;
    }
}
