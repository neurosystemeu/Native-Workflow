using NeuroSystem.Workflow.UserData.UI.Html.Version1.ViewModel;
using NeuroSystem.Workflow.UserData.UI.Html.Version1.Widgets.DataWidgets;
using Telerik.Web.UI;

namespace NeuroSystem.Workflow.UserData.UI.Html.Version1.Widgets.DataForms
{
    public class NsCheckBox : RadCheckBox, IBindingControl
    {
        public WidgetBase Widget { get; set; }

        public void LoadToControl()
        {
            var dataWidget = Widget as DataWidget;
            var date = (bool?)Binding.PobierzWartosc(dataWidget.Value, dataWidget.DataContext);
            Checked = date;
        }

        public void SaveFromControl()
        {
            var dataWidget = Widget as DataWidget;
            var binding = dataWidget.Value;
            Binding.UstawWartosc(ref binding, dataWidget.DataContext, Checked);
            dataWidget.Value = binding; //w binding może być wartość - dane bez bindowania
        }

        internal static NsCheckBox UtworzCheckBox(WidgetBase widget)
        {
            return new NsCheckBox() { Widget = widget, AutoPostBack = false};
        }
    }
}
