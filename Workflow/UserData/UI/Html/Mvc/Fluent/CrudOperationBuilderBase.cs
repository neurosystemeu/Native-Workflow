namespace NeuroSystem.Workflow.UserData.UI.Html.Mvc.Fluent
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
