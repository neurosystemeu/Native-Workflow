using System.Collections.Generic;

namespace NeuroSystem.Workflow.UserData.UI.Html.Widgets.Panels
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
