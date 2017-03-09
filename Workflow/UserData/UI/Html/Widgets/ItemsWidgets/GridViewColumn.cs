using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuroSystem.Workflow.UserData.UI.Html.Widgets.ItemsWidgets
{
    public class GridViewColumn : WidgetBase
    {
        public bool ShowColumnFilter { get; set; }
        public GridKnownFunction FilterFunction { get; set; }
        public GridAggregateFunction Aggregate { get; set; }
        public string DataFormatString { get; set; }
        public string FilterDefaultValue { get; set; }
    }
}
