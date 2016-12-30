using System;
using NeuroSystem.Workflow.UserData.UI.Html.ViewModel;
using NeuroSystem.Workflow.UserData.UI.Html.Widgets;
using Telerik.Web.UI;
using Action = NeuroSystem.Workflow.UserData.UI.Html.Widgets.Actions.Action;

namespace NeuroSystem.Workflow.UserData.UI.Html.ASP.UI.Html.Widgets.Actions
{
    public class NsAction : RadButton, IBindingControl
    {
        public NsAction()
        {
            Click += NsAction_Click;
        }

        private void NsAction_Click(object sender, EventArgs e)
        {
            
        }

        public WidgetBase Widget { get; set; }

        public void WczytajDoKontrolkiZMW()
        {
            var action = Widget as Action;
            Text = Binding.PobierzWartosc(action.Label, Widget.DataContext)?.ToString();
        }

        public void ZapiszDoMWZKontrolki()
        {
            
        }
    }
}
