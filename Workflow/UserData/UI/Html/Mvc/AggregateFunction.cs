using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using NeuroSystem.Workflow.UserData.UI.Html.Widgets;

namespace NeuroSystem.Workflow.UserData.UI.Html.Version2
{
    /// <summary>
    ///  Represents an aggregate function.
    /// </summary>
    public class AggregateFunction : JsonObject
    {
        /// <summary>
        /// Gets or sets the name of the aggregate function, which appears as a property of the group record on which records the function works.
        /// </summary>
        /// <value>The name of the function as visible from the group record.</value>
        public virtual string FunctionName { get; set; }

        public Type MemberType
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets a string that is used to format the result value.
        /// </summary>
        /// <value>The format string.</value>
        public virtual string ResultFormatString
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the name of the field, of the item from the set of items, which value is used as the argument of the aggregate function.
        /// </summary>
        /// <value>The name of the field to get the argument value from.</value>
        public virtual string SourceField
        {
            get;
            set;
        }
    }
}