using System;
using System.Linq.Expressions;
using NeuroSystem.Workflow.Core.Extensions;
using NeuroSystem.Workflow.UserData.UI.Html.Fluent.Widgets.DataForms;
using NeuroSystem.Workflow.UserData.UI.Html.Fluent.Widgets.DataWidgets;
using NeuroSystem.Workflow.UserData.UI.Html.ViewModel;
using NeuroSystem.Workflow.UserData.UI.Html.Widgets;
using NeuroSystem.Workflow.UserData.UI.Html.Widgets.DataForms;
using NeuroSystem.Workflow.UserData.UI.Html.Widgets.ItemsWidgets;
using NeuroSystem.Workflow.UserData.UI.Html.Widgets.Panels;
using NeuroSystem.Workflow.UserData.UI.Html.DataSources;

namespace NeuroSystem.Workflow.UserData.UI.Html.Fluent.Widgets.Panels
{
    public class DataFormFactory<T> : PanelFactory<T>
    {
        public DataFormFactory()
        {
            Widget = new DataForm();
        }

        public DataForm DataForm => ((DataForm)Panel);

        #region Controls

        public PanelFactory<T> AddField<TD>(Expression<Func<T, TD>> nazwaPola, string tooltip = null)
        {
            var member = (nazwaPola.Body as MemberExpression).Member as System.Reflection.PropertyInfo;
            return AddField(member, tooltip);
        }

        public PanelFactory<T> AddField(System.Reflection.PropertyInfo member, string tooltip = null)
        {
            var name = member.Name;

            WidgetBase widget = null;

            if (tooltip == null)
            {
                tooltip = member.GetPropertyDescription();
            }

            if (member.PropertyType == typeof(DateTime) || member.PropertyType == typeof(DateTime?))
            {
                widget = new DateTimePicker()
                {
                    Name = name,
                    Label = name,
                    Value = new Binding(name),
                    ToolTip = tooltip
                };
            }
            else if (member.PropertyType == typeof(bool))
            {
                widget = new CheckBox()
                {
                    Name = name,
                    Label = name,
                    Value = new Binding(name),
                    ToolTip = tooltip
                };
            } else if (member.PropertyType.IsEnum)
            {
                widget = new ComboBox()
                {
                    Name = name,
                    Label = name,
                    SelectedValue = new Binding(name),
                    DataSource = new EnumDataSource(member.PropertyType)
                };
            } else
            {
                widget = new TextBox()
                {
                    Name = name,
                    Label = name,
                    Value = new Binding(name),
                    ToolTip = tooltip
                };
            }
            

            Panel.Elementy.Add(widget);
            return this;
        }

        public ComboBoxFactory<T> AddComboBox<TD>(Expression<Func<T, TD>> nazwaPola, string tooltip = null, DataSourceBase dataSource= null)
        {
            var member = (nazwaPola.Body as MemberExpression).Member as System.Reflection.PropertyInfo;
            var name = member.Name;
            var cb = new ComboBox();
            cb.SetDefaultValues();

            var factory = new ComboBoxFactory<T>() { Widget = cb };
            factory.Widget.Name = name;
            cb.DataValueField = "Id";
            factory.ComboBox.SelectedValue = new Binding(name);
            Panel.Elementy.Add(factory.ComboBox);

            if (dataSource != null)
            {
                factory.DataSource(dataSource);
            }
            return factory;
        }

        public ComboBoxFactory<T> AddComboBox(string name)
        {
            var factory = new ComboBoxFactory<T>() {Widget = new ComboBox()};
            factory.ComboBox.SetDefaultValues();
            factory.Widget.Name = name;
            Panel.Elementy.Add(factory.ComboBox);
            return factory;
        }


        public AutoCompleteFactory<T> AddAutoComplete<TD>(Expression<Func<T, TD>> nazwaPolaId, Expression<Func<T, TD>> nazwaPolaNames, string tooltip = null, DataSourceBase dataSource = null)
        {
            var memberIds = (nazwaPolaId.Body as MemberExpression).Member as System.Reflection.PropertyInfo;
            var ids = memberIds.Name;

            var memberNames = (nazwaPolaNames.Body as MemberExpression).Member as System.Reflection.PropertyInfo;
            var names = memberNames.Name;

            var ac = new AutoCompleteBox();
            ac.SetDefaultValues();

            var factory = new AutoCompleteFactory<T>() { Widget = ac };
            factory.Widget.Name = ids;
            ac.DataValueField = "Id";
            factory.AutoComplete.SelectedValue = new Binding(ids);
            factory.AutoComplete.SelectedNames = new Binding(names);
            Panel.Elementy.Add(factory.AutoComplete);

            if (dataSource != null)
            {
                factory.DataSource(dataSource);
            }
            return factory;
        }


        public GridViewFactory<T> AddGridView(Action<GridViewFactory<T>> panel = null)
        {
            var factory = new GridViewFactory<T>() {Widget = new GridView() {Name = "grid"} };
            factory.GridView.SetDefaultValues();
            Panel.Elementy.Add(factory.GridView);

            if (panel != null)
            {
                panel(factory);
            }
            return factory;
        }

        public TreeViewFactory<T> AddTreeView()
        {
            var factory = new TreeViewFactory<T>() { Widget = new TreeView() };
            Panel.Elementy.Add(factory.TreeView);

            return factory;
        }

        public TreeComboBoxFactory<T> AddTreeComboBox()
        {
            var factory = new TreeComboBoxFactory<T>() { Widget = new TreeComboBox() };
            Panel.Elementy.Add(factory.Widget);
            
            return factory;
        }

        #endregion
    }
}
