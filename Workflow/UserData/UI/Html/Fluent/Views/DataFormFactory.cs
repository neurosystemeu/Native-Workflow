using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using NeuroSystem.Workflow.UserData.UI.Html.DataSources;
using NeuroSystem.Workflow.UserData.UI.Html.Fluent.Widgets.DataForms;
using NeuroSystem.Workflow.UserData.UI.Html.Fluent.Widgets.Panels;
using NeuroSystem.Workflow.UserData.UI.Html.Views;
using NeuroSystem.Workflow.UserData.UI.Html.Widgets.Panels;

namespace NeuroSystem.Workflow.UserData.UI.Html.Fluent.Views
{
    public class DataFormFactory<T> : ViewFactory<T>
    {
        public Widgets.Panels.DataFormFactory<T> ActiveDataForm { get; set; }

        public DataFormFactory<T> DataForm(Action<Widgets.Panels.DataFormFactory<T>> panel)
        {
            var factory = new Widgets.Panels.DataFormFactory<T>();
            panel(factory);
            mainPanel.Elementy.Add(factory.DataForm);
            return this;
        }

        public PanelFactory<T> AddField<TD>(Expression<Func<T, TD>> nazwaPola, string tooltip = null)
        {
            return ActiveDataForm.AddField(nazwaPola, tooltip);
        }

        public DataFormFactory<T> AddComboBox<TD>(Expression<Func<T, TD>> nazwaPola, string tooltip = null, DataSourceBase dataSource = null)
        {
            ActiveDataForm.AddComboBox(nazwaPola, tooltip, dataSource);
            return this;
        }
    }
}
