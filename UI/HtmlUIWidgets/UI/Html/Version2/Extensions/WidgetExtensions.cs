using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Kendo.Mvc.Infrastructure;
using Kendo.Mvc.UI;
using Kendo.Mvc.UI.Fluent;
using NeuroSystem.Workflow.UserData.UI.Html.ASP.UI.Html.Version2.TestViews;
using NeuroSystem.Workflow.UserData.UI.Html.ASP.UI.Html.Version2.Widgets;
using NeuroSystem.Workflow.UserData.UI.Html.Widgets;
using WidgetBase = NeuroSystem.Workflow.UserData.UI.Html.Widgets.WidgetBase;

namespace NeuroSystem.Workflow.UserData.UI.Html.ASP.UI.Html.Version2.Extensions
{
    public static class WidgetExtensions
    {
        public static Kendo.Mvc.UI.WidgetBase ToKendoWidget(this WidgetBase widget, ViewContext viewContext,
            IJavaScriptInitializer initializer, ViewDataDictionary viewData, Kendo.Mvc.IUrlGenerator urlGenerator)
        {
            var type = widget.GetType();
            if (type.IsGenericType)
            {
                if (type.GetGenericTypeDefinition() == typeof(UserData.UI.Html.Widgets.TextBox<>))
                {
                    var controlType = typeof (Kendo.Mvc.UI.TextBox<>).MakeGenericType(type.GenericTypeArguments[0]);
                    var control= (Kendo.Mvc.UI.WidgetBase)Activator.CreateInstance(controlType, new object[] { viewContext, initializer, viewData });
                    control.Name = "cb";
                    return control;
                }

                if (type.GetGenericTypeDefinition() == typeof(UserData.UI.Html.Widgets.Grid<>))
                {
                    var controlType = typeof(Kendo.Mvc.UI.Grid<>).MakeGenericType(type.GenericTypeArguments[0]);
                    var control = (Kendo.Mvc.UI.WidgetBase)Activator.CreateInstance(controlType, new object[]
                    {
                        viewContext, initializer, urlGenerator, DI.Current.Resolve<Kendo.Mvc.UI.Html.IGridHtmlBuilderFactory>()
                    });
                    control.Name = "grid";
                    var grid = (Kendo.Mvc.UI.IGrid) control;

                    var ds = grid.DataSource;
                    var dsb = new Kendo.Mvc.UI.Fluent.DataSourceBuilder<PracownikTestModel>(ds, viewContext, urlGenerator);
                    dsb.Ajax()
                        .Read("PracownikTestModel_Read", "Proces");
                    
                    return control;
                } 
            }

            if (widget is Panel)
            {
                return new NsPanel(widget as Panel, viewContext, initializer, viewData, urlGenerator);
            } 
            return null;
        }

       
    }
}
