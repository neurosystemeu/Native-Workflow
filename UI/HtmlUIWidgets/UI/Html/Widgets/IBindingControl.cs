using NeuroSystem.Workflow.UserData.UI.Html.Widgets;

namespace NeuroSystem.Workflow.UserData.UI.Html.ASP.UI.Html.Widgets
{
    public interface IBindingControl : IWidgetControl
    {
        void LoadToControl();
        void SaveFromControl();
    }
}
