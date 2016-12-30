using NeuroSystem.Workflow.UserData.UI.Html.Fluent.Widgets.DataWidgets;
using NeuroSystem.Workflow.UserData.UI.Html.Widgets.ItemsWidgets;

namespace NeuroSystem.Workflow.UserData.UI.Html.Fluent.Widgets.DataForms
{
    public class ComboBoxFactory<T> : ItemsWidgetsFactory<T>
    {
        public ComboBox ComboBox => Widget as ComboBox;
    }
}
