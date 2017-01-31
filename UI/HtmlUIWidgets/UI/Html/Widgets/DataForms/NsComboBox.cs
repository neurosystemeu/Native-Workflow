using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NeuroSystem.Workflow.UserData.UI.Html.ViewModel;
using NeuroSystem.Workflow.UserData.UI.Html.Widgets;
using NeuroSystem.Workflow.UserData.UI.Html.Widgets.DataWidgets;
using NeuroSystem.Workflow.UserData.UI.Html.Widgets.ItemsWidgets;
using Telerik.Web.UI;

namespace NeuroSystem.Workflow.UserData.UI.Html.ASP.UI.Html.Widgets.DataForms
{
    public class NsComboBox : RadComboBox, IBindingControl
    {
        public WidgetBase Widget { get; set; }

        public void LoadToControl()
        {
            var dataWidget = Widget as ComboBox;
            var date = Binding.PobierzWartosc(dataWidget.SelectedValue, dataWidget.DataContext);
            SelectedValue = date?.ToString();
        }

        public void SaveFromControl()
        {
            var dataWidget = Widget as ComboBox;
            var binding = dataWidget.SelectedValue;
            Binding.UstawWartosc(ref binding, dataWidget.DataContext, SelectedValue);
            dataWidget.SelectedValue = binding; //w binding może być wartość - dane bez bindowania
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (Page.IsPostBack == false)
            {
                var dataWidget = Widget as ComboBox;
                DataSource = dataWidget.GetAllData();
                DataBind();
            }
        }

        internal static NsComboBox UtworzComboBox(ComboBox opisPola)
        {
            var cb = new NsComboBox() { Widget = opisPola, ToolTip = opisPola.ToolTip };
            cb.DataValueField = opisPola.DataValueField;
            cb.DataTextField = opisPola.DataTextField;

            return cb;
        }
    }
}
