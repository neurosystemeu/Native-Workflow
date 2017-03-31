using System;
using System.Linq.Expressions;
using NeuroSystem.Workflow.UserData.UI.Html.Version1.DataSources;
using NeuroSystem.Workflow.UserData.UI.Html.Version1.Fluent.Widgets.DataWidgets;
using NeuroSystem.Workflow.UserData.UI.Html.Version1.Widgets;

namespace NeuroSystem.Workflow.UserData.UI.Html.Version1.Fluent.Views
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

        public WidgetBase AddField<TD>(Expression<Func<T, TD>> nazwaPola, string tooltip = null)
        {
            return ActiveDataForm.AddField(nazwaPola, tooltip); ;
        }

        public DataFormFactory<T> AddComboBox<TD>(Expression<Func<T, TD>> nazwaPola,
            string tooltip = null,
            DataSourceBase dataSource = null,
            bool loadOnDemand = false)
        {
            ActiveDataForm.AddComboBox(nazwaPola, tooltip, dataSource, loadOnDemand);
            return this;
        }

        public AutoCompleteFactory<T> AddAutoComplete<TD>(Expression<Func<T, TD>> nazwaPolaId, Expression<Func<T, TD>> nazwaPolaNames, string tooltip = null, DataSourceBase dataSource = null)
        {
            return ActiveDataForm.AddAutoComplete(nazwaPolaId, nazwaPolaNames, tooltip, dataSource);
        }
    }
}
