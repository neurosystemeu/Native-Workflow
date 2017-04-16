using System;

namespace NeuroSystem.Workflow.UserData.UI.Html.Mvc.Fluent
{
    /// <summary>    
    /// Defines the fluent interface for configuring the <see cref="T:Kendo.Mvc.UI.DataSource" /> options.
    /// </summary>    
    public abstract class AjaxDataSourceBuilderBase<TModel, TDataSourceBuilder> 
    where TModel : class
    where TDataSourceBuilder : AjaxDataSourceBuilderBase<TModel, TDataSourceBuilder>
    {
        protected readonly DataSource dataSource;

        public AjaxDataSourceBuilderBase(DataSource dataSource)
        {
            this.dataSource = dataSource;
        }

        /// <summary>
        /// Configures the initial aggregates.
        /// </summary>
        public virtual TDataSourceBuilder Aggregates(Action<DataSourceAggregateDescriptorFactory<TModel>> aggregates)
        {
            aggregates(new DataSourceAggregateDescriptorFactory<TModel>(this.dataSource.Aggregates));
            return (TDataSourceBuilder)this;
        }

        /// <summary>
        /// Configures the initial filter.
        /// </summary>
        public virtual TDataSourceBuilder Filter(Action<DataSourceFilterDescriptorFactory<TModel>> configurator)
        {
            configurator(new DataSourceFilterDescriptorFactory<TModel>(this.dataSource.Filters));
            return (TDataSourceBuilder)this;
        }

        /// <summary>
        /// Configures Model properties
        /// </summary>                
        public virtual TDataSourceBuilder Model(Action<DataSourceModelDescriptorFactory<TModel>> configurator)
        {
            configurator(new DataSourceModelDescriptorFactory<TModel>(this.dataSource.Schema.Model));
            return (TDataSourceBuilder)this;
        }

        /// <summary>
        /// Sets the number of records displayed on a single page.
        /// </summary>
        /// <param name="pageSize"></param>        
        public TDataSourceBuilder PageSize(int pageSize)
        {
            this.dataSource.PageSize = pageSize;
            return (TDataSourceBuilder)this;
        }

        /// <summary>
        /// Sets controller, action and routeValues for Read operation.
        /// </summary>
        /// <param name="actionName">Action name</param>
        /// <param name="controllerName">Controller Name</param>                
        public TDataSourceBuilder Read(string actionName, string controllerName)
        {
            this.SetOperationUrl(this.dataSource.Transport.Read, actionName, controllerName, null);
            return (TDataSourceBuilder)this;
        }

        protected virtual void SetOperationUrl(CrudOperation operation, string actionName, string controllerName, object routeValues)
        {
            operation.ControllerName = controllerName;
            operation.ActionName = actionName;
            //operation.Url = operation.GenerateUrl(this.viewContext, this.urlGenerator);
        }
    }
}
