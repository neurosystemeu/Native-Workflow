using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuroSystem.Workflow.UserData.UI.Html.Widgets.Panels
{
    public class TabsWidget : WidgetBase
    {
        public TabsWidget()
        {
            Tabs = new List<Tab>();
        }

        public List<Tab> Tabs { get; set; }
    }
}
