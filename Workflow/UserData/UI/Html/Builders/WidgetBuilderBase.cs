using NeuroSystem.Workflow.UserData.UI.Html.Widgets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuroSystem.Workflow.UserData.UI.Html.Builders
{
    public abstract class WidgetBuilderBase<TViewComponent, TBuilder> 
    where TViewComponent : WidgetBase
    where TBuilder : WidgetBuilderBase<TViewComponent, TBuilder>
    {
        /// <summary>
        /// Gets the view component.
        /// </summary>
        /// <value>The component.</value>
        protected internal TViewComponent Component { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:Kendo.Mvc.UI.Fluent.WidgetBuilderBase`2" /> class.
        /// </summary>
        /// <param name="component">The component.</param>
        public WidgetBuilderBase(TViewComponent component)
        {
            this.Component = component;
        }

        /// <summary>
        /// Sets the name of the component.
        /// </summary>
        /// <param name="componentName">The name.</param>
        /// <returns></returns>
        public virtual TBuilder Name(string componentName)
        {
            this.Component.Name = componentName;
            return (TBuilder)(this as TBuilder);
        }
    }
}
