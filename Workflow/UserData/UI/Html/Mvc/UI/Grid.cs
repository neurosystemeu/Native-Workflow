using System.Collections.Generic;

namespace NeuroSystem.Workflow.UserData.UI.Html.Mvc.UI
{
    public class Grid : WidgetBase
    {
        public DataSource DataSource { get; set; }

        public List<GridColumn> Columns { get; set; }
        public string DataSourceFilter { get; internal set; }

        public Grid()
        {
            Columns = new List<GridColumn>();
            DataSource = new DataSource();
        }
    }

    /// <summary>
    /// The server side wrapper for Kendo UI Grid
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Grid<T> : Grid
        where T : class
    {
        
        
    }
}
