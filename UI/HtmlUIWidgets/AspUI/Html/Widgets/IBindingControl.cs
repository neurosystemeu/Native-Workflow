using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NeuroSystem.Workflow.UserData.UI.Html.Widgets;

namespace NeuroSystem.UI.HtmlUIWidgets.AspUI.Html.Widgets
{
    public interface IBindingControl : IWidgetControl
    {
        void WczytajDoKontrolkiZMW();
        void ZapiszDoMWZKontrolki();
    }
}
