using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Kendo.Mvc.Infrastructure;
using NeuroSystem.Workflow.UserData.UI.Html.Mvc.Widgets;

namespace NeuroSystem.Workflow.UserData.UI.Html.ASP.UI.Html.Mvc.Extensions
{
    public static class TextBoxExtensions
    {
        public static Kendo.Mvc.UI.WidgetBase ToKendoWidget<T>(this TextBox<T> textBox, ViewContext viewContext,
            IJavaScriptInitializer initializer, ViewDataDictionary viewData)
        {
            var tx = new Kendo.Mvc.UI.TextBox<T>(viewContext, initializer, viewData);
            tx.Name = textBox.Name;
            tx.Format = textBox.Format;
            return tx;
        }

        public static Kendo.Mvc.UI.WidgetBase ToKendoTextBox(Type typArgumentu, ViewContext viewContext,
            IJavaScriptInitializer initializer, ViewDataDictionary viewData)
        {
            var controlType = typeof(Kendo.Mvc.UI.TextBox<>).MakeGenericType(typArgumentu);
            var control = (Kendo.Mvc.UI.WidgetBase)Activator.CreateInstance(controlType, new object[] { viewContext, initializer, viewData });
            control.Name = "cb";
            return control;
        } 
    }
}
