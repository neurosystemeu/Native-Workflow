using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NeuroSystem.Workflow.UserData.UI.Html.ViewModel;
using NeuroSystem.Workflow.UserData.UI.Html.Widgets;
using NeuroSystem.Workflow.UserData.UI.Html.Widgets.ItemsWidgets;
using Telerik.Web.UI;

namespace NeuroSystem.Workflow.UserData.UI.Html.ASP.UI.Html.Widgets.DataForms
{
    public class NsTreeView : RadTreeView, IBindingControl
    {
        public NsTreeView()
        {
            
        }
        public WidgetBase Widget { get; set; }

        public void WczytajDoKontrolkiZMW()
        {
            var dataWidget = Widget as TreeView;
            var date = Binding.PobierzWartosc(dataWidget.SelectedValue, dataWidget.DataContext);
            //SelectedValue = date?.ToString();
        }

        public void ZapiszDoMWZKontrolki()
        {
            var dataWidget = Widget as TreeView;
            var binding = dataWidget.SelectedValue;
            Binding.UstawWartosc(ref binding, dataWidget.DataContext, SelectedValue);
            dataWidget.SelectedValue = binding; //w binding może być wartość - dane bez bindowania
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (Page.IsPostBack == false)
            {
                var dataWidget = Widget as TreeView;
                if (dataWidget.AutoLoadDataSource)
                {
                    DataSource = dataWidget.GetAllData();
                    DataBind();
                }
            }
        }

        internal static NsTreeView UtworzTreeView(TreeView opisPola)
        {
            var cb = new NsTreeView()
            {
                Widget = opisPola, ToolTip = opisPola.ToolTip,
                DataFieldID = opisPola.DataIdField,
                DataFieldParentID = opisPola.DataFieldParentId,
                DataTextField = opisPola.DataTextField,
                DataValueField = opisPola.DataValueField
            };
            return cb;
        }
    }
}
