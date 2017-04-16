using NeuroSystem.Workflow.UserData.UI.Html.Mvc.UI;

namespace NeuroSystem.Workflow.UserData.UI.Html.Mvc.Fluent
{
    /// <summary>
    /// Defines the fluent interface for configuring the <see cref="T:Kendo.Mvc.UI.DataSource" /> Model definition.
    /// </summary>
    /// <typeparam name="TModel">Type of the model</typeparam>
    public class DataSourceModelDescriptorFactory<TModel> : DataSourceModelDescriptorFactoryBase<TModel>
    where TModel : class
    {
        public DataSourceModelDescriptorFactory(ModelDescriptor model) : base(model)
        {
        }

        /// <summary>
        /// Specify the member used to identify an unique Model instance.
        /// </summary>
        /// <param name="fieldName">The member name.</param>
        public new void Id(string fieldName)
        {
            base.Id(fieldName);
        }
    }
}
