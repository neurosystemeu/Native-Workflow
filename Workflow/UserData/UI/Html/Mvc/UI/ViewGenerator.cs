using NeuroSystem.Workflow.UserData.UI.Html.Mvc.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using NeuroSystem.Workflow.Core.Extensions;
using NeuroSystem.Workflow.UserData.UI.Html.Mvc.Extensions;
using NeuroSystem.Workflow.UserData.UI.Html.Mvc.Infrastructure;

namespace NeuroSystem.Workflow.UserData.UI.Html.Mvc.UI
{
    public class ViewGenerator
    {
        #region Grid

        public static Grid CreateDefaultGrid(Type type,
            string dataSourceFiltr, EnumGridColumnVisibleMode visibleMode)
        {
            var visibleProperty = new List<VisibleProperty>();
            //var type = model.GetType();
            var properties = type.GetProperties();
            foreach (var propertyInfo in properties)
            {
                var displays = propertyInfo.GetCustomAttributes(typeof(GridViewAttribute));
                if (displays.Any())
                {
                    var display = displays.First() as GridViewAttribute;
                    if (visibleMode == EnumGridColumnVisibleMode.SmallList)
                    {
                        if (display.VisibleMode == EnumGridColumnVisibleMode.SmallList || 
                            display.VisibleMode == EnumGridColumnVisibleMode.SmallAndBigList)
                        {
                            visibleProperty.Add(
                                new VisibleProperty() {ListView = display, PropertyInfo = propertyInfo});
                        }
                    }
                    else if(visibleMode == EnumGridColumnVisibleMode.BigList)
                    {
                        if (display.VisibleMode == EnumGridColumnVisibleMode.BigList ||
                            display.VisibleMode == EnumGridColumnVisibleMode.SmallAndBigList)
                        {
                            visibleProperty.Add(
                                new VisibleProperty() { ListView = display, PropertyInfo = propertyInfo });
                        }
                    }
                }
            }

            var grid = new Grid();
            grid.Name = "grid";
            grid.DataSourceFilter = dataSourceFiltr;
            foreach (var property in visibleProperty)
            {
                var column = new GridColumn();
                column.Name = property.PropertyInfo.Name;
                grid.Columns.Add(column);
            }

            return grid;
        }

        #endregion

        #region DataForm

        public static Panel CreateDefaultDataForm(object model,
            string propertyPrefix = null)
        {
            var visibleProperty = new List<VisibleProperty>();
            var type = model.GetType();
            var properties = type.GetProperties();
            foreach (var propertyInfo in properties)
            {
                var displays = propertyInfo.GetCustomAttributes(typeof(DataFormViewAttribute));
                if (displays.Any())
                {
                    var display = displays.First() as DataFormViewAttribute;
                    visibleProperty.Add(new VisibleProperty() { DataFormView = display, PropertyInfo = propertyInfo });
                }
            }

            var tabsName = visibleProperty.Where(w => w.DataFormView.TabName != null)
               .Select(w => w.DataFormView.TabName).Distinct().ToList();

            var dataForm = new Panel("dataForm");
            //dataForm.Class("container well");
            //var sekcja = new Panel("sekcja");
            //sekcja.Class("well");
            //sekcja.HtmlContent = "<h2 class='ra - well - title'>What is this page?</h2>".Replace("'", "\"");

            //dataForm.Items.Add(sekcja);

            if (tabsName.Count > 1)
            {
                //var panel = view.AddPanel();
                var tabsControl = new Tabs();
                tabsControl.Name = "tabs";
                foreach (var tabName in tabsName)
                {
                    //tabsControl.Items.Add();
                    var tab = new Tab();
                    tab.Name = tabName;
                    var tabWidgets = visibleProperty.Where(w => w.DataFormView.TabName == tabName);
                    var tabPanel = new Panel("tab_" + tabName);
                    tabPanel.Class("tabPanel");
                    tab.Panel = tabPanel;
                    generateGroups(tabWidgets, tabPanel, model, propertyPrefix);
                    tabsControl.Items.Add(tab);
                }
                dataForm.Items.Add(tabsControl);
            }
            else
            {
                //visibleProperty = visibleProperty.OrderBy(p => p.Order).ToList();

                generateGroups(visibleProperty, dataForm, model, propertyPrefix);
            }

            return dataForm;
        }

