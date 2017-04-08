using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NeuroSystem.Workflow.UserData.UI.Html.Widgets;

namespace NeuroSystem.Workflow.UserData.UI.Html.Builders
{
    public class DropDownListBuilderBase<TDropDown, TDropDownBuilder> : ListBuilderBase<TDropDown, TDropDownBuilder>
    where TDropDown : DropDownListBase
    where TDropDownBuilder : WidgetBuilderBase<TDropDown, TDropDownBuilder>
    {
        public DropDownListBuilderBase(TDropDown component) : base(component)
        {
        }
    }
}
