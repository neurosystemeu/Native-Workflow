namespace NeuroSystem.Workflow.UserData.UI.Html.Version1.Widgets
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

        public virtual void SetDataContext(object dataContext)
        {
            DataContext = dataContext;
        }

        public string GetReadableName()
        {
            return Label?.ToString() ?? Name;
        }

        public static string GetReadableName(string name)
        {
            return name;
        }
    }
}
