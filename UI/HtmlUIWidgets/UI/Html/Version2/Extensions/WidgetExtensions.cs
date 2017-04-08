using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NeuroSystem.Workflow.UserData.UI.Html.ASP.UI.Html.Version2.Widgets;
using NeuroSystem.Workflow.UserData.UI.Html.Widgets;

namespace NeuroSystem.Workflow.UserData.UI.Html.ASP.UI.Html.Version2.Extensions
{
    public static class WidgetExtensions
    {
        public static NsPanel ToControl(this WidgetBase widget)
        {
            if (widget is Panel)
            {
                return new NsPanel(widget as Panel);
            }
            return null;

        }
    }
}
