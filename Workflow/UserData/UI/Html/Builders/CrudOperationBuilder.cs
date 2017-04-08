using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuroSystem.Workflow.UserData.UI.Html.Builders
{
    /// <summary>
    /// Defines the fluent interface for configuring the <see cref="T:Kendo.Mvc.UI.CrudOperation" /> options.
    /// </summary>
    public class CrudOperationBuilder : CrudOperationBuilderBase<CrudOperationBuilder>
    {
        public CrudOperationBuilder(CrudOperation operation) : base(operation)
        {
        }
    }
}
