using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NeuroSystem.Workflow.UserData.UI.Html.ViewModel;
using NeuroSystem.Workflow.UserData.UI.Html.Widgets;
using NeuroSystem.Workflow.UserData.UI.Html.Widgets.DataForms;
using NeuroSystem.Workflow.UserData.UI.Html.Widgets.DataWidgets;
using Telerik.Web.UI;

namespace NeuroSystem.Workflow.UserData.UI.Html.ASP.UI.Html.Widgets.DataForms
{
    public class NsEdytor : RadEditor, IBindingControl
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
