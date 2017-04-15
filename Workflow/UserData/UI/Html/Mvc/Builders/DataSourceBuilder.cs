namespace NeuroSystem.Workflow.UserData.UI.Html.Mvc.Builders
{
    /// <summary>
    /// Defines the fluent interface for configuring the <see cref="T:Kendo.Mvc.UI.DataSource" /> component.
    /// </summary>
    public class DataSourceBuilder<TModel>
    where TModel : class
    {
        private DataSource dataSource;

        public DataSourceBuilder(DataSource dataSource)
        {
            this.dataSource = dataSource;
        }

        /// <summary>
        /// Use it to configure Ajax binding.
        /// </summary>        
        public AjaxDataSourceBuilder<TModel> Ajax()
        {
            this.dataSource.Type = new DataSourceType?(DataSourceType.Ajax);
            return new AjaxDataSourceBuilder<TModel>(this.dataSource);
        }

    }
}
