namespace NeuroSystem.Workflow.UserData.UI.Html.Mvc.Builders
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
