using System;
using System.Linq.Expressions;
using NeuroSystem.Workflow.UserData.UI.Html.Widgets.ItemsWidgets;

namespace NeuroSystem.Workflow.UserData.UI.Html.Fluent.Widgets.DataWidgets
{
    public class GridViewFactory<T> : ItemsWidgetsFactory<T>
    {
        public GridView GridView => Widget as GridView;

        
        public GridViewColumnFactory<T> Column<TD>(Expression<Func<T, TD>> nazwaPola)
        {
            var member = (nazwaPola.Body as MemberExpression).Member as System.Reflection.PropertyInfo;
            var nazwa = member.Name;

            var col = new GridViewColumnFactory<T>();
            col.Column.Name = nazwa;
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
