using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telerik.Web.UI;
using Action = NeuroSystem.Workflow.UserData.UI.Html.Widgets.Actions.Action;

namespace NeuroSystem.Workflow.UserData.UI.Html.ASP.UI.Html.Widgets.Ribbon
{
    public class NsRibbonAction : RibbonBarButton
    {
        public NsRibbonAction()
        {

        }

        public Action Widget { get; set; }
    }
}