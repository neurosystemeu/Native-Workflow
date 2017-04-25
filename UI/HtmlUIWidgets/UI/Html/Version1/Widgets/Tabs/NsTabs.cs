using System.Linq;
using System.Web.UI;
using NeuroSystem.Workflow.UserData.UI.Html.Version1.Widgets.Panels;
using Telerik.Web.UI;
using Panel = NeuroSystem.Workflow.UserData.UI.Html.Version1.Widgets.Panels.Panel;

namespace NeuroSystem.Workflow.UserData.UI.Html.Version1.Widgets.Tabs
{
    public class NsTabs : RadTabStrip, IBindingControl
    {
        public WidgetBase Widget { get; set; }

        public RadMultiPage NsMultiPage { get; set; }
        public NsPanel Panel { get; private set; }

        public virtual void LoadToControl()
        {
            foreach (RadPageView view in NsMultiPage.PageViews)
            {
                foreach (Control control in view.Controls)
                {
                    var bindingControl = control as IBindingControl;
                    if (bindingControl != null)
                    {
                        bindingControl.Widget.DataContext = Widget.DataContext;
                        bindingControl.LoadToControl();
                    }
                }
            }
        }

        public virtual void SaveFromControl()
        {
            //Binding.UstawWartosc(OpisPanelu.WidocznoscBinding, this, Visible);
            foreach (RadPageView view in NsMultiPage.PageViews)
            {
                foreach (Control control in view.Controls)
                {
                    var bindingControl = control as IBindingControl;
                    if (bindingControl != null)
                    {
                        bindingControl.SaveFromControl();
                    }
                }
            }
        }

        internal void AddTab(NsPanel tab)
        {
            var t = new RadTab(tab.Widget.Name);

            this.Tabs.Add(t);
            Tabs.First().Selected = true;

            var d = new RadPageView();
            d.Controls.Add(tab);
            NsMultiPage.PageViews.Add(d);
            NsMultiPage.SelectedIndex = 0;

            //paneleTaby.Add(panel);
        }

        #region Kreator

        internal static NsTabs UtworzTabs(TabsWidget panelWidget)
        {
            var panel = NsPanel.UtworzPanel(new Panel());

            var tabs = new NsTabs() {Widget = panelWidget };
            tabs.Panel = panel;
            tabs.ID = "RadTabStrip1";
            tabs.MultiPageID = "RadMultiPage1";

            var multi = new RadMultiPage();
            multi.ID = "RadMultiPage1";
            tabs.NsMultiPage = multi;

            panel.Controls.Add(tabs);
            panel.Controls.Add(tabs.NsMultiPage);


            return tabs;
        }
        #endregion
    }
}
