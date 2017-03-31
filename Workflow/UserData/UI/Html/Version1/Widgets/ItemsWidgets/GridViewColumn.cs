namespace NeuroSystem.Workflow.UserData.UI.Html.Version1.Widgets.ItemsWidgets
{
    public class GridViewColumn : WidgetBase
    {
        public bool ShowColumnFilter { get; set; }
        public GridKnownFunction FilterFunction { get; set; }
        public GridAggregateFunction Aggregate { get; set; }
        public GridColumnType ColumnType { get; set; }
        public string DataTypeName { get; set; }
        public string DataFormatString { get; set; }
        public string FilterDefaultValue { get; set; }
        public bool ReadOnly { get; set; }
    }
}
