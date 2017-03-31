using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NeuroSystem.Workflow.UserData.UI.Html.Version1.ViewModel;
using NeuroSystem.Workflow.UserData.UI.Html.Version1.Widgets;
using NeuroSystem.Workflow.UserData.UI.Html.Version1.Widgets.DataForms;
using NeuroSystem.Workflow.UserData.UI.Html.Version1.Widgets.DataWidgets;
using Telerik.Web.UI;

namespace NeuroSystem.Workflow.UserData.UI.Html.ASP.UI.Html.Widgets.DataForms
{
    public class NsDateTimePicker : RadDateTimePicker, IBindingControl
    {
        public WidgetBase Widget { get; set; }

        public void LoadToControl()
        {
            var dataWidget = Widget as DataWidget;
            var date = (DateTime?)Binding.PobierzWartosc(dataWidget.Value, dataWidget.DataContext);
            if (date == DateTime.MinValue)
            {
                SelectedDate = DateTime.Now;
            }
            else
            {
                SelectedDate = date;
            }
        }

        public void SaveFromControl()
        {
            var dataWidget = Widget as DateTimePicker;
            var binding = dataWidget.Value;
            Binding.UstawWartosc(ref binding, dataWidget.DataContext, SelectedDate);
            dataWidget.Value = binding; //w binding może być wartość - dane bez bindowania
        }

        internal static NsDateTimePicker UtworzDate(WidgetBase opisDataICzas)
        {
            return new NsDateTimePicker() { Widget = opisDataICzas };
        }
    }
}
