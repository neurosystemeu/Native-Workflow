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
using NeuroSystem.Workflow.UserData.UI.Html.ASP.UI.Html.Mvc.Widgets;
using NeuroSystem.Workflow.UserData.UI.Html.ASP.UI.Html.Version2.Extensions;
using NeuroSystem.Workflow.UserData.UI.Html.Mvc.UI;
using WidgetBase = Kendo.Mvc.UI.WidgetBase;

namespace NeuroSystem.Workflow.UserData.UI.Html.ASP.UI.Html.Version2.Widgets
{
    public class NsPanel : Kendo.Mvc.UI.WidgetBase
    {
        public Panel Panel;
        private IUrlGenerator urlGenerator;
        private IList<Kendo.Mvc.UI.WidgetBase> KendoWidgets;
        
        public NsPanel(Panel panel, ViewContext viewContext, IJavaScriptInitializer initializer,
            ViewDataDictionary viewData, IUrlGenerator urlGenerator)
            :base(viewContext, initializer, viewData)
        {
            this.Panel = panel;
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
                var control = item.ToKendoWidget(ViewContext, Initializer, ViewData, urlGenerator);
                control.Render();
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
