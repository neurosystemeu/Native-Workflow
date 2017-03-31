using NeuroSystem.Workflow.UserData.UI.Html.Version1.ViewModel;
using NeuroSystem.Workflow.UserData.UI.Html.Version1.Widgets;
using NeuroSystem.Workflow.UserData.UI.Html.Version1.Widgets.DataForms;
using NeuroSystem.Workflow.UserData.UI.Html.Version1.Widgets.DataWidgets;
using Telerik.Web.UI;

namespace NeuroSystem.Workflow.UserData.UI.Html.ASP.UI.Html.Widgets
{
    public class NsTextBox : RadTextBox, IBindingControl
    {
        public WidgetBase Widget { get; set; }

        public void LoadToControl()
        {
            var dataWidget = Widget as DataWidget;
            if (dataWidget != null)
            {
                var val = Binding.PobierzWartosc(dataWidget.Value, Widget.DataContext);
                if (val is decimal)
                {
                    Text = ((decimal)val).ToString("### ### ### ##0.0");
                }
                else
                {
                    Text = val?.ToString();
                }
            }
        }

        public void SaveFromControl()
        {
            var dataWidget = Widget as TextBox;
            var binding = dataWidget.Value;
            Binding.UstawWartosc(ref binding, dataWidget.DataContext, Text);
            dataWidget.Value = binding; //w binding może być wartość - dane bez bindowania
        }

        internal static NsTextBox UtworzTextBox(TextBox widget)
        {
            return new NsTextBox() { Widget = widget};
        }
    }
}
