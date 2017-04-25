using System.Collections.Generic;
using System.IO;
using System.Web.Mvc;
using System.Web.UI;
using Kendo.Mvc;
using Kendo.Mvc.Infrastructure;
using NeuroSystem.Workflow.UserData.UI.Html.Mvc.Extensions;
using NeuroSystem.Workflow.UserData.UI.Html.Mvc.UI;
using WidgetBase = Kendo.Mvc.UI.WidgetBase;

namespace NeuroSystem.Workflow.UserData.UI.Html.Mvc.Widgets
{
    public class NsPanel : Kendo.Mvc.UI.WidgetBase
    {
        public Panel Panel;
        private IUrlGenerator urlGenerator;
        private IList<Kendo.Mvc.UI.WidgetBase> KendoWidgets;
        private HtmlHelper helper;

        public NsPanel(Panel panel, HtmlHelper helper, 
            IJavaScriptInitializer initializer,
            IUrlGenerator urlGenerator)
            :base(helper.ViewContext, initializer, helper.ViewData)
        {
            this.Panel = panel;
            this.helper = helper;
            this.urlGenerator = urlGenerator;
            KendoWidgets = new List<WidgetBase>();
        }

        public void Class(string htmlClass)
        {
            Panel.Class(htmlClass);
        }

        /// <summary>
        /// Writes the HTML.
        /// </summary>
        protected override void WriteHtml(HtmlTextWriter writer)
        {
            writer.WriteBeginTag("div");
            foreach (var key in Panel.HtmlAttributes.Keys)
            {
                writer.WriteAttribute(key, Panel.HtmlAttributes[key].ToString());
            }
            writer.Write(">");

            //renderuje itemy
            foreach (var item in Panel.Items)
            {
                var control = item.ToKendoWidget(helper, Initializer, urlGenerator);
                var html = control.ToHtmlString();
                writer.Write(html);
            }

            if(Panel.HtmlContent != null)
            {
                writer.Write(Panel.HtmlContent);
            }

            foreach (var kendoWidget in KendoWidgets)
            {
                writer.Write(kendoWidget.ToHtmlString());
            }

            writer.WriteEndTag("div");
        }

        public new string ToHtmlString()
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

        internal void AddItem(Kendo.Mvc.UI.WidgetBase nsLabel)
        {
            KendoWidgets.Add(nsLabel);
        }
    }


}
