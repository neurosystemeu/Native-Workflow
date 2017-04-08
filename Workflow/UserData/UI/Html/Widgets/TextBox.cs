using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuroSystem.Workflow.UserData.UI.Html.Widgets
{
    public class TextBox<T> : WidgetBase<T>
    {
        public bool Enabled { get; set; }

        public string Format { get; set; }

        public T Value { get; set; }

        public TextBox()
        {
            this.Enabled = true;
        }
    }
}
