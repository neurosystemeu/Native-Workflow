using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using NeuroSystem.Workflow.UserData.UI.Html.Version1.Widgets;
using NeuroSystem.Workflow.UserData.UI.Html.Version1.Widgets.Panels;
using Telerik.Web.UI;
using Panel = System.Web.UI.WebControls.Panel;

namespace NeuroSystem.Workflow.UserData.UI.Html.ASP.UI.Html.Widgets
{
    public class NsPanel : Panel, IBindingControl
    {
        public NsPanel()
        {
        }

        public WidgetBase Widget { get; set; }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
        }

        
        public virtual void LoadToControl()
        {
            foreach (var control in Controls)
            {
                var bindingControl = control as IBindingControl;
                if (bindingControl != null)
                {
                    bindingControl.Widget.DataContext = Widget.DataContext;
                    bindingControl.LoadToControl();
                }
            }
        }

        public virtual void SaveFromControl()
        {
            //Binding.UstawWartosc(OpisPanelu.WidocznoscBinding, this, Visible);
            foreach (var control in Controls)
            {
                var bindingControl = control as IBindingControl;
                if (bindingControl != null)
                {
                    bindingControl.SaveFromControl();
                }
            }
        }

        internal static NsPanel UtworzPanel(Version1.Widgets.Panels.Panel panelWidget)
        {
            var panel = new NsPanel() { Widget = panelWidget };
            panel.GroupingText = panelWidget.Label?.ToString();
            if (panelWidget.Width != null)
            {
                panel.Width = new Unit(panelWidget.Width.ToString());
            }
            if (panelWidget.Height != null)
            {
                panel.Height = new Unit(panelWidget.Height.ToString());
            }
            if (panelWidget.Float != EnumPanelFloat.None)
            {
                panel.Style["float"] = panelWidget.Float.ToString().ToLower();
            }
            if (panelWidget.Clear != EnumPanelClear.None)
            {
                panel.Style["clear"] = panelWidget.Clear.ToString().ToLower();
            }
            //if (opisPanelu is OpisGrupy)
            //{
            //    panel.GroupingText = opisPanelu.Label;
            //}


            //switch (opisPanelu.Orientacja)
            //{
            //    case EnumOrientacjaPanelu.Flat:
            //        panel.Style["float"] = "left";
            //        break;
            //    case EnumOrientacjaPanelu.Clear:
            //        panel.Style["clear"] = "both";
            //        break;
            //}


            return panel;
        }

        
    }
}
