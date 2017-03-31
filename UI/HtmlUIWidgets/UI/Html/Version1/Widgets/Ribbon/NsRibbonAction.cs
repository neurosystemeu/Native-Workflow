using Telerik.Web.UI;
using Action = NeuroSystem.Workflow.UserData.UI.Html.Version1.Widgets.Actions.Action;

namespace NeuroSystem.Workflow.UserData.UI.Html.ASP.UI.Html.Version1.Widgets.Ribbon
{
    public class NsRibbonAction : RibbonBarButton
    {
        public NsRibbonAction()
        {

        }

        public Action Widget { get; set; }
    }
}