namespace NeuroSystem.Workflow.UserData.UI.Html.Version1.Widgets.DataForms
{
    public class NsLabel : System.Web.UI.WebControls.Label
    {

        public static NsLabel CreateLabel(WidgetBase widget)
        {
            var l = new NsLabel();
            l.Text = widget.Label?.ToString();
            return l;
        }
    }
}
