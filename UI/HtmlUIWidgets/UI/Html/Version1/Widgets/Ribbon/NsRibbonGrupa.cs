using Telerik.Web.UI;

namespace NeuroSystem.Workflow.UserData.UI.Html.ASP.UI.Html.Version1.Widgets.Ribbon
{
    public class NsRibbonGrupa : RibbonBarGroup
    {
        public void DodajAkcje(NsRibbonAction akcja)
        {
            this.Items.Add(akcja);
        }

        public string Nazwa { get; set; }
    }
}