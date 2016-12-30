using System.Collections.Generic;
using NeuroSystem.Workflow.UserData.UI.Html.Widgets.DataWidgets;

namespace NeuroSystem.Workflow.UserData.UI.Html.Widgets.ItemsWidgets
{
    public class GridView : ItemsWidget
    {
        public GridView()
        {
            Columns =new List<GridViewColumn>();
        }

        public List<GridViewColumn> Columns { get; set; }
    }
}
