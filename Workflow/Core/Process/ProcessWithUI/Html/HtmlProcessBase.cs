using System;
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
using NeuroSystem.Workflow.UserData.UI.Html.DataAnnotations;
using NeuroSystem.Workflow.UserData.UI.Html.DataSources;
using NeuroSystem.Workflow.UserData.UI.Html.Fluent.Widgets.DataWidgets;
using NeuroSystem.Workflow.UserData.UI.Html.Fluent.Widgets.Panels;
using NeuroSystem.Workflow.UserData.UI.Html.Widgets.ItemsWidgets;
using NeuroSystem.Workflow.UserData.UI.Html.Widgets.Panels;

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
            public GridViewAttribute ListView { get; set; }
            public DataFormViewAttribute DataFormView { get; set; }

        }

        public HtmlProcessBase()
        {
            UserActions = new List<string>();
        }

        #region Propercje

        /// <summary>
        /// Lista dodatkowych akcji użytkownika które mają być obsługiwan
        /// </summary>
        public List<string> UserActions { get; set; }

        /// <summary>
        /// Funkcja użytownika do obsługi wykonania funkcji użytkownika
        /// (wywoływana przez proces w momenci gdy użytkownik kliknie na funkcję nie standardową.
        /// Wykonywanie będzie przeniesione na zewnątrz z informacją o nazwie funkcji)
        /// </summary>
        public Func<string, object> PerformUserAction;

        #endregion

        #region Edit data form

        /// <summary>
        /// Tworzy widok dla trypu edycji na podstawie typu
        /// Tworzy panel który może być łączony z innymi panelami
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="title"></param>
        /// <param name="description"></param>
        /// <returns></returns>
        public UserData.UI.Html.Fluent.Views.DataFormFactory<T> CreateDataForm<T>(string title = null, string description = null)
        {
            var view = new UserData.UI.Html.Fluent.Views.DataFormFactory<T>();
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
        /// Tworzy fabrykę widoku edycji dla edycji na podstawie obiektu (tworzy widok na podstawie danych w moduelu typu T)
        /// Tworzy panel który może być łączony z innymi panelami
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="biznesObject"></param>
        /// <returns></returns>
        public UserData.UI.Html.Fluent.Views.DataFormFactory<T> CreateDataForm<T>(T biznesObject, string title = null, string description= null)
        {
            var view = new UserData.UI.Html.Fluent.Views.DataFormFactory<T>();
            view.DataContext(biznesObject);

            var visibleProperty = new List<VisibleProperty>();

            var type = biznesObject.GetType();
            var properties = type.GetProperties();
            foreach (var propertyInfo in properties)
            {
                var displays = propertyInfo.GetCustomAttributes(typeof(DataFormViewAttribute));
                if (displays.Any())
                {
                    var display = displays.First() as DataFormViewAttribute;
                    visibleProperty.Add(new VisibleProperty() { DataFormView = display , PropertyInfo = propertyInfo });
                }
            }
            
            var tabsName = visibleProperty.Where(w => w.DataFormView.TabName != null)
                .Select(w => w.DataFormView.TabName).Distinct().ToList();
            if (tabsName.Count > 1)
            {
                var panel = view.AddPanel();
                var tabsControl = panel.AddTabs();
                foreach (var tabName in tabsName)
                {
                    var tab = tabsControl.AddTab(tabName);
                    
                    var tabWidgets = visibleProperty.Where(w => w.DataFormView.TabName == tabName);
                    generateGroups(tabWidgets, tab);
                }
                
            }
            else
            {
                //visibleProperty = visibleProperty.OrderBy(p => p.Order).ToList();
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
                generateGroups(visibleProperty, df);
            }

            

            return view;
        }

        private void generateGroups<T>(IEnumerable<VisibleProperty> tabWidgets, PanelFactory<T> tab)
        {
            var groupsName = tabWidgets.Select(w => w.DataFormView.GroupName).Distinct().ToList();
            foreach (var groupName in groupsName)
            {
                var groupWidgets = tabWidgets.Where(w => w.DataFormView.GroupName == groupName);
                var groupPanel = tab.AddPanel();
                groupPanel.Label(groupName);
                groupPanel.Width("49%");
                groupPanel.Float(EnumPanelFloat.Left);
                var df = groupPanel.AddDataForm();
                foreach (var groupWidget in groupWidgets)
                {
                    if (groupWidget.DataFormView.RepositoryType != null)
                    {
                        var cb = df.AddComboBox(groupWidget.PropertyInfo.Name).LoadOnDemand(true);
                        cb.DataSource(GetDataSourceByType(groupWidget.DataFormView.RepositoryType));
                        cb.Label(groupWidget.PropertyInfo.Name);
                    }
                    else
                    {
                        df.AddField(groupWidget.PropertyInfo).Height = groupWidget.DataFormView.Height;
                    }
                }
            }
            tab.AddPanel(p => p.Clear(EnumPanelClear.Both));
        }

        #endregion

        #region List -> grid

        /// <summary>
        /// Tworzy widok listy
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="title"></param>
        /// <param name="description"></param>
        /// <returns></returns>
        public virtual ListViewFactory<T> CreateGrid<T>(string title = null, string description = null)
        {
            var view = new ListViewFactory<T>();

            var visibleProperty = new List<VisibleProperty>();

            var type = typeof(T);
            var properties = type.GetProperties();
            foreach (var propertyInfo in properties)
            {
                var scaffoldColumns = propertyInfo.GetCustomAttributes(typeof(GridViewAttribute));
                if (scaffoldColumns.Any())
                {
                    var scaffoldColumn = scaffoldColumns.First() as GridViewAttribute;
                    if (scaffoldColumn != null)
                    {
                        visibleProperty.Add(new VisibleProperty() { ListView = scaffoldColumn, PropertyInfo = propertyInfo });
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
            grid.GridView.GroupingEnabled = true;
            grid.GridView.AllowFilteringByColumn = true;
            grid.GridView.AllowSorting = true;
            grid.GridView.AggregateEnabled = true;

            foreach (var property in visibleProperty)
            {
                var column = grid.Column(property.PropertyInfo.Name).Label(property.ListView.Label ?? property.PropertyInfo.Name);
                
                column.Column.FilterFunction = property.ListView.FilterFunction;
                column.Column.FilterDefaultValue = property.ListView.FilterDefaultValue;
                if (property.ListView.FilterFunction != GridKnownFunction.NoFilter)
                {
                    column.ShowColumnFilter();
                }

                column.Column.DataFormatString = property.ListView.DataFormatString;
                column.Column.Aggregate = property.ListView.Aggregate;
                
            }

            view.Grid = grid;

            return view;
        }

        #endregion

        #region DataSources

        /// <summary>
        /// Zwraca zródło danych w zależności od typu
        /// </summary>
        /// <param name="datasourceType"></param>
        /// <returns></returns>
        protected virtual DataSourceBase GetDataSourceByType(Type datasourceType)
        {
            return null;
        }

        

        #endregion

        #region UI method

        /// <summary>
        /// Metoda służy do 'wyświetlania' widoku
        /// (w zależności od implemantacji np. 
        /// </summary>
        /// <param name="view"></param>
        /// <returns></returns>
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


        /// <summary>
        /// Wyświetla komunikat
        /// </summary>
        /// <param name="text"></param>
        /// <param name="endText"></param>
        [Interpret]
        public void ShowMessage(string text, string endText = "Zakończono proces")
        {
            var view = CreateDataForm(new object(), text);
            view.AddAction("Ok");
            view.AddAction("Zamknij");

            var wynikEdycji = ShowView(view);
            if (wynikEdycji.ActionName == "Zamknij")
            {
                EndProcess(endText);
            }
        }

        #endregion

        #region UI funkcje zewnętrzne

        public virtual object InvokeUserAction(string actionName)
        {
            if (PerformUserAction != null)
            {
                return PerformUserAction(actionName);
            }
            return null;
        }

        #endregion
    }
}
