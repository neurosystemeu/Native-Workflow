using System.Collections.Generic;

namespace NeuroSystem.Workflow.UserData.UI.Html.Mvc.UI
{
    public class Panel : WidgetBase
    {
        public Panel(string name):this()
        {
            Name = name;
        }

        public Panel()
        {
            Items = new List<WidgetBase>();
        }

        public List<WidgetBase> Items { get; set; }

        public string HtmlContent { get;  set; }
    }

    public class Panel<T> : Panel
    {
    }
}
