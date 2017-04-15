using NeuroSystem.Workflow.UserData.UI.Html.Mvc.Widgets;

namespace NeuroSystem.Workflow.UserData.UI.Html.Mvc.Builders
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
