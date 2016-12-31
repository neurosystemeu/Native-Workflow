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
    public class NsAutoComplete : RadAutoCompleteBox, IBindingControl
    {
        public WidgetBase Widget { get; set; }

        public void WczytajDoKontrolkiZMW()
        {
            var dataWidget = Widget as AutoCompleteBox;
            var ids = (string)Binding.PobierzWartosc(dataWidget.SelectedIds, dataWidget.DataContext);
            var names = (string)Binding.PobierzWartosc(dataWidget.SelectedNames, dataWidget.DataContext);
            var idsList = ids.Split(';');
            var namesList = names.Split(';');
            int i = 0;
            foreach (var u in idsList)
            {
                if (string.IsNullOrEmpty(u))
                {
                    i++;
                    continue;
                }
                if (dataWidget.SelectedNames == dataWidget.SelectedIds)
                {
                    this.Entries.Add(new AutoCompleteBoxEntry(u, u));
                }
                else
                {
                    var nazwa = namesList[i];
                    this.Entries.Add(new AutoCompleteBoxEntry(nazwa, u));
                }
                i++;
            }

        }

        public void ZapiszDoMWZKontrolki()
        {
            var ids = new List<string>();
            var nazwy = new List<string>();

            foreach (AutoCompleteBoxEntry prac in this.Entries)
            {
                ids.Add(prac.Value);
                nazwy.Add(prac.Text);
            }
            var idstr = string.Join(";", ids);
            var nazwystr = string.Join(";", nazwy);

            var dataWidget = Widget as AutoCompleteBox;
            var binding = dataWidget.SelectedIds;
            Binding.UstawWartosc(ref binding, dataWidget.DataContext, idstr);
            dataWidget.SelectedIds = binding; //w binding może być wartość - dane bez bindowania

            binding = dataWidget.SelectedNames;
            Binding.UstawWartosc(ref binding, dataWidget.DataContext, nazwystr);
            dataWidget.SelectedNames = binding; //w binding może być wartość - dane bez bindowania
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
            return cb;
        }
    }
}
