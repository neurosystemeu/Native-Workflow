using System;

namespace NeuroSystem.Workflow.UserData.UI.Html.Mvc.Fluent
{
    public class ReadOnlyDataSourceBuilder
    {
        private DataSource dataSource;

        public ReadOnlyDataSourceBuilder(DataSource dataSource)
        {
            this.dataSource = dataSource;
        }

        /// <summary>
        /// Configures the URL for Read operation.
        /// </summary> 
        public ReadOnlyDataSourceBuilder Read(Action<CrudOperationBuilder> configurator)
        {
            //configurator(new CrudOperationBuilder(this.dataSource.Transport.Read, this.viewContext, this.urlGenerator));
            return this;
        }

        /// <summary>
        /// Sets controller, action and routeValues for Read operation.
        /// </summary>
        /// <param name="actionName">Action name</param>
        /// <param name="controllerName">Controller Name</param>                
        public ReadOnlyDataSourceBuilder Read(string actionName, string controllerName)
        {
            this.SetOperationUrl(this.dataSource.Transport.Read, actionName, controllerName, null);
            return this;
        }

        protected virtual void SetOperationUrl(CrudOperation operation, string actionName, string controllerName, object routeValues)
        {
            operation.ControllerName = controllerName;
            operation.ActionName = actionName;
            //operation.Url = operation.GenerateUrl(this.viewContext, this.urlGenerator);
        }
    }
}
