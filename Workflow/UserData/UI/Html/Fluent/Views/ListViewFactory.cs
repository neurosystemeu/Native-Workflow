using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NeuroSystem.Workflow.UserData.UI.Html.DataSources;
using NeuroSystem.Workflow.UserData.UI.Html.Fluent.DataSources;
using NeuroSystem.Workflow.UserData.UI.Html.Fluent.Widgets.DataWidgets;
using NeuroSystem.Workflow.UserData.UI.Html.Widgets.DataWidgets;

namespace NeuroSystem.Workflow.UserData.UI.Html.Fluent.Views
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
