using System.Collections.Generic;

namespace NeuroSystem.Workflow.UserData.UI.Html.Mvc.Builders
{
    /// <summary>
    /// Defines the fluent interface for configuring the <see cref="T:Kendo.Mvc.AggregateDescriptor" />.
    /// </summary>    
    public class DataSourceAggregateDescriptorFactory<TModel> 
    where TModel : class
    {
        private readonly IList<AggregateDescriptor> descriptors;

        public DataSourceAggregateDescriptorFactory(IList<AggregateDescriptor> descriptors)
        {
            this.descriptors = descriptors;
        }
    }
}
