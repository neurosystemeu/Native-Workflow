using NeuroSystem.Workflow.UserData.UI.Html.Version1.Widgets.ItemsWidgets;

namespace NeuroSystem.Workflow.UserData.UI.Html.Version1.Fluent.Widgets.DataWidgets
{
    public class GridViewColumnFactory<T> : WidgetFactory
    {
        public GridViewColumnFactory()
        {
            Column = new GridViewColumn();
        }

        public GridViewColumn Column { get; set; }

        public GridViewColumnFactory<T> Width(string width)
        {
            Column.Width = width;
            return this;
        }

        public GridViewColumnFactory<T> ShowColumnFilter(bool show = true)
        {
            Column.ShowColumnFilter = show;
            return this;
        }

        public GridViewColumnFactory<T> Label(string label)
        {
            Column.Label = label;
            return this;
        }
    }
}
