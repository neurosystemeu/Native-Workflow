using NeuroSystem.Workflow.UserData.UI.Html.Version1.Widgets.ItemsWidgets;

namespace NeuroSystem.Workflow.UserData.UI.Html.Version1.Fluent.Widgets.DataWidgets
{
    public class TreeComboBoxFactory<T> : ItemsWidgetsFactory<T>
    {
        public TreeComboBox TreeComboBox => Widget as TreeComboBox;
    }
}
