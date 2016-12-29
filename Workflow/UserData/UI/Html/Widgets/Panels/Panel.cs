using System.Collections.Generic;

namespace NeuroSystem.Workflow.UserData.UI.Html.Widget.Panels
{
    public class Panel : WidgetBase
    {
        public Panel()
        {
            Elementy = new List<WidgetBase>();
        }

        public EnumPanelOrientation Orientation { get; set; }
        public List<WidgetBase> Elementy { get; set; }
    }
}
