using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NeuroSystem.Workflow.UserData.UI.Html.Widget;

namespace NeuroSystem.Workflow.UserData.UI.Html.Widgets
{
    public interface IWidgetControl
    {
        WidgetBase Widget { get; set; }
    }
}