        private static void generateGroups(IEnumerable<VisibleProperty> tabWidgets, Panel tab, object model,
            string propertyPrefix)
        {
            var groupsName = tabWidgets.Select(w => w.DataFormView.GroupName).Distinct().ToList();
            foreach (var groupName in groupsName)
            {
                var groupWidgets = tabWidgets.Where(w => w.DataFormView.GroupName == groupName);
                var groupPanel = new Panel("group_" + groupName);
                tab.Items.Add(groupPanel);

                groupPanel.Class("form-horizontal form-widgets col-xs-12 col-sm-5");
                //var groupPanel = new NsPanel(panel, viewContext, initializer, viewData, urlGenerator);
                //groupPanel.Label(groupName);
                //groupPanel.Width("49%");
                //groupPanel.Float(EnumPanelFloat.Left);

                foreach (var groupWidget in groupWidgets)
                {
                    var propertyName = groupWidget.PropertyInfo.Name;
                    var propertyNameWithObject = propertyPrefix + propertyName;


                    var blok = new Panel("block_" + propertyNameWithObject);
                    blok.Class("form-group");
                    var label = new Label();
                    label.Content = propertyName.SplitPascalCase();
                    label.Class("control-label col-sm-3");
                    label.For(propertyNameWithObject);
                    blok.Items.Add(label);

                    var div = new Panel("item_" + propertyNameWithObject);
                    div.Class("col-sm-7");
                    div.HtmlAttributes.Add("data-toggle", "tooltip");
                    div.HtmlAttributes.Add("title", groupWidget.PropertyInfo.GetPropertyDescription());
                    div.HtmlAttributes.Add("data-placement", "right");



                    blok.Items.Add(div);

                    if (groupWidget.DataFormView.RepositoryType != null)
                    {
                        var cb = new ComboBox();
                        cb.Name = propertyNameWithObject;
                        cb.DataTextField = "Nazwa";
                        cb.DataValueField = "Id";
                        var ds = new DataSource();
                        ds.ObjectType = groupWidget.DataFormView.RepositoryType;
                        ds.Type = DataSourceType.Ajax;
                        //ds.ServerFiltering = true;
                        //ds.PageSize = 10;
                        ds.Transport.Read.ActionName = groupWidget.DataFormView.RepositoryType.Name + "_ReadList";
                        ds.Transport.Read.ControllerName = null;
                        cb.DataSource = ds;
                        div.Items.Add(cb);

                        if (groupWidget.DataFormView.ListViewUrl != null)
                        {
                            //dodaje link do listy obiektów
                            div.Items.Add(new Link()
                            {
                                Name = propertyNameWithObject + "Lista",
                                Content = "Lista ",
                                NavigateUrl = groupWidget.DataFormView.ListViewUrl
                            });
                        }

                        if (groupWidget.DataFormView.DataFormViewUrl != null)
                        {
                            //dodaje link do listy obiektów
                            div.Items.Add(new Link()
                            {
                                Name = propertyNameWithObject + "Edycja",
                                Content = "Edycja",
                                NavigateUrl = groupWidget.DataFormView.DataFormViewUrl + model.GetPropValue(propertyName)
                            });
                        }

                        groupPanel.Items.Add(blok);
                    }
                    else
                    {
                        if (groupWidget.DataFormView.ControlType == EnumControlType.Grid)
                        {
                            //Mamy grida
                            var idObiektu = (Guid)model.GetPropValue("Id");
                            var typKolekcji = groupWidget.PropertyInfo.PropertyType;
                            var typ = typKolekcji.GetGenericArguments()[0];
                            var grid = CreateDefaultGrid(typ, idObiektu.ToString()
                               , EnumGridColumnVisibleMode.SmallList);
                            div.Items.Add(grid);
                        } else
                        if (groupWidget.PropertyInfo.PropertyType == typeof(DateTime) ||
                            groupWidget.PropertyInfo.PropertyType == typeof(DateTime?))
                        {
                            var dp = new DatePicker();
                            dp.Name = propertyNameWithObject;
                            dp.Value = (DateTime?)model.GetPropValue(propertyName);
                            dp.IsReadOnly = groupWidget.DataFormView.IsReadOnly;
                            div.Items.Add(dp);
                        }
                        else if (groupWidget.PropertyInfo.PropertyType == typeof(bool) ||
                                   groupWidget.PropertyInfo.PropertyType == typeof(bool?))
                        {
                            var cb = new CheckBox();
                            cb.Name = propertyNameWithObject;
                            cb.Value = (bool?)model.GetPropValue(propertyName);
                            cb.IsReadOnly = groupWidget.DataFormView.IsReadOnly;
                            div.Items.Add(cb);
                        }
                        else if (groupWidget.PropertyInfo.PropertyType.IsEnum)
                        {
                            var cb = new ComboBox();
                            cb.Name = propertyNameWithObject;
                            cb.Text = model.GetPropValue(propertyName).ToString();
                            var ds = new DataSource();
                            var values = Enum.GetNames(groupWidget.PropertyInfo.PropertyType);

                            ds.Type = DataSourceType.Server;
                            ds.Data = values;
                            cb.DataSource = ds;

                            int index = 0;
                            foreach (var value in values)
                            {
                                if (value == cb.Text)
                                {
                                    cb.SelectedIndex = index;
                                    break;
                                }
                                index++;
                            }

                            div.Items.Add(cb);
                        }
                        else
                        {
                            var tb = new TextBox<string>();
                            tb.Name = propertyNameWithObject;
                            tb.Value = model.GetPropValue(propertyName)?.ToString();
                            tb.IsReadOnly = groupWidget.DataFormView.IsReadOnly;
                            div.Items.Add(tb);
                        }

                        groupPanel.Items.Add(blok);
                        //df.AddField(groupWidget.PropertyInfo).Height = groupWidget.DataFormView.Height;
                    }
                }
            }
            //tab.AddPanel(p => p.Clear(EnumPanelClear.Both));
        }

        #endregion

        public class VisibleProperty
        {
            public PropertyInfo PropertyInfo { get; set; }
            public GridViewAttribute ListView { get; set; }
            public DataFormViewAttribute DataFormView { get; set; }

        }
    }
}
