using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuroSystem.Workflow.UserData.UI.Html.Extensions
{
    internal static class ObjectExtensions
    {
        public static IDictionary<string, object> ToDictionary(this object @object)
        {
            Dictionary<string, object> strs = new Dictionary<string, object>(StringComparer.CurrentCultureIgnoreCase);
            if (@object != null)
            {
                foreach (PropertyDescriptor property in TypeDescriptor.GetProperties(@object))
                {
                    strs.Add(property.Name.Replace("_", "-"), property.GetValue(@object));
                }
            }
            return strs;
        }
    }
}
