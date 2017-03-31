using NeuroSystem.Workflow.UserData.UI.Html.Version1.ViewModel;
using NeuroSystem.Workflow.UserData.UI.Html.Version1.Widgets;
using NeuroSystem.Workflow.UserData.UI.Html.Version1.Widgets.DataForms;
using NeuroSystem.Workflow.UserData.UI.Html.Version1.Widgets.DataWidgets;
using Telerik.Web.UI;

namespace NeuroSystem.Workflow.UserData.UI.Html.ASP.UI.Html.Version1.Widgets.DataForms
{
    public class NsEdytor : RadEditor, IBindingControl
    {
        public WidgetBase Widget { get; set; }

        public void LoadToControl()
        {
            var dataWidget = Widget as DataWidget;
            if (dataWidget != null)
            {
                var val = Binding.PobierzWartosc(dataWidget.Value, Widget.DataContext);
                Text = val?.ToString();
            }
        }

        public void SaveFromControl()
        {
            var dataWidget = Widget as Edytor;
            var binding = dataWidget.Value;
            Binding.UstawWartosc(ref binding, dataWidget.DataContext, Text);
            dataWidget.Value = binding; //w binding może być wartość - dane bez bindowania
        }

        internal static NsEdytor UtworzTextBox(Edytor widget)
        {
            return new NsEdytor() { Widget = widget };
        }
    }
}
