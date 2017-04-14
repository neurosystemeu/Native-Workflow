using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuroSystem.Workflow.UserData.UI.Html.Version2
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