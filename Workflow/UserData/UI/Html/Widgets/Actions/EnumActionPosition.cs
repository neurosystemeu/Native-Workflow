using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuroSystem.Workflow.UserData.UI.Html.Widgets.Actions
{
    [Flags]
    public enum EnumActionPosition
    {
        TopAndBottom = 3,

        Bottom = 1,

        Top = 2,

        Ribbon = 4,

        /// <summary>
        /// Element generowany jako pole elementu w strukturze widoku
        /// </summary>
        Inline = 0
    }
}
