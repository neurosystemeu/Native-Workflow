using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NeuroSystem.Workflow.UserData.UI.Html.Widgets;

namespace NeuroSystem.Workflow.UserData.UI.Html.Builders
{
    public class WidgetFactory
    {
        public object Helper;

        public WidgetFactory()
        {
        }

        public WidgetFactory(object helper)
        {
            this.Helper = helper;
        }

        /// <summary>
        /// Creates a new <see cref="M:Kendo.Mvc.UI.Fluent.WidgetFactory.AutoComplete" />.
        /// </summary>
        /// <example>
        /// <code lang="CS">
        ///  &lt;%= Html.Kendo().AutoComplete()
        ///             .Name("AutoComplete")
        ///             .Items(items =&gt;
        ///             {
        ///                 items.Add().Text("First Item");
        ///                 items.Add().Text("Second Item");
        ///             })
        /// %&gt;
        /// </code>
        /// </example>
        public virtual AutoCompleteBuilder AutoComplete()
        {
            return new AutoCompleteBuilder(new AutoComplete());
        }

        public virtual PanelBuilder Panel()
        {
            return new PanelBuilder(new Panel());
        }

        public virtual PanelBuilder<T> Panel<T>()
        {
            return new PanelBuilder<T>(new Panel<T>());
        }

        /// <summary>
        /// Creates a new <see cref="M:Kendo.Mvc.UI.Fluent.WidgetFactory.TextBox" />.
        /// </summary>
        /// <example>
        /// <code lang="CS">
        ///  &lt;%= Html.Kendo().TextBox()
        ///             .Name("TextBox")
        /// %&gt;
        /// </code>
        /// </example>
        public virtual TextBoxBuilder<string> TextBox()
        {
            return new TextBoxBuilder<string>(new TextBox<string>());
        }

        /// <summary>
        /// Creates a new <see cref="M:Kendo.Mvc.UI.Fluent.WidgetFactory.TextBox``1" />.
        /// </summary>
        /// <example>
        /// <code lang="CS">
        ///  &lt;%= Html.Kendo().TextBox&lt;double&gt;()
        ///             .Name("TextBox")
        /// %&gt;
        /// </code>
        /// </example>
        public virtual TextBoxBuilder<T> TextBox<T>()
        {
            return new TextBoxBuilder<T>(new TextBox<T>());
        }

        public object Process()
        {
            return "Proces :)";
        }
    }
}
