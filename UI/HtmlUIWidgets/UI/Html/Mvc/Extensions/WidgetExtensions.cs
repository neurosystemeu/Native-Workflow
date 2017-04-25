using System;
using System.Web.Mvc;
using Kendo.Mvc.Infrastructure;
using NeuroSystem.Workflow.Core.Extensions;
using NeuroSystem.Workflow.UserData.UI.Html.ASP.UI.Html.Version2.TestViews;
using NeuroSystem.Workflow.UserData.UI.Html.ASP.UI.Html.Version2.Widgets;
using NeuroSystem.Workflow.UserData.UI.Html.Mvc.UI;

namespace NeuroSystem.Workflow.UserData.UI.Html.ASP.UI.Html.Mvc.Extensions
{
    public static class WidgetExtensions
    {
        public static Kendo.Mvc.UI.WidgetBase ToKendoWidget(this WidgetBase widget, HtmlHelper helper,
            IJavaScriptInitializer initializer, Kendo.Mvc.IUrlGenerator urlGenerator)
        {
            var type = widget.GetType();
            if (type.IsGenericType)
            {
                if (type.GetGenericTypeDefinition() == typeof(TextBox<>))
                {
                    var tb = TextBoxExtensions.CreateTextBox(
                        type.GenericTypeArguments[0], helper, initializer);
                    tb.Name = widget.Name;

                    tb.SetPropValue("Value", widget.GetPropValue("Value"));

                    dynamic dynamicTb = tb;
                    dynamicTb.Enabled = !widget.IsReadOnly;
                    return tb;
                }

                if (type.GetGenericTypeDefinition() == typeof(Grid<>))
                {
                    var grid = widget as Grid;
                    var controlType = typeof(Kendo.Mvc.UI.Grid<>).MakeGenericType(type.GenericTypeArguments[0]);
                    var control = (Kendo.Mvc.UI.WidgetBase)Activator.CreateInstance(controlType, new object[]
                    {
                        helper.ViewContext, initializer, urlGenerator, DI.Current.Resolve<Kendo.Mvc.UI.Html.IGridHtmlBuilderFactory>()
                    });

                    control.Name = "grid";
                    var gridControl = (Kendo.Mvc.UI.IGrid)control;
                    grid.DataSource.SetDataSource(gridControl.DataSource, helper.ViewContext, initializer, helper.ViewData,
                        urlGenerator);


                    return control;
                }
            }
            else
            {
                if (widget is DatePicker)
                {
                    var dp = widget as DatePicker;
                    return dp.ToKendoWidget(helper, initializer);
                }

                if (widget is CheckBox)
                {
                    var cb = widget as CheckBox;
                    return cb.ToKendoWidget(helper, initializer);
                }

                if (widget is ComboBox)
                {
                    var cb = widget as ComboBox;
                    return cb.ToKendoWidget(helper, initializer, urlGenerator);
                }

                if (widget is Label)
                {
                    var label = widget as Label;
                    return label.ToKendoWidget(helper, initializer);
                }

                if (widget is Tabs)
                {
                    var tabs = widget as Tabs;
                    return tabs.ToKendoWidget(helper, initializer, urlGenerator);
                }
            }

            if (widget is Panel)
            {
                return new NsPanel(widget as Panel, helper, initializer, urlGenerator);
            }
            return null;
        }


    }
}
