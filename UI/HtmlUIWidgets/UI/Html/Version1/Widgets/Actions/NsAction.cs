using System;
using NeuroSystem.Workflow.UserData.UI.Html.Version1.ViewModel;
using Telerik.Web.UI;

namespace NeuroSystem.Workflow.UserData.UI.Html.Version1.Widgets.Actions
{
    public class NsAction : RadButton, IBindingControl
    {
        public NsAction()
        {
            Click += NsAction_Click;
        }

        private void NsAction_Click(object sender, EventArgs e)
        {
            var action = Widget as Action;
            if (action != null && action.Viewer != null)
            {
                action.Viewer.ActionExecuted(action.Name);
            }
        }

        public WidgetBase Widget { get; set; }

        public void LoadToControl()
        {
            var action = Widget as Action;
            Text = Binding.PobierzWartosc(action.Label, Widget.DataContext)?.ToString();
        }

        public void SaveFromControl()
        {
            var action = Widget as Action;
            if (action != null && action.Viewer != null)
            {
                action.Viewer = null;
            }
        }
    }
}
