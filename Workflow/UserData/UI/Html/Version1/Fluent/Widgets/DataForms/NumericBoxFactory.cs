using NeuroSystem.Workflow.UserData.UI.Html.Version1.Widgets.DataForms;

namespace NeuroSystem.Workflow.UserData.UI.Html.Version1.Fluent.Widgets.DataForms
{
    public class NumericBoxFactory<T> : WidgetFactory<T>
    {
        public NumericBox NumericBox => Widget as NumericBox;
    }
}
