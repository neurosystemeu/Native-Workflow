using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using NeuroSystem.VirtualMachine.Core.Attributes;
using NeuroSystem.Workflow.Core.Extensions;
using NeuroSystem.Workflow.UserData.UI.Html.Fluent;
using NeuroSystem.Workflow.UserData.UI.Html.Fluent.Views;
using NeuroSystem.Workflow.UserData.UI.Html.UserDataActions;
using NeuroSystem.Workflow.UserData.UI.Html.Views;
using System.Reflection;
using NeuroSystem.Workflow.UserData.UI.Html.Fluent.Widgets.DataWidgets;

namespace NeuroSystem.Workflow.Core.Process.ProcessWithUI.Html
{
    /// <summary>
    /// Proces obsługujący dane użytkownika w formacie html
    /// Host musi obsługiwać taki format
    /// </summary>
    public class HtmlProcessBase : ProcessBase
    {
        private class VisibleProperty
        {
            public PropertyInfo PropertyInfo { get; set; }
            public int Order { get; set; }
        }

        #region Edit data form

        public DataFormFactory<T> CreateDataFormView<T>(string title = null, string description = null)
        {
            var view = new DataFormFactory<T>();
            var df = view.AddDataForm();
            if (title != null)
            {
                df.AddLabel(title);
            }
            if (description != null)
            {
                df.AddLabel(description);
            }

            view.ActiveDataForm = df;
            return view;
        }

        /// <summary>
        /// Generuje data form dla obiektu
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="biznesObject"></param>
        /// <returns></returns>
        public DataFormFactory<T> CreateDataFormView<T>(T biznesObject, string title = null, string description= null)
        {
            var view = new DataFormFactory<T>();
            view.DataContext(biznesObject);

            var visibleProperty = new List<VisibleProperty>();

            var type = biznesObject.GetType();
            var properties = type.GetProperties();
            foreach (var propertyInfo in properties)
            {
                var displays = propertyInfo.GetCustomAttributes(typeof(DisplayAttribute));
                if (displays.Any())
                {
                    var display = displays.First() as DisplayAttribute;
                    visibleProperty.Add(new VisibleProperty() { Order = display.GetOrder() ?? 0, PropertyInfo = propertyInfo });
                }
            }

            visibleProperty = visibleProperty.OrderBy(p => p.Order).ToList();
            var df = view.AddDataForm();
            if (title != null)
            {
                df.AddLabel(title);
            }
            if (description != null)
            {
                df.AddLabel(description);
            }

            view.ActiveDataForm = df;
            foreach (var property in visibleProperty)
            {
                df.AddField(property.PropertyInfo);
            }

            return view;
        }

        #endregion

        #region List -> grid

        public ListViewFactory<T> CreateGridView<T>(string title = null, string description = null)
        {
            var view = new ListViewFactory<T>();

            var visibleProperty = new List<VisibleProperty>();

            var type = typeof(T);
            var properties = type.GetProperties();
            foreach (var propertyInfo in properties)
            {
                var scaffoldColumns = propertyInfo.GetCustomAttributes(typeof(ScaffoldColumnAttribute));
                if (scaffoldColumns.Any())
                {
                    var scaffoldColumn = scaffoldColumns.First() as ScaffoldColumnAttribute;
                    if (scaffoldColumn.Scaffold)
                    {
                        visibleProperty.Add(new VisibleProperty() { Order = 1, PropertyInfo = propertyInfo });
                    }
                }
            }
            var df = view.AddDataForm();
            if (title != null )
            {
                df.AddLabel(title);
            }
            if (description != null)
            {
                df.AddLabel(description);
            }

            var grid = df.AddGridView();
            foreach (var property in visibleProperty)
            {
                grid.Column(property.PropertyInfo.Name);
            }

            view.Grid = grid;

            return view;
        }

        #endregion

        [Interpret]
        public HtmlRead ShowView(ViewFaktoryBase view)
        {
            var show = new HtmlShow();
            show.View = view.GetView();
            UserDataInput = null;
            UserDataOutput = show;
            Status = EnumProcessStatus.WaitingForUserData;
            Hibernate();
            return UserDataInput as HtmlRead;
        }
    }
}
