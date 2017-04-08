using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuroSystem.Workflow.UserData.UI.Html.Widgets
{
    public class Panel : WidgetBase
    {
        public Panel()
        {
            Items = new List<WidgetBase>();
        }

        public List<WidgetBase> Items { get; set; } 
    }
}
