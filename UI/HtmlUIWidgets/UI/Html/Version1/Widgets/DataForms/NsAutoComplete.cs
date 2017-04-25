using System;
using System.Collections.Generic;
using NeuroSystem.Workflow.UserData.UI.Html.Version1.ViewModel;
using NeuroSystem.Workflow.UserData.UI.Html.Version1.Widgets.ItemsWidgets;
using Telerik.Web.UI;

namespace NeuroSystem.Workflow.UserData.UI.Html.Version1.Widgets.DataForms
{
    public class NsAutoComplete : RadAutoCompleteBox, IBindingControl
    {
        public WidgetBase Widget { get; set; }

        public void LoadToControl()
        {
            var dataWidget = Widget as AutoCompleteBox;
            var ids = (string)Binding.PobierzWartosc(dataWidget.SelectedValue, dataWidget.DataContext);
            var names = (string)Binding.PobierzWartosc(dataWidget.SelectedNames, dataWidget.DataContext);
            var idsList = ids?.Split(';');
            var namesList = names?.Split(';');
            int i = 0;
            if (idsList != null)
            {
                foreach (var u in idsList)
                {
                    if (string.IsNullOrEmpty(u))
                    {
                        i++;
                        continue;
                    }
                    if (dataWidget.SelectedNames == dataWidget.SelectedValue)
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

        }

        public void SaveFromControl()
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
            var binding = dataWidget.SelectedValue as object;
            Binding.UstawWartosc(ref binding, dataWidget.DataContext, idstr);
            dataWidget.SelectedValue = binding; //w binding może być wartość - dane bez bindowania

            binding = dataWidget.SelectedNames;
            Binding.UstawWartosc(ref binding, dataWidget.DataContext, nazwystr);
            dataWidget.SelectedNames = binding; //w binding może być wartość - dane bez bindowania
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            //if (Page.IsPostBack == false)
            {
                var dataWidget = Widget as AutoCompleteBox;
                DataSource = dataWidget.GetAllData();
                DataBind();
            }
        }

        internal static NsAutoComplete UtworzAutoComplete(AutoCompleteBox opisPola)
        {
            var cb = new NsAutoComplete() { Widget = opisPola, ToolTip = opisPola.ToolTip };
            cb.DataValueField = opisPola.DataValueField;
            cb.DataTextField = opisPola.DataTextField;
            return cb;
        }
    }
}
