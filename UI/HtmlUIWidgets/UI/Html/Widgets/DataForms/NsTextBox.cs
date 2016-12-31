using NeuroSystem.Workflow.UserData.UI.Html.ViewModel;
using NeuroSystem.Workflow.UserData.UI.Html.Widgets;
using NeuroSystem.Workflow.UserData.UI.Html.Widgets.DataForms;
using NeuroSystem.Workflow.UserData.UI.Html.Widgets.DataWidgets;
using Telerik.Web.UI;

namespace NeuroSystem.Workflow.UserData.UI.Html.ASP.UI.Html.Widgets
{
    public class NsTextBox : RadTextBox, IBindingControl
    {
        public WidgetBase Widget { get; set; }

        public void WczytajDoKontrolkiZMW()
        {
            var dataWidget = Widget as DataWidget;
            if (dataWidget != null)
            {
                var val = Binding.PobierzWartosc(dataWidget.Value, Widget.DataContext);
                Text = val?.ToString();
            }
        }

        public void ZapiszDoMWZKontrolki()
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
