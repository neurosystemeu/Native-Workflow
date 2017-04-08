using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;
using NeuroSystem.Workflow.UserData.UI.Html.ASP.UI.Html.Version2.Extensions;
using NeuroSystem.Workflow.UserData.UI.Html.Widgets;

namespace NeuroSystem.Workflow.UserData.UI.Html.ASP.UI.Html.Version2.Widgets
{
    public class NsPanel
    {
        private Panel panel;

        public NsPanel(Panel panel)
        {
            this.panel = panel;
        }

        /// <summary>
        /// Writes the HTML.
        /// </summary>
        protected virtual void WriteHtml(HtmlTextWriter writer)
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
                var control = item.ToControl();
                control.WriteHtml(writer);
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
