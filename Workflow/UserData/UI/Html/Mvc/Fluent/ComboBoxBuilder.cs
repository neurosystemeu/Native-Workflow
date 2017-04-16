using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NeuroSystem.Workflow.UserData.UI.Html.Mvc.UI;

namespace NeuroSystem.Workflow.UserData.UI.Html.Mvc.Fluent
{
    /// <summary>
    /// Defines the fluent interface for configuring the <see cref="T:Kendo.Mvc.UI.ComboBox" /> component.
    /// </summary>
    public class ComboBoxBuilder : DropDownListBuilderBase<ComboBox, ComboBoxBuilder>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:Kendo.Mvc.UI.Fluent.ComboBoxBuilder" /> class.
        /// </summary>
        /// <param name="component">The component.</param>
        public ComboBoxBuilder(ComboBox component) : base(component)
        {
        }
    }
}
