using System;
using System.Linq.Expressions;
using NeuroSystem.Workflow.UserData.UI.Html.Version1.Widgets.ItemsWidgets;

namespace NeuroSystem.Workflow.UserData.UI.Html.Version1.Fluent.Widgets.DataWidgets
{
    public class GridViewFactory<T> : ItemsWidgetsFactory<T>
    {
        public GridView GridView => Widget as GridView;

        
        public GridViewColumnFactory<T> Column<TD>(Expression<Func<T, TD>> nazwaPola, string label=null)
        {
            var member = (nazwaPola.Body as MemberExpression).Member as System.Reflection.PropertyInfo;
            var nazwa = member.Name;
            return Column(nazwa, label);
        }

        public GridViewColumnFactory<T> Column(string name, string label=null)
        {
            //var member = (nazwaPola.Body as MemberExpression).Member as System.Reflection.PropertyInfo;
            var col = new GridViewColumnFactory<T>();
            col.Column.Name = name;
            col.Column.Label = label;
            GridView.Columns.Add(col.Column);
            return col;
        }

        public GridViewFactory<T> AllowEditing(bool AllowEditing)
        {
            GridView.AllowEditing = AllowEditing;
            return this;
        }
    }
}
