using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NeuroSystem.Workflow.UserData.UI.Html.Widgets;

namespace NeuroSystem.Workflow.UserData.UI.Html.Builders
{
    public class PanelBuilder<T> : PanelBuilder
    {
        public PanelBuilder(Panel<T> component) : base(component)
        {
        }
    }
}
