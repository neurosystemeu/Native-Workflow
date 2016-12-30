using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NeuroSystem.Workflow.UserData.UI.Html.ViewModel;
using NeuroSystem.Workflow.UserData.UI.Html.Widget;
using NeuroSystem.Workflow.UserData.UI.Html.Widget.Data;
using NeuroSystem.Workflow.UserData.UI.Html.Widget.Simple;
using NeuroSystem.Workflow.UserData.UI.Html.Widgets;
using Telerik.Web.UI;

namespace NeuroSystem.UI.HtmlUIWidgets.AspUI.Html.Widgets.DataForm
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
