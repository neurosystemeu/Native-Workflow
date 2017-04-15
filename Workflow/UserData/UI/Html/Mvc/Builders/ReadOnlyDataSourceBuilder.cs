using System;

namespace NeuroSystem.Workflow.UserData.UI.Html.Mvc.Builders
{
    public class ReadOnlyDataSourceBuilder
    {
        private object dataSource;

        public ReadOnlyDataSourceBuilder(object dataSource)
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
    }
}
