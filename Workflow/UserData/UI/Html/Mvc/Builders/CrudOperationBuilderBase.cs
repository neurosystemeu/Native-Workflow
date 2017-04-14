using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuroSystem.Workflow.UserData.UI.Html.Builders
{
    public abstract class CrudOperationBuilderBase<TCrudOperationBuilder>
        where TCrudOperationBuilder : CrudOperationBuilderBase<TCrudOperationBuilder>
    {
        protected readonly CrudOperation operation;

        public CrudOperationBuilderBase(CrudOperation operation)
        {
            this.operation = operation;
        }
    }
}
