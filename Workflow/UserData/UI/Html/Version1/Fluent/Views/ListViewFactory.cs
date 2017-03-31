using NeuroSystem.Workflow.UserData.UI.Html.Version1.DataSources;
using NeuroSystem.Workflow.UserData.UI.Html.Version1.Fluent.Widgets.DataWidgets;

namespace NeuroSystem.Workflow.UserData.UI.Html.Version1.Fluent.Views
{
    public class ListViewFactory<T> : ViewFactory<T>
    {
        public GridViewFactory<T> Grid { get; set; }

        public ListViewFactory<T> DataSource(DataSourceBase dataSource)
        {
            Grid.DataSource(dataSource);
            return this;
        }
    }
}
