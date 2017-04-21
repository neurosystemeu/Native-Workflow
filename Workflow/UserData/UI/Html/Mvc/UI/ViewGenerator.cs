using NeuroSystem.Workflow.UserData.UI.Html.Mvc.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace NeuroSystem.Workflow.UserData.UI.Html.Mvc.UI
{
    public class ViewGenerator
    {
        public static Panel CreateDefaultDataForm(object model)
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
            dataForm.Class("container well");

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
                    tab.Panel = tabPanel;
                    generateGroups(tabWidgets, tabPanel);
                    tabsControl.Items.Add(tab);
                }
                dataForm.Items.Add(tabsControl);
            }
            else
            {
                //visibleProperty = visibleProperty.OrderBy(p => p.Order).ToList();
                
                generateGroups(visibleProperty, dataForm);
            }

            return dataForm;
        }

        private static void generateGroups(IEnumerable<VisibleProperty> tabWidgets, Panel tab)
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
                    label.Content = groupWidget.PropertyInfo.Name;
                    label.Class("control-label col-sm-3");
                    label.For(groupWidget.PropertyInfo.Name);
                    blok.Items.Add(label);
                    if (groupWidget.DataFormView.RepositoryType != null)
                    {
                        //var cb = df.AddComboBox(groupWidget.PropertyInfo.Name).LoadOnDemand(true);
                        //cb.DataSource(GetDataSourceByType(groupWidget.DataFormView.RepositoryType));
                        //cb.Label(groupWidget.PropertyInfo.Name);
                    }
                    else
                    {
                        var div = new Panel("item_" + groupWidget.PropertyInfo.Name);
                        div.Class("col-sm-7");
                        blok.Items.Add(div);
                        var tb = new TextBox<string>();
                        tb.Name = groupWidget.PropertyInfo.Name;
                        div.Items.Add(tb);

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
