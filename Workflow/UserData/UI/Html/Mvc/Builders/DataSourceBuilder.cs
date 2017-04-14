using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NeuroSystem.Workflow.UserData.UI.Html.Version2.Builders;
using NeuroSystem.Workflow.UserData.UI.Html.Widgets;

namespace NeuroSystem.Workflow.UserData.UI.Html.Builders
{
    /// <summary>
    /// Defines the fluent interface for configuring the <see cref="T:Kendo.Mvc.UI.DataSource" /> component.
    /// </summary>
    public class DataSourceBuilder<TModel>
    where TModel : class
    {
        private Widgets.DataSource dataSource;

        public DataSourceBuilder(Widgets.DataSource dataSource)
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
