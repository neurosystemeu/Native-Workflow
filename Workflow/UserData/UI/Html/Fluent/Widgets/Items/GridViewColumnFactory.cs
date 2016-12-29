using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NeuroSystem.Workflow.UserData.UI.Html.Widgets.ItemsWidgets;

namespace NeuroSystem.Workflow.UserData.UI.Html.Fluent.Widgets.Items
{
    public class GridViewColumnFactory<T> : WidgetFactory
    {
        public GridViewColumnFactory()
        {
            Column = new GridViewColumn();
        }

        public GridViewColumn Column { get; set; }

        public GridViewColumnFactory<T> Width(string width)
        {
            Column.Width = width;
            return this;
        }

        public GridViewColumnFactory<T> Label(string label)
        {
            Column.Label = label;
            return this;
        }
    }
}
