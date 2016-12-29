using System.Collections.Generic;
using NeuroSystem.Workflow.UserData.UI.Html.Widgets.ItemsWidgets;

namespace NeuroSystem.Workflow.UserData.UI.Html.Widget.ItemsWidget
{
    public class GridView : Data.ItemsWidget
    {
        public GridView()
        {
            Columns =new List<GridViewColumn>();
        }

        public List<GridViewColumn> Columns { get; set; }
    }
}
