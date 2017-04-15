using System.Collections.Generic;

namespace NeuroSystem.Workflow.UserData.UI.Html.Mvc.Widgets
{
    public class Panel : WidgetBase
    {
        public Panel()
        {
            Items = new List<WidgetBase>();
        }

        public List<WidgetBase> Items { get; set; } 
    }

    public class Panel<T> : Panel
    {
    }
}
