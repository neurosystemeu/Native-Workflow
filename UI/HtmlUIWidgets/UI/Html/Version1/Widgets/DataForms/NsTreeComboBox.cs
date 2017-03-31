using System;
using NeuroSystem.Workflow.UserData.UI.Html.Version1.ViewModel;
using NeuroSystem.Workflow.UserData.UI.Html.Version1.Widgets;
using NeuroSystem.Workflow.UserData.UI.Html.Version1.Widgets.ItemsWidgets;
using Telerik.Web.UI;

namespace NeuroSystem.Workflow.UserData.UI.Html.ASP.UI.Html.Version1.Widgets.DataForms
{
    public class NsTreeComboBox : RadDropDownTree, IBindingControl
    {
        public NsTreeComboBox()
        {
            DataTextField = "Nazwa";
            DataValueField = "Id";
            DataFieldID = "Id";
            DataFieldParentID = "RodzicId";
            DropDownSettings.Width = new System.Web.UI.WebControls.Unit("300px");
        }
        public WidgetBase Widget { get; set; }

        public void LoadToControl()
        {
            //var dataWidget = Widget as TreeComboBox;
            //var date = Binding.PobierzWartosc(dataWidget.SelectedValue, dataWidget.DataContext);
            //SelectedValue = date?.ToString();
        }

        public void SaveFromControl()
        {
            var dataWidget = Widget as TreeComboBox;
            var binding = dataWidget.SelectedValue;
            Binding.UstawWartosc(ref binding, dataWidget.DataContext, SelectedValue);
            dataWidget.SelectedValue = binding; //w binding może być wartość - dane bez bindowania
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (Page.IsPostBack == false)
            {
                var dataWidget = Widget as TreeComboBox;
                DataSource = dataWidget.GetAllData();
                DataBind();
            }
        }

        internal static NsTreeComboBox UtworzComboBox(TreeComboBox opisPola)
        {
            var cb = new NsTreeComboBox() { Widget = opisPola, ToolTip = opisPola.ToolTip };
            return cb;
        }
    }
}
