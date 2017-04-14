using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Kendo.Mvc.Infrastructure;
using NeuroSystem.Workflow.UserData.UI.Html.ASP.UI.Html.Version2.Extensions;

namespace NeuroSystem.Workflow.UserData.UI.Html.ASP.UI.Html.Version2.TestViews
{
    public class ProcesMW
    {
        private Controller procesController;

        public ProcesMW(Controller procesController)
        {
            this.procesController = procesController;
        }

        //public HtmlString GetProcessViewHtml()
        //{
        //    //var viewContext = procesController.ControllerContext as ViewContext;
            
        //    //var testView = new TestView();
        //    //var panel = testView.GetView();
        //    //var c = panel.ToKendoWidget(viewContext, new JavaScriptInitializer(), new ViewDataDictionary());
        //    //var str= c.ToHtmlString();
        //    //return new HtmlString(str);
        //}
    }
}
