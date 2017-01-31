using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telerik.Web.UI;

namespace NeuroSystem.Workflow.UserData.UI.Html.ASP.UI.Html.Widgets.Ribbon
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