using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NeuroSystem.Workflow.UserData.UI.Html.Mvc.UI;

namespace NeuroSystem.Workflow.UserData.UI.Html.Mvc.Fluent
{
    public class DatePickerBuilderBase<TPicker, TPickerBuilder> : WidgetBuilderBase<TPicker, TPickerBuilder>
    where TPicker : DatePickerBase
    where TPickerBuilder : WidgetBuilderBase<TPicker, TPickerBuilder>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:Kendo.Mvc.UI.Fluent.DatePickerBuilderBase`2" /> class.
        /// </summary>
        /// <param name="component">The component.</param>
        public DatePickerBuilderBase(TPicker component) : base(component)
        {
        }

        /// <summary>
        /// Sets the value of the picker input
        /// </summary>
        public TPickerBuilder Value(DateTime? date)
        {
            base.Component.Value = date;
            return (TPickerBuilder)(this as TPickerBuilder);
        }
    }
}
