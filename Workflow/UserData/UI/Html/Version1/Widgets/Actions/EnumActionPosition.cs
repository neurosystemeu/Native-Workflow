using System;

namespace NeuroSystem.Workflow.UserData.UI.Html.Version1.Widgets.Actions
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
