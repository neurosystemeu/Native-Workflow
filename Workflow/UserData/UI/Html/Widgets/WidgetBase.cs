namespace NeuroSystem.Workflow.UserData.UI.Html.Widget
{
    public class WidgetBase
    {
        public string Name { get; set; }
        public object Label { get; set; }
        public string ToolTip { get; set; }

        public object Width { get; set; }
        public object Height { get; set; }
        public object CssClass { get; set; }

        public object DataContext { get; set; }

        public string GetReadableName()
        {
            return Name;
        }
    }
}
