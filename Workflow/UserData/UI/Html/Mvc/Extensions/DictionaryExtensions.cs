using System.Collections.Generic;

namespace NeuroSystem.Workflow.UserData.UI.Html.Mvc.Extensions
{
    public static class DictionaryExtensions
    {
        /// <summary>
        /// Appends the in value.
        /// </summary>
        /// <param name="instance">The instance.</param>
        /// <param name="key">The key.</param>
        /// <param name="separator">The separator.</param>
        /// <param name="value">The value.</param>
        public static void AppendInValue(this IDictionary<string, object> instance, string key, string separator, object value)
        {
            instance[key] = (instance.ContainsKey(key) ? string.Concat(instance[key], separator, value) : value.ToString());
        }

        /// <summary>
        /// Merges the specified instance.
        /// </summary>
        /// <param name="instance">The instance.</param>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        /// <param name="replaceExisting">if set to <c>true</c> [replace existing].</param>
        public static void Merge(this IDictionary<string, object> instance, string key, object value, bool replaceExisting)
        {
            if (replaceExisting || !instance.ContainsKey(key))
            {
                instance[key] = value;
            }
        }

        /// <summary>
        /// Merges the specified instance.
        /// </summary>
        /// <param name="instance">The instance.</param>
        /// <param name="from">From.</param>
        /// <param name="replaceExisting">if set to <c>true</c> [replace existing].</param>
        public static void Merge(this IDictionary<string, object> instance, IDictionary<string, object> from, bool replaceExisting)
        {
            foreach (KeyValuePair<string, object> value in from)
            {
                if (!replaceExisting && instance.ContainsKey(value.Key))
                {
                    continue;
                }
                instance[value.Key] = value.Value;
            }
        }

        /// <summary>
        /// Merges the specified instance.
        /// </summary>
        /// <param name="instance">The instance.</param>
        /// <param name="from">From.</param>
        public static void Merge(this IDictionary<string, object> instance, IDictionary<string, object> from)
        {
            instance.Merge(from, true);
        }

        ///// <summary>
        ///// Merges the specified instance.
        ///// </summary>
        ///// <param name="instance">The instance.</param>
        ///// <param name="values">The values.</param>
        ///// <param name="replaceExisting">if set to <c>true</c> [replace existing].</param>
        //public static void Merge(this IDictionary<string, object> instance, object values, bool replaceExisting)
        //{
        //    instance.Merge((IDictionary<string, object>)(new RouteValueDictionary(values)), replaceExisting);
        //}

        ///// <summary>
        ///// Merges the specified instance.
        ///// </summary>
        ///// <param name="instance">The instance.</param>
        ///// <param name="values">The values.</param>
        //public static void Merge(this IDictionary<string, object> instance, object values)
        //{
        //    instance.Merge(values, true);
        //}

        /// <summary>
        /// Appends the specified value at the beginning of the existing value
        /// </summary>
        /// <param name="instance"></param>
        /// <param name="key"></param>
        /// <param name="separator"></param>
        /// <param name="value"></param>
        public static void PrependInValue(this IDictionary<string, object> instance, string key, string separator, object value)
        {
            instance[key] = (instance.ContainsKey(key) ? string.Concat(value, separator, instance[key]) : value.ToString());
        }

        ///// <summary>
        ///// Toes the attribute string.
        ///// </summary>
        ///// <param name="instance">The instance.</param>
        ///// <returns></returns>
        //public static string ToAttributeString(this IDictionary<string, object> instance)
        //{
        //    StringBuilder stringBuilder = new StringBuilder();
        //    foreach (KeyValuePair<string, object> keyValuePair in instance)
        //    {
        //        object[] objArray = new object[] { HttpUtility.HtmlAttributeEncode(keyValuePair.Key), HttpUtility.HtmlAttributeEncode(keyValuePair.Value.ToString()) };
        //        stringBuilder.Append(" {0}=\"{1}\"".FormatWith(objArray));
        //    }
        //    return stringBuilder.ToString();
        //}
    }
}