using NeuroSystem.Workflow.UserData.UI.Html.Version1.Widgets.ItemsWidgets;

namespace NeuroSystem.Workflow.UserData.UI.Html.Version1.Fluent.Widgets.DataWidgets
{
    public class ComboBoxFactory<T> : ItemsWidgetsFactory<T>
    {
        public ComboBox ComboBox => Widget as ComboBox;
    }
}
