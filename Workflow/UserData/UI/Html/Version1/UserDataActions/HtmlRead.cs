using NeuroSystem.Workflow.UserData.UI.Html.Version1.Widgets.Panels;

namespace NeuroSystem.Workflow.UserData.UI.Html.Version1.UserDataActions
{
    public class HtmlRead
    {
        public Panel Panel { get; set; }
        public object DataContext => Panel?.DataContext;
        public string ActionName { get; set; }
    }
}
