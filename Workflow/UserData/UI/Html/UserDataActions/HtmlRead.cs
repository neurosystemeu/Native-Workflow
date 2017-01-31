using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NeuroSystem.Workflow.UserData.UI.Html.Widgets.Panels;

namespace NeuroSystem.Workflow.UserData.UI.Html.UserDataActions
{
    public class HtmlRead
    {
        public Panel Panel { get; set; }
        public object DataContext => Panel?.DataContext;
        public string ActionName { get; set; }
    }
}
