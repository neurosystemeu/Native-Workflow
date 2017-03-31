using System.Web.UI.WebControls;
using NeuroSystem.Workflow.UserData.UI.Html.Version1.Widgets;

namespace NeuroSystem.Workflow.UserData.UI.Html.ASP.UI.Html.Version1.Widgets.DataForms
{
    public class NsLabel : Label
    {

        public static NsLabel CreateLabel(WidgetBase widget)
        {
            var l = new NsLabel();
            l.Text = widget.Label?.ToString();
            return l;
        }
    }
}
