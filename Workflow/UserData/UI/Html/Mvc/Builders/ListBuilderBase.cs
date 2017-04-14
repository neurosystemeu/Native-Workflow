using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NeuroSystem.Workflow.UserData.UI.Html.Widgets;

namespace NeuroSystem.Workflow.UserData.UI.Html.Builders
{
    public class ListBuilderBase<TDropDown, TDropDownBuilder> : WidgetBuilderBase<TDropDown, TDropDownBuilder>
    where TDropDown : ListBase
    where TDropDownBuilder : WidgetBuilderBase<TDropDown, TDropDownBuilder>
    {
        public ListBuilderBase(TDropDown component) : base(component)
        {
        }

        /// <summary>
        /// Configures the DataSource options.
        /// </summary>
        /// <param name="configurator">The DataSource configurator action.</param>
        /// <example>
        /// <code lang="CS">
        ///  &lt;%= Html.Kendo().DropDownList()
        ///             .Name("DropDownList")
        ///             .DataSource(source =&gt;
        ///             {
        ///                 source.Read(read =&gt;
        ///                 {
        ///                     read.Action("GetProducts", "Home");
        ///                 }
        ///             })
        /// %&gt;
        /// </code>
        /// </example>
        public TDropDownBuilder DataSource(Action<ReadOnlyDataSourceBuilder> configurator)
        {
            configurator(new ReadOnlyDataSourceBuilder(base.Component.DataSource));
            return (TDropDownBuilder)(this as TDropDownBuilder);
        }
    }
}
