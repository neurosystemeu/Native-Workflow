using NeuroSystem.Workflow.UserData.UI.Html.Version1.Widgets;

namespace NeuroSystem.Workflow.UserData.UI.Html.ASP.UI.Html.Widgets
{
    public interface IBindingControl : IWidgetControl
    {
        void LoadToControl();
        void SaveFromControl();
    }
}
