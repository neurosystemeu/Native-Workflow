using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NeuroSystem.Workflow.UserData.UI.Html.Mvc.UI;

namespace NeuroSystem.Workflow.UserData.UI.Html.Mvc.Fluent
{
    /// <summary>
    /// Defines the fluent interface for configuring the <see cref="T:Kendo.Mvc.UI.DatePicker" /> component.
    /// </summary>
    public class DatePickerBuilder : DatePickerBuilderBase<DatePicker, DatePickerBuilder>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:Kendo.Mvc.UI.Fluent.DatePickerBuilder" /> class.
        /// </summary>
        /// <param name="component">The component.</param>
        public DatePickerBuilder(DatePicker component) : base(component)
        {
        }
    }
}
