using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuroSystem.Workflow.UserData.UI.Html.Mvc.UI
{
    public class Label : WidgetBase
    {
        public string Content { get; set; }

        internal void For(string name)
        {
            HtmlAttributes.Add("for", name);
        }
    }
}
