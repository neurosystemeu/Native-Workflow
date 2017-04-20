using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuroSystem.Workflow.UserData.UI.Html.Mvc.UI
{
    public class Tabs : WidgetBase
    {
        public Tabs()
        {
            Items = new List<Tab>();
        }

        public IList<Tab> Items { get; set; }
    }
}
