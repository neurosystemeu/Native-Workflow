using System.Collections.Generic;

namespace NeuroSystem.Workflow.UserData.UI.Html.Mvc.Fluent
{
    /// <summary>
    /// Defines the fluent interface for configuring filter.
    /// </summary>    
    public abstract class DataSourceFilterDescriptorFactoryBase
    {
        protected IList<IFilterDescriptor> Filters
        {
            get;
            private set;
        }

        public DataSourceFilterDescriptorFactoryBase(IList<IFilterDescriptor> filters)
        {
            this.Filters = filters;
        }

        public virtual void AddRange(IEnumerable<IFilterDescriptor> filters)
        {
            
        }
    }
}