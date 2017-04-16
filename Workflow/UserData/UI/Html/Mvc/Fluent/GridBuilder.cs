using System;
using NeuroSystem.Workflow.UserData.UI.Html.Mvc.UI;

namespace NeuroSystem.Workflow.UserData.UI.Html.Mvc.Fluent
{
    /// <summary>
    /// The fluent API for configuring Kendo UI Grid for ASP.NET MVC.
    /// </summary>
    public class GridBuilder<T> : WidgetBuilderBase<Grid<T>, GridBuilder<T>>
    where T : class
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:Kendo.Mvc.UI.Fluent.GridBuilder`1" /> class.
        /// </summary>
        /// <param name="component">The component.</param>
        public GridBuilder(Grid<T> component) : base(component)
        {
        }


        /// <summary>
        /// Sets the data source configuration of the grid.
        /// </summary>
        /// <param name="configurator">The lambda which configures the data source</param>
        /// <example>
        /// <code lang="Razor">
        /// @(Html.Kendo().Grid&lt;Product&gt;()
        ///     .Name("grid")
        ///     .DataSource(dataSource =&gt;
        ///         // configure the data source
        ///         dataSource
        ///             .Ajax()
        ///             .Read(read =&gt; read.Action("Products_Read", "Home"))
        ///     )
        /// )
        /// </code>
        /// <code lang="ASPX">
        /// &lt;%:Html.Kendo().Grid&lt;Product&gt;()
        ///     .Name("grid")
        ///     .DataSource(dataSource =&gt;
        ///         // configure the data source
        ///         dataSource
        ///             .Ajax()
        ///             .Read(read =&gt; read.Action("Products_Read", "Home"))
        ///     )
        /// %&gt;
        /// </code>
        /// </example>
        public GridBuilder<T> DataSource(Action<DataSourceBuilder<T>> configurator)
        {
            configurator(new DataSourceBuilder<T>(base.Component.DataSource));
            return this;
        }
    }
}
