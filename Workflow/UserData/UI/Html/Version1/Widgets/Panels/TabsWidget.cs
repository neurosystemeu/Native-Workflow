using System.Collections.Generic;

namespace NeuroSystem.Workflow.UserData.UI.Html.Version1.Widgets.Panels
{
    public class TabsWidget : WidgetBase
    {
        public TabsWidget()
        {
            Tabs = new List<Tab>();
        }

        public List<Tab> Tabs { get; set; }

        public override void SetDataContext(object dataContext)
        {
            foreach (var tab in Tabs)
            {
                tab.SetDataContext(dataContext);
            }
        }
    }
}
