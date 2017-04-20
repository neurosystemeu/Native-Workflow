using Kendo.Mvc.Infrastructure;
using NeuroSystem.Workflow.UserData.UI.Html.ASP.UI.Html.Mvc.Widgets;
using NeuroSystem.Workflow.UserData.UI.Html.Mvc.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace NeuroSystem.Workflow.UserData.UI.Html.ASP.UI.Html.Mvc.Extensions
{
    public static class LabelExtension
    {
        public static NsLabel ToKendoWidget(this Label widget, HtmlHelper helper,
            IJavaScriptInitializer initializer)
        {
            var control = new NsLabel(widget, helper, initializer);
            control.Name = widget.Name;
            control.Content = widget.Content;            
            return control;
        }
    }
}
