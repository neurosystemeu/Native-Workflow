using NeuroSystem.Workflow.UserData.UI.Html.Mvc.Widgets;

namespace NeuroSystem.Workflow.UserData.UI.Html.Mvc.Builders
{
    /// <summary>
    /// Defines the fluent interface for configuring the <see cref="T:Kendo.Mvc.UI.AutoComplete" /> component.
    /// </summary>
    public class AutoCompleteBuilder : DropDownListBuilderBase<AutoComplete, AutoCompleteBuilder>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:Kendo.Mvc.UI.Fluent.AutoCompleteBuilder" /> class.
        /// </summary>
        /// <param name="component">The component.</param>
        public AutoCompleteBuilder(AutoComplete component) : base(component)
        {
        }
    }
}
