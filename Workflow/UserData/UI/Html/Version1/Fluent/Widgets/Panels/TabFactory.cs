using NeuroSystem.Workflow.UserData.UI.Html.Version1.Widgets.Panels;

namespace NeuroSystem.Workflow.UserData.UI.Html.Version1.Fluent.Widgets.Panels
{
    public class TabFactory<T> : PanelFactory<T>
    {
        public TabFactory()
        {
            Widget = new Tab();
        }

        public Tab Tab => Panel as Tab;
    }
}
