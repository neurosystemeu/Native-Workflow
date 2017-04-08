using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Kendo.Mvc.Infrastructure;
using NeuroSystem.Workflow.UserData.UI.Html.ASP.UI.Html.Version2.Widgets;
using NeuroSystem.Workflow.UserData.UI.Html.Widgets;

namespace NeuroSystem.Workflow.UserData.UI.Html.ASP.UI.Html.Version2.Extensions
{
    public static class WidgetExtensions
    {
        public static Kendo.Mvc.UI.WidgetBase ToKendoWidget(this WidgetBase widget, ViewContext viewContext, IJavaScriptInitializer initializer, ViewDataDictionary viewData = null)
        {
            var type = widget.GetType();
            if (type.IsGenericType)
            {
                if (type.GetGenericTypeDefinition() == typeof(TextBox<>))
                {
                    var controlType = typeof (Kendo.Mvc.UI.TextBox<>).MakeGenericType(type.GenericTypeArguments[0]);
                    var control= (Kendo.Mvc.UI.WidgetBase)Activator.CreateInstance(controlType, new object[] { viewContext, initializer, viewData });
                    control.Name = "test";
                    return control;
                }
            }

            if (widget is Panel)
            {
                return new NsPanel(widget as Panel, viewContext, initializer, viewData);
            } 
            return null;
        }

       
    }
}
