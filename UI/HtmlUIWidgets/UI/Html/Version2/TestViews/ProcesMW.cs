using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using NeuroSystem.Workflow.UserData.UI.Html.ASP.UI.Html.Version2.Extensions;

namespace NeuroSystem.Workflow.UserData.UI.Html.ASP.UI.Html.Version2.TestViews
{
    public class ProcesMW
    {
        public HtmlString GetProcessViewHtml()
        {
            var testView = new TestView();
            var panel = testView.GetView();
            var c = panel.ToControl();
            var str= c.ToHtmlString();
            return new HtmlString(str);
        }
    }
}
