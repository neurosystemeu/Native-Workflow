using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using NeuroSystem.Workflow.Core.Extensions;
using NeuroSystem.Workflow.UserData.UI.Html.Fluent.Widgets.Items;
using NeuroSystem.Workflow.UserData.UI.Html.ViewModel;
using NeuroSystem.Workflow.UserData.UI.Html.Widget;
using NeuroSystem.Workflow.UserData.UI.Html.Widget.Data;
using NeuroSystem.Workflow.UserData.UI.Html.Widget.ItemsWidget;
using NeuroSystem.Workflow.UserData.UI.Html.Widget.Simple;
using NeuroSystem.Workflow.UserData.UI.Html.Widgets.DataForm;
using NeuroSystem.Workflow.UserData.UI.Html.Widgets.Panels;

namespace NeuroSystem.Workflow.UserData.UI.Html.Fluent.Panels
{
    public class DataFormFactory<T> : PanelFactory<T>
    {
        public DataFormFactory()
        {
            Panel = new DataForm();
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
                    Tooltip = tooltip
                };
            }
            else if (member.PropertyType == typeof(bool))
            {
                widget = new CheckBox()
                {
                    Name = name,
                    Label = name,
                    Value = new Binding(name),
                    Tooltip = tooltip
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
                    Tooltip = tooltip
                };
            }
            

            Panel.Elementy.Add(widget);
            return this;
        }

        public PanelFactory<T> AddComboBox<TD>(Expression<Func<T, TD>> nazwaPola)
        {
            var member = (nazwaPola.Body as MemberExpression).Member as System.Reflection.PropertyInfo;
            var nazwa = member.Name;

            Panel.Elementy.Add(new WidgetBase() { Label = nazwa });
            return this;
        }

        public GridViewFactory<T> AddGridView(Action<GridViewFactory<T>> panel)
        {
            var gridView = new GridViewFactory<T>();
            Panel.Elementy.Add(gridView.GridView);

            panel(gridView);
            return gridView;
        }

        #endregion
    }
}
