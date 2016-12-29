using System.Collections.Generic;
using NeuroSystem.Workflow.UserData.UI.Html.Widgets.Panels;

namespace NeuroSystem.Workflow.UserData.UI.Html.Widget.Panels
{
    public class Panel : WidgetBase
    {
        public Panel()
        {
            Elementy = new List<WidgetBase>();
        }

        public EnumPanelFloat Float { get; set; }
        public EnumPanelClear Clear { get; set; }
        public EnumPanelOrientation Orientation { get; set; }
        public List<WidgetBase> Elementy { get; set; }
    }
}
