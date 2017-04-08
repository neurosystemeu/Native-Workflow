using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NeuroSystem.Workflow.UserData.UI.Html.Widgets;

namespace NeuroSystem.Workflow.UserData.UI.Html.Builders
{
    public class ButtonBuilder : WidgetBuilderBase<Button, ButtonBuilder>
    {
        public ButtonBuilder(Button component) : base(component)
        {
        }
    }
}
