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
        public static Panel CreateDefaultDataForm(object model, IViewGeneratorHelper generatorHelper = null)
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
                    var tabPanel = new Panel("tab_"+tabName);
                    tabPanel.Class("tabPanel");
                    tab.Panel = tabPanel;
                    generateGroups(tabWidgets, tabPanel, model, generatorHelper);
                    tabsControl.Items.Add(tab);
                }
                dataForm.Items.Add(tabsControl);
            }
            else
            {
                //visibleProperty = visibleProperty.OrderBy(p => p.Order).ToList();
                
                generateGroups(visibleProperty, dataForm, model, generatorHelper);
            }

            return dataForm;
        }

        private static void generateGroups(IEnumerable<VisibleProperty> tabWidgets, Panel tab, object model, 
            IViewGeneratorHelper generatorHelper)
        {
            var groupsName = tabWidgets.Select(w => w.DataFormView.GroupName).Distinct().ToList();
            foreach (var groupName in groupsName)
            {
                var groupWidgets = tabWidgets.Where(w => w.DataFormView.GroupName == groupName);
                var groupPanel = new Panel("group_"+groupName);
                tab.Items.Add(groupPanel);

                groupPanel.Class("form-horizontal form-widgets col-xs-12 col-sm-5");
                //var groupPanel = new NsPanel(panel, viewContext, initializer, viewData, urlGenerator);
                //groupPanel.Label(groupName);
                //groupPanel.Width("49%");
                //groupPanel.Float(EnumPanelFloat.Left);
                
                foreach (var groupWidget in groupWidgets)
                {
                    var blok = new Panel("block_" + groupWidget.PropertyInfo.Name);
                    blok.Class("form-group");
                    var label = new Label();
                    label.Content = groupWidget.PropertyInfo.Name.SplitPascalCase();
                    label.Class("control-label col-sm-3");
                    label.For(groupWidget.PropertyInfo.Name);
                    blok.Items.Add(label);
                    
                    var div = new Panel("item_" + groupWidget.PropertyInfo.Name);
                    div.Class("col-sm-7");
                    div.HtmlAttributes.Add("data-toggle", "tooltip");
                    div.HtmlAttributes.Add("title", groupWidget.PropertyInfo.GetPropertyDescription());
                    div.HtmlAttributes.Add("data-placement", "right");

                    blok.Items.Add(div);

                    if (groupWidget.DataFormView.RepositoryType != null)
                    {
                        var cb = new ComboBox();
                        cb.Name = groupWidget.PropertyInfo.Name;
                        var idObiektu = model.GetPropValue(groupWidget.PropertyInfo.Name)?.ToString();
                        if (generatorHelper != null)
                        {
                            cb.Text = generatorHelper.GetObjectName(groupWidget.DataFormView.RepositoryType, idObiektu);
                        }
                        cb.DataTextField = "Nazwa";
                        cb.DataValueField = "Id";
                        var ds = new DataSource();
                        ds.ObjectType = groupWidget.DataFormView.RepositoryType;
                        ds.Type = DataSourceType.Custom;
                        ds.ServerFiltering = true;
                        ds.Transport.Read.ActionName = groupWidget.DataFormView.RepositoryType.Name + "_Read";
                        ds.Transport.Read.ControllerName = null;
                        cb.DataSource = ds;
                        div.Items.Add(cb);
                        
                        groupPanel.Items.Add(blok);
                    }
                    else
                    {
                        

                        if (groupWidget.PropertyInfo.PropertyType == typeof(DateTime) ||
                            groupWidget.PropertyInfo.PropertyType == typeof(DateTime?))
                        {
                            var dp = new DatePicker();
                            dp.Name = groupWidget.PropertyInfo.Name;
                            dp.Value = (DateTime?)model.GetPropValue(groupWidget.PropertyInfo.Name);
                            dp.IsReadOnly = groupWidget.DataFormView.IsReadOnly;
                            div.Items.Add(dp);
                        }
                        else if (groupWidget.PropertyInfo.PropertyType == typeof(bool) ||
                                   groupWidget.PropertyInfo.PropertyType == typeof(bool?))
                        {
                            var cb = new CheckBox();
                            cb.Name = groupWidget.PropertyInfo.Name;
                            cb.Value = (bool?)model.GetPropValue(groupWidget.PropertyInfo.Name);
                            cb.IsReadOnly = groupWidget.DataFormView.IsReadOnly;
                            div.Items.Add(cb);
                        }
                        else if(groupWidget.PropertyInfo.PropertyType.IsEnum)
                        {
                            var cb = new ComboBox();
                            cb.Name = groupWidget.PropertyInfo.Name;
                            cb.Text = model.GetPropValue(groupWidget.PropertyInfo.Name).ToString();
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
                            tb.Name = groupWidget.PropertyInfo.Name;
                            tb.Value = model.GetPropValue(groupWidget.PropertyInfo.Name)?.ToString();
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

        public class VisibleProperty
        {
            public PropertyInfo PropertyInfo { get; set; }
            public GridViewAttribute ListView { get; set; }
            public DataFormViewAttribute DataFormView { get; set; }

        }
    }
}
