using System.Collections.Generic;

namespace NeuroSystem.Workflow.UserData.UI.Html.Mvc.Widgets
{
    public class WidgetBase
    {
        public WidgetBase()
        {
            htmlAttributes = new Dictionary<string, object>();
        }

        public string Name { get; set; }

        /// <summary>
        /// Gets the HTML attributes.
        /// </summary>
        /// <value>The HTML attributes.</value>
        public IDictionary<string, object> HtmlAttributes {
            get { return htmlAttributes; }
            set { htmlAttributes = value;} }

        private IDictionary<string, object> htmlAttributes;



        public virtual string ToHtmlString()
        {
            return null;
        }
    }

    public class WidgetBase<T> : WidgetBase
    {
        
    }
}
