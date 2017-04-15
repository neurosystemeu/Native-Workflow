using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.UI;
using Kendo.Mvc;
using Kendo.Mvc.Infrastructure;
using NeuroSystem.Workflow.UserData.UI.Html.ASP.UI.Html.Mvc.Extensions;
using NeuroSystem.Workflow.UserData.UI.Html.ASP.UI.Html.Version2.Extensions;
using NeuroSystem.Workflow.UserData.UI.Html.Mvc.Widgets;
using WidgetBase = Kendo.Mvc.UI.WidgetBase;

namespace NeuroSystem.Workflow.UserData.UI.Html.ASP.UI.Html.Version2.Widgets
{
    public class NsPanel : Kendo.Mvc.UI.WidgetBase
    {
        private Panel panel;
        private IUrlGenerator urlGenerator;
        
        public NsPanel(Panel panel, ViewContext viewContext, IJavaScriptInitializer initializer,
            ViewDataDictionary viewData, IUrlGenerator urlGenerator)
            :base(viewContext, initializer, viewData)
        {
            this.panel = panel;
            this.urlGenerator = urlGenerator;
        }

        /// <summary>
        /// Writes the HTML.
        /// </summary>
        protected override void WriteHtml(HtmlTextWriter writer)
        {
            writer.WriteBeginTag("div");
            foreach (var key in panel.HtmlAttributes.Keys)
            {
                writer.WriteAttribute(key, panel.HtmlAttributes[key].ToString());
            }
            writer.Write(">");

            //renderuje itemy
            foreach (var item in panel.Items)
            {
                var control = item.ToKendoWidget(ViewContext, Initializer, ViewData, urlGenerator);
                control.Render();
                
            }

            writer.WriteEndTag("div");
        }

        public string ToHtmlString()
        {
            string str;
            using (StringWriter stringWriter = new StringWriter())
            {
                HtmlTextWriter htmlTextWriter = new HtmlTextWriter(stringWriter);
                this.WriteHtml(htmlTextWriter);
                str = stringWriter.ToString();
            }
            return str;
        }
    }


}
