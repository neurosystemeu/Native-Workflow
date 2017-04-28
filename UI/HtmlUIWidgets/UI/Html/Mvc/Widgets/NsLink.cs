using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using Kendo.Mvc.Infrastructure;
using NeuroSystem.Workflow.UserData.UI.Html.Mvc.UI;

namespace NeuroSystem.Workflow.UserData.UI.Html.Mvc.Widgets
{
    public class NsLink : Kendo.Mvc.UI.WidgetBase
    {
        public NsLink(Link link, HtmlHelper helper) 
            : base(helper.ViewContext, helper.ViewData)
        {
            this.link = link;
            this.helper = helper;
        }

        public NsLink(Link link, HtmlHelper helper, IJavaScriptInitializer initializer) 
            : base(helper.ViewContext, initializer, helper.ViewData)
        {
            this.link = link;
        }

        private HtmlHelper helper;
        private Link link;
        public string Content { get; set; }

        protected override void WriteHtml(HtmlTextWriter writer)
        {
            var url = link.NavigateUrl.Replace("~/", GetBaseUrl());
            link.HtmlAttributes["href"] = url;
            writer.WriteBeginTag("a");
            foreach (var key in link.HtmlAttributes.Keys)
            {
                writer.WriteAttribute(key, link.HtmlAttributes[key].ToString());
            }
            writer.Write(">");

            writer.Write(Content);

            writer.WriteEndTag("a");
        }

        public string GetBaseUrl()
        {
            var request = HttpContext.Current.Request;
            var appUrl = HttpRuntime.AppDomainAppVirtualPath;

            if (appUrl != "/")
                appUrl = "/" + appUrl;

            var baseUrl = string.Format("{0}://{1}{2}", request.Url.Scheme, request.Url.Authority, appUrl);

            return baseUrl;
        }
    }
}
