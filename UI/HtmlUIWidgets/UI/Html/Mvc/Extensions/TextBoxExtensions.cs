using System;
using System.Web.Mvc;
using Kendo.Mvc.Infrastructure;
using NeuroSystem.Workflow.UserData.UI.Html.Mvc.UI;

namespace NeuroSystem.Workflow.UserData.UI.Html.Mvc.Extensions
{
    public static class TextBoxExtensions
    {
        public static Kendo.Mvc.UI.WidgetBase ToKendoWidget<T>(this TextBox<T> textBox, ViewContext viewContext,
            IJavaScriptInitializer initializer, ViewDataDictionary viewData)
        {
            var tx = new Kendo.Mvc.UI.TextBox<T>(viewContext, initializer, viewData);
            tx.Name = textBox.Name;
            tx.Format = textBox.Format;
            tx.Value = textBox.Value;
            return tx;
        }

        public static Kendo.Mvc.UI.WidgetBase CreateTextBox(Type typArgumentu, HtmlHelper helper,
            IJavaScriptInitializer initializer)
        {
            var controlType = typeof(Kendo.Mvc.UI.TextBox<>).MakeGenericType(typArgumentu);
            var control = (Kendo.Mvc.UI.WidgetBase)Activator.CreateInstance(controlType, new object[] { helper.ViewContext, initializer, helper.ViewData });
            
            return control;
        } 
    }
}
