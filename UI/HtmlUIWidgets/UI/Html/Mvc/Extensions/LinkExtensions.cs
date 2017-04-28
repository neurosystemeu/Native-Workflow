using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Kendo.Mvc.Infrastructure;
using NeuroSystem.Workflow.UserData.UI.Html.Mvc.UI;
using NeuroSystem.Workflow.UserData.UI.Html.Mvc.Widgets;

namespace NeuroSystem.Workflow.UserData.UI.Html.Mvc.Extensions
{
    public static class LinkExtensions
    {
        public static NsLink ToKendoWidget(this Link widget, HtmlHelper helper,
            IJavaScriptInitializer initializer)
        {
            var control = new NsLink(widget, helper, initializer);
            control.Name = widget.Name;
            control.Content = widget.Content;
            return control;
        }
    }
}
