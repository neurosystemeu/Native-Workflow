using System.Collections.Generic;
using NeuroSystem.Workflow.UserData.UI.Html.Widgets.DataWidgets;

namespace NeuroSystem.Workflow.UserData.UI.Html.Widgets.ItemsWidgets
{
    public class GridView : ItemsWidget
    {
        public GridView()
        {
            Columns =new List<GridViewColumn>();
            AllowPaging = true;
            PageSize = 20;
        }

        public List<GridViewColumn> Columns { get; set; }

        public bool AllowPaging { get; set; }
        public bool AllowEditing { get; set; }
        public int PageSize { get; set; }
        public bool AllowFilteringByColumn { get; set; }
    }
}
