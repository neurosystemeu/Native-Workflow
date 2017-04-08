using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuroSystem.Workflow.UserData.UI.Html.Widgets
{
    public class TextBox : WidgetBase
    {
        public bool Enabled { get; set; }

        public string Format { get; set; }

        public TextBox()
        {
            this.Enabled = true;
        }
    }

    public class TextBox<T> : TextBox
    {
        public T Value { get; set; }
    }
}
