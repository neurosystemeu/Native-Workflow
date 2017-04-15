using System;
using System.Web.Mvc;
using Kendo.Mvc.Infrastructure;
using NeuroSystem.Workflow.UserData.UI.Html.ASP.UI.Html.Version2.TestViews;
using NeuroSystem.Workflow.UserData.UI.Html.ASP.UI.Html.Version2.Widgets;
using NeuroSystem.Workflow.UserData.UI.Html.Mvc.Widgets;

namespace NeuroSystem.Workflow.UserData.UI.Html.ASP.UI.Html.Mvc.Extensions
{
    public static class WidgetExtensions
    {
        public static Kendo.Mvc.UI.WidgetBase ToKendoWidget(this WidgetBase widget, ViewContext viewContext,
            IJavaScriptInitializer initializer, ViewDataDictionary viewData, Kendo.Mvc.IUrlGenerator urlGenerator)
        {
            var type = widget.GetType();
            if (type.IsGenericType)
            {
                if (type.GetGenericTypeDefinition() == typeof(TextBox<>))
                {
                    //var tx = widget.ToKendoWidget();
                }

                if (type.GetGenericTypeDefinition() == typeof(Grid<>))
                {
                    var grid = widget as Grid;
                    var controlType = typeof(Kendo.Mvc.UI.Grid<>).MakeGenericType(type.GenericTypeArguments[0]);
                    var control = (Kendo.Mvc.UI.WidgetBase)Activator.CreateInstance(controlType, new object[]
                    {
                        viewContext, initializer, urlGenerator, DI.Current.Resolve<Kendo.Mvc.UI.Html.IGridHtmlBuilderFactory>()
                    });

                    control.Name = "grid";
                    var gridControl = (Kendo.Mvc.UI.IGrid)control;

                    var ds = gridControl.DataSource;
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
