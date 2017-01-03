﻿using System;
using System.Linq.Expressions;
using NeuroSystem.Workflow.Core.Extensions;
using NeuroSystem.Workflow.UserData.UI.Html.Fluent.Widgets.DataForms;
using NeuroSystem.Workflow.UserData.UI.Html.Fluent.Widgets.DataWidgets;
using NeuroSystem.Workflow.UserData.UI.Html.ViewModel;
using NeuroSystem.Workflow.UserData.UI.Html.Widgets;
using NeuroSystem.Workflow.UserData.UI.Html.Widgets.DataForms;
using NeuroSystem.Workflow.UserData.UI.Html.Widgets.ItemsWidgets;
using NeuroSystem.Workflow.UserData.UI.Html.Widgets.Panels;

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
                    //TypPola = OpisTypu.UtworzOpisTypu(member.PropertyType),
                    //SelectedItemBinding = "{Binding Pola[\"" + nazwa + "\"]}",
                    //Opis = tooltip
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

        public ComboBoxFactory<T> AddComboBox<TD>(Expression<Func<T, TD>> nazwaPola, string tooltip = null)
        {
            var member = (nazwaPola.Body as MemberExpression).Member as System.Reflection.PropertyInfo;
            var name = member.Name;

            var factory = new ComboBoxFactory<T>() { Widget = new ComboBox() };
            factory.Widget.Name = name;
            factory.ComboBox.SelectedValue = new Binding(name);
            Panel.Elementy.Add(factory.ComboBox);
            return factory;
        }

        public ComboBoxFactory<T> AddComboBox(string name)
        {
            var factory = new ComboBoxFactory<T>() {Widget = new ComboBox()};
            factory.Widget.Name = name;
            Panel.Elementy.Add(factory.ComboBox);
            return factory;
        }

        public GridViewFactory<T> AddGridView(Action<GridViewFactory<T>> panel)
        {
            var factory = new GridViewFactory<T>() {Widget = new GridView()};
            Panel.Elementy.Add(factory.GridView);

            panel(factory);
            return factory;
        }

        #endregion
    }
}
