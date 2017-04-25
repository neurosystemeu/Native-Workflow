using System;
using NeuroSystem.Workflow.UserData.UI.Html.Version1.DataSources;
using NeuroSystem.Workflow.UserData.UI.Html.Version1.ViewModel;
using NeuroSystem.Workflow.UserData.UI.Html.Version1.Widgets.ItemsWidgets;
using Telerik.Web.UI;

namespace NeuroSystem.Workflow.UserData.UI.Html.Version1.Widgets.DataForms
{
    public class NsComboBox : RadComboBox, IBindingControl
    {
        public WidgetBase Widget { get; set; }
        

        public void LoadToControl()
        {
            var dataWidget = Widget as ComboBox;
            var date = Binding.PobierzWartosc(dataWidget.SelectedValue, dataWidget.DataContext);
            if (dataWidget.LoadOnDemand && date != null)
            {
                //wczytywanie na rządanie - doczytuje wartość początkową
                var id = date;
                var obiekt = dataWidget.DataSource.GetObjectById(id.ToString());
                SelectedValue = id.ToString();
                Text = obiekt.ToString();
            }
            else
            {
                SelectedValue = date?.ToString();
            }
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
                if (dataWidget != null)
                {
                    if(dataWidget.LoadOnDemand == false)
                    {
                        DataSource = dataWidget.GetAllData();
                        DataBind();
                    }
                }
            }
        }

        internal static NsComboBox UtworzComboBox(ComboBox opisPola)
        {
            var cb = new NsComboBox() { Widget = opisPola, ToolTip = opisPola.ToolTip };
            cb.DataValueField = opisPola.DataValueField;
            cb.DataTextField = opisPola.DataTextField;
            
            if (opisPola.LoadOnDemand)
            {
                cb.EnableAutomaticLoadOnDemand = true;
                cb.WebServiceSettings.Path = opisPola.WebServiceSettingsPath;
                cb.WebServiceSettings.Method = opisPola.WebServiceSettingsMethod;
                cb.ShowMoreResultsBox = true;
                cb.EnableVirtualScrolling = true;
                cb.OnClientItemsRequesting = "OnClientItemsRequesting";
                var repository = opisPola.DataSource as RepositoryDataSourceBase;
                cb.Attributes.Add("data-rodzajProwajdera", repository.RepositoryName);
            }

            return cb;
        }
    }
}
