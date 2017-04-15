namespace NeuroSystem.Workflow.UserData.UI.Html.Mvc.Widgets
{
    public class Grid : WidgetBase
    {
        public DataSource DataSource { get; set; }

        public Grid()
        {
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
