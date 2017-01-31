using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuroSystem.Workflow.UserData.UI.Html.Widgets.Actions
{
    public class Action : WidgetBase
    {
        public string Group { get; set; }
        public string Tab { get; set; }
        public string IconUrl { get; set; }
        public EnumActionSize Size { get; set; }
        public EnumActionPosition Position { get; set; }

        public IViewer Viewer { get; set; }
    }
}
