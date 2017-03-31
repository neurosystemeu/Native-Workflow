using Action = NeuroSystem.Workflow.UserData.UI.Html.Version1.Widgets.Actions.Action;

namespace NeuroSystem.Workflow.UserData.UI.Html.Version1.Fluent.Widgets.Actions
{
    public class ActionFactory<T> : WidgetFactory<T>
    {
        public Action Action => Widget as Action;

        public ActionFactory()
        {
            Widget = new Action();
        }
    }
}
