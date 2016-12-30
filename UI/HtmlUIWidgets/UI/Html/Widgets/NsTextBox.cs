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
            var data = Widget as DataWidget;
            if (data != null)
            {
                var val = Binding.PobierzWartosc(data.Value, Widget.DataContext);
                Text = val?.ToString();
            }
        }

        public void ZapiszDoMWZKontrolki()
        {
            
        }

        internal static NsTextBox UtworzTextBox(TextBox widget)
        {
            return new NsTextBox() { Widget = widget};
        }
    }
}
