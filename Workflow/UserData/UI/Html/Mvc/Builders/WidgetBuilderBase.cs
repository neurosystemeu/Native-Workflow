using System.Collections.Generic;
using NeuroSystem.Workflow.UserData.UI.Html.Mvc.Extensions;
using NeuroSystem.Workflow.UserData.UI.Html.Mvc.Widgets;

namespace NeuroSystem.Workflow.UserData.UI.Html.Mvc.Builders
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

        public virtual TBuilder HtmlAttributes(string key, string value)
        {
            Component.HtmlAttributes[key] = value;
            return (TBuilder)(this as TBuilder);
        }

        /// <summary>
        /// Sets the HTML attributes.
        /// </summary>
        /// <param name="attributes">The HTML attributes.</param>
        /// <returns></returns>
        public virtual TBuilder HtmlAttributes(object attributes)
        {
            return this.HtmlAttributes(attributes.ToDictionary());
        }

        /// <summary>
        /// Sets the HTML attributes.
        /// </summary>
        /// <param name="attributes">The HTML attributes.</param>
        /// <returns></returns>
        public virtual TBuilder HtmlAttributes(IDictionary<string, object> attributes)
        {
            this.Component.HtmlAttributes.Clear();
            this.Component.HtmlAttributes.Merge(attributes);
            return (TBuilder)(this as TBuilder);
        }


        /// <summary>
        /// Returns the internal view component.
        /// </summary>
        /// <returns></returns>
        public TViewComponent ToComponent()
        {
            return this.Component;
        }

        public virtual string ToHtmlString()
        {
            return this.ToComponent().ToHtmlString();
        }

        public override string ToString()
        {
            return this.ToHtmlString();
        }
    }
}
