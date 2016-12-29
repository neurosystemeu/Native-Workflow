using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using NeuroSystem.Workflow.UserData.UI.Html.Widget.ItemsWidget;

namespace NeuroSystem.Workflow.UserData.UI.Html.Fluent.Widgets.Items
{
    public class GridViewFactory<T> : ItemsWidgetsFactory<T>
    {
        public GridView GridView => Widget as GridView;

        
        public GridViewColumnFactory<T> Column<TD>(Expression<Func<T, TD>> nazwaPola)
        {
            var member = (nazwaPola.Body as MemberExpression).Member as System.Reflection.PropertyInfo;
            var nazwa = member.Name;

            var col = new GridViewColumnFactory<T>();
            return col;
        }
    }
}
