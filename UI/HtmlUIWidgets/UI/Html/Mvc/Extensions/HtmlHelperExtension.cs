using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web.Mvc;
using Kendo.Mvc;
using Kendo.Mvc.Infrastructure;
using Kendo.Mvc.UI;
using NeuroSystem.Workflow.UserData.UI.Html.Mvc.DataAnnotations;
using NeuroSystem.Workflow.UserData.UI.Html.Mvc.Fluent;
using NeuroSystem.Workflow.UserData.UI.Html.Mvc.TestViews;
using NeuroSystem.Workflow.UserData.UI.Html.Mvc.UI;
using NeuroSystem.Workflow.UserData.UI.Html.Mvc.Widgets;

namespace NeuroSystem.Workflow.UserData.UI.Html.Mvc.Extensions
{
    public static class HtmlHelperExtension
    {
        public static WidgetFactory Ns(this System.Web.Mvc.HtmlHelper helper)
        {
            return new WidgetFactory(helper);
        }

        public static object CreateDataForm<TModel>(this HtmlHelper<TModel> helper, object model)
        {
            var initializer = DI.Current.Resolve<IJavaScriptInitializer>();
            var urlGenerator = DI.Current.Resolve<IUrlGenerator>();
            
            var dataForm = ViewGenerator.CreateDefaultDataForm(model);
            var kendoPanel = dataForm.ToKendoWidget(helper, initializer, urlGenerator);
            
            var htmlstr = kendoPanel.ToHtmlString();
            return new MvcHtmlString(htmlstr);
        }

        public class VisibleProperty
        {
            public PropertyInfo PropertyInfo { get; set; }
            public GridViewAttribute ListView { get; set; }
            public DataFormViewAttribute DataFormView { get; set; }

        }

        public static object DataForm<TModel>(this HtmlHelper<TModel> helper, TModel model)
        {
            var viewContext = helper.ViewContext;
            var initializer = DI.Current.Resolve<IJavaScriptInitializer>();
            var urlGenerator = DI.Current.Resolve<IUrlGenerator>();
            var viewData = helper.ViewData;
            

            var biznesObject = new PracownikTest();
            var viewPanel = new Panel();
            var view = new NsPanel(viewPanel, helper, initializer, urlGenerator);

            var visibleProperty = new List<VisibleProperty>();

            var type = biznesObject.GetType();
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
            if (tabsName.Count > 1)
            {
                //var panel = view.AddPanel();
                var tabsControl = helper.Kendo().TabStrip().ToComponent();
                foreach (var tabName in tabsName)
                {
                    //tabsControl.Items.Add();
                    var tab = new TabStripItem();
                    var tabWidgets = visibleProperty.Where(w => w.DataFormView.TabName == tabName);
                    generateGroups(tabWidgets, tab);
                }

            }
            else
            {
                ////visibleProperty = visibleProperty.OrderBy(p => p.Order).ToList();
                //var df = view.AddDataForm();
                //if (title != null)
                //{
                //    df.AddLabel(title);
                //}
                //if (description != null)
                //{
                //    df.AddLabel(description);
                //}

                //view.ActiveDataForm = df;
                //generateGroups(visibleProperty, df);
            }

            return new MvcHtmlString("");
        }

        private static void generateGroups(IEnumerable<VisibleProperty> tabWidgets, TabStripItem tab)
        {
            var groupsName = tabWidgets.Select(w => w.DataFormView.GroupName).Distinct().ToList();
            foreach (var groupName in groupsName)
            {
                //var groupWidgets = tabWidgets.Where(w => w.DataFormView.GroupName == groupName);
                //var panel = new Panel();
                //var groupPanel = new NsPanel(panel, viewContext, initializer, viewData, urlGenerator);
                ////groupPanel.Label(groupName);
                ////groupPanel.Width("49%");
                ////groupPanel.Float(EnumPanelFloat.Left);
                //var df = groupPanel.AddDataForm();
                //foreach (var groupWidget in groupWidgets)
                //{
                //    if (groupWidget.DataFormView.RepositoryType != null)
                //    {
                //        var cb = df.AddComboBox(groupWidget.PropertyInfo.Name).LoadOnDemand(true);
                //        cb.DataSource(GetDataSourceByType(groupWidget.DataFormView.RepositoryType));
                //        cb.Label(groupWidget.PropertyInfo.Name);
                //    }
                //    else
                //    {
                //        df.AddField(groupWidget.PropertyInfo).Height = groupWidget.DataFormView.Height;
                //    }
                //}
            }
            //tab.AddPanel(p => p.Clear(EnumPanelClear.Both));
        }

        public static NsPanel generujGrupe(IEnumerable<VisibleProperty> tabWidgets
            , System.Web.Mvc.HtmlHelper helper, IJavaScriptInitializer initializer,
            IUrlGenerator urlGenerator)
        {
            var nsgrupa = new NsPanel(new Panel(),helper, initializer, urlGenerator );
            nsgrupa.Class("form-horizontal form-widgets col-sm-6");

            foreach (var visibleProperty in tabWidgets)
            {
                //blok
                var blok = new NsPanel(new Panel(), helper, initializer, urlGenerator);
                blok.Class("form-group");
                var label = new NsLabel(new Label(), helper);
                label.Content = visibleProperty.PropertyInfo.Name;
                blok.AddItem(label);
                var div = new Panel();
                div.Class("col-sm-8 col-md-8");
                blok.Panel.Items.Add(div);
                var tb = new UserData.UI.Html.Mvc.UI.TextBox<string>();
                tb.Name = visibleProperty.PropertyInfo.Name;
                div.Items.Add(tb);

                nsgrupa.AddItem(blok);
            }

            return nsgrupa;
        }
    }
}
