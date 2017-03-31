using System.Collections.Generic;
using NeuroSystem.Workflow.UserData.UI.Html.Version1.Widgets.DataWidgets;

namespace NeuroSystem.Workflow.UserData.UI.Html.Version1.Widgets.ItemsWidgets
{
    public class GridView : ItemsWidget
    {
        public GridView()
        {
            Columns =new List<GridViewColumn>();
            AllowPaging = true;
            PageSize = 50;
        }

        public const string DataFormatStringDecimalCurrency = "{0:### ### ### ##0.0}";

        public List<GridViewColumn> Columns { get; set; }

        public bool AllowFilteringByColumn { get; set; }
        public bool AllowSorting { get; set; }
        public bool AllowPaging { get; set; }
        public bool AllowEditing { get; set; }
        public bool GroupingEnabled { get; set; }
        public bool AggregateEnabled { get; set; }
        public int PageSize { get; set; }
        
    }
}
