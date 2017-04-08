using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NeuroSystem.Workflow.UserData.UI.Html.Widgets;

namespace NeuroSystem.Workflow.UserData.UI.Html.Builders
{
    public class PanelBuilder : WidgetBuilderBase<Panel, PanelBuilder>
    {
        public PanelBuilder(Panel component) : base(component)
        {
        }

        public PanelBuilder Class(string htmlClass)
        {
            Component.HtmlAttributes.Add("class", htmlClass);
            return this;
        }

        /// <summary>
        /// Defines the items in the ComboBox
        /// </summary>
        /// <param name="addAction">The add action.</param>
        /// <example>
        /// <code lang="CS">
        ///  &lt;%= Html.Telerik().ComboBox()
        ///             .Name("ComboBox")
        ///             .AddItem(items =&gt;
        ///             {
        ///                 items.Text("First Item");                 
        ///             })
        /// %&gt;
        /// </code>
        /// </example>
        public PanelBuilder AddItem(Action<PanelBuilder> addAction)
        {
            var panel = new Panel();
            var factory = new PanelBuilder(panel);
            Component.Items.Add(panel);
            addAction(factory);
            return this;
        }

        /// <summary>
        /// Defines the items in the ComboBox
        /// </summary>
        /// <param name="addAction">The add action.</param>
        /// <example>
        /// <code lang="CS">
        ///  &lt;%= Html.Telerik().ComboBox()
        ///             .Name("ComboBox")
        ///             .AddItem(items =&gt;
        ///             {
        ///                 items.Text("First Item");                 
        ///             })
        /// %&gt;
        /// </code>
        /// </example>
        public PanelBuilder AddItem(WidgetBase widget)
        {
            Component.Items.Add(widget);
            return this;
        }

        /// <summary>
        /// Defines the items in the tabstrip
        /// </summary>
        /// <param name="addAction">The add action.</param>
        /// <example>
        /// <code lang="CS">
        ///  &lt;%= Html.Kendo().TabStrip()
        ///             .Name("TabStrip")
        ///             .Items(items =&gt;
        ///             {
        ///                 items.Add().Text("First Item");
        ///                 items.Add().Text("Second Item");
        ///             })
        /// %&gt;
        /// </code>
        /// </example>
        public PanelBuilder Items(Action<PanelItemFactory> addAction)
        {
            addAction(new PanelItemFactory(base.Component, this));
            return this;
        }
    }
}