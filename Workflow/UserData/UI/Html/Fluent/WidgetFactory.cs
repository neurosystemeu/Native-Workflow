using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuroSystem.Workflow.UserData.UI.Html.Fluent
{
    public class WidgetFactory
    {
        public string Label { get; set; }
    }

    public class WidgetFactory<T> : WidgetFactory
    {
        
    }
}
