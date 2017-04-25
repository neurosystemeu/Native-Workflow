using System.Web.Mvc;
using System.Web.UI;
using Kendo.Mvc.Infrastructure;
using NeuroSystem.Workflow.UserData.UI.Html.Mvc.UI;

namespace NeuroSystem.Workflow.UserData.UI.Html.Mvc.Widgets
{
    public class NsLabel : Kendo.Mvc.UI.WidgetBase
    {
        public NsLabel(Label label, HtmlHelper helper) 
            : base(helper.ViewContext, helper.ViewData)
        {
            this.label = label;
        }

        public NsLabel(Label label, HtmlHelper helper, IJavaScriptInitializer initializer) 
            : base(helper.ViewContext, initializer, helper.ViewData)
        {
            this.label = label;
        }

        private Label label;        
        public string Content { get; set; }

        protected override void WriteHtml(HtmlTextWriter writer)
        {
            writer.WriteBeginTag("label");
            foreach (var key in label.HtmlAttributes.Keys)
            {
                writer.WriteAttribute(key, label.HtmlAttributes[key].ToString());
            }
            writer.Write(">");

            writer.Write(Content);

            writer.WriteEndTag("label");
        }
    }
}
