using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NeuroSystem.Workflow.UserData.UI.Html.Mvc.Extensions;

namespace NeuroSystem.Workflow.UserData.UI.Html.Mvc
{
    /// <summary>
    /// Represents a client-side event handler of a Kendo UI widget
    /// </summary>
    public class ClientHandlerDescriptor
    {
        /// <summary>
        /// The name of the JavaScript function which will be called as a handler.
        /// </summary>
        public string HandlerName
        {
            get;
            set;
        }

        /// <summary>
        /// A Razor template delegate.
        /// </summary>
        public Func<object, object> TemplateDelegate
        {
            get;
            set;
        }

        public ClientHandlerDescriptor()
        {
        }

        public bool HasValue()
        {
            if (this.HandlerName.HasValue())
            {
                return true;
            }
            return this.TemplateDelegate != null;
        }
    }
}