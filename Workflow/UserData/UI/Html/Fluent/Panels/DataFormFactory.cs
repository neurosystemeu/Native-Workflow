using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using NeuroSystem.Workflow.UserData.UI.Html.Fluent.Widgets.Items;
using NeuroSystem.Workflow.UserData.UI.Html.Widget;
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

        public PanelFactory<T> Pole<TD>(Expression<Func<T, TD>> nazwaPola)
        {
            var member = (nazwaPola.Body as MemberExpression).Member as System.Reflection.PropertyInfo;
            var nazwa = member.Name;

            Panel.Elementy.Add(new WidgetBase() { Label = nazwa });
            return this;
        }

        public PanelFactory<T> ComboBox<TD>(Expression<Func<T, TD>> nazwaPola)
        {
            var member = (nazwaPola.Body as MemberExpression).Member as System.Reflection.PropertyInfo;
            var nazwa = member.Name;

            Panel.Elementy.Add(new WidgetBase() { Label = nazwa });
            return this;
        }

        public PanelFactory<T> GridView(Action<GridViewFactory<T>> panel)
        {
            var gridView = new GridViewFactory<T>();
            Panel.Elementy.Add(gridView.GridView);

            panel(gridView);
            return this;
        }

        #endregion
    }
}
