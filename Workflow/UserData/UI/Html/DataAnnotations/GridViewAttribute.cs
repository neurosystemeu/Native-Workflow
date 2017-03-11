using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NeuroSystem.Workflow.UserData.UI.Html.Widgets.ItemsWidgets;

namespace NeuroSystem.Workflow.UserData.UI.Html.DataAnnotations
{
    public class GridViewAttribute : Attribute
    {
        public GridViewAttribute()
        {
            FilterFunction = GridKnownFunction.Contains;
        }

        public const string DataFormatStringDecimalCurrency = "{0:### ### ### ##0.0}";

        public string Label { get; set; }
        public int Order { get; set; }
        public GridKnownFunction FilterFunction { get; set; }
        public string FilterDefaultValue { get; set; }
        public string DataFormatString { get; set; }
        public GridAggregateFunction Aggregate { get; set; }
        public GridColumnType ColumnType { get; set; }
    }
}
