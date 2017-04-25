using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace NeuroSystem.Workflow.UserData.UI.Html.Mvc.Extensions
{
    public static class StringExtensions
    {
        private readonly static Regex NameExpression;

        private readonly static Regex EntityExpression;

        static StringExtensions()
        {
            StringExtensions.NameExpression = new Regex("([A-Z]+(?=$|[A-Z][a-z])|[A-Z]?[a-z]+)", RegexOptions.Compiled);
            StringExtensions.EntityExpression = new Regex("(&amp;|&)#([0-9]+;)", RegexOptions.Compiled);
        }

        public static string AsTitle(this string value)
        {
            if (value == null)
            {
                return string.Empty;
            }
            int num = value.LastIndexOf(".", StringComparison.Ordinal);
            if (num > -1)
            {
                value = value.Substring(num + 1);
            }
            return value.SplitPascalCase();
        }

        public static string EscapeHtmlEntities(this string html)
        {
            return StringExtensions.EntityExpression.Replace(html, "$1\\\\#$2");
        }

        /// <summary>
        /// Replaces the format item in a specified System.String with the text equivalent of the value of a corresponding System.Object instance in a specified array.
        /// </summary>
        /// <param name="instance">A string to format.</param>
        /// <param name="args">An System.Object array containing zero or more objects to format.</param>
        /// <returns>A copy of format in which the format items have been replaced by the System.String equivalent of the corresponding instances of System.Object in args.</returns>
        public static string FormatWith(this string instance, params object[] args)
        {
            return string.Format(CultureInfo.CurrentCulture, instance, args);
        }

        public static bool HasValue(this string value)
        {
            return !string.IsNullOrEmpty(value);
        }

        /// <summary>
        /// Determines whether this instance and another specified System.String object have the same value.
        /// </summary>
        /// <param name="instance">The string to check equality.</param>
        /// <param name="comparing">The comparing with string.</param>
        /// <returns>
        /// <c>true</c> if the value of the comparing parameter is the same as this string; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsCaseInsensitiveEqual(this string instance, string comparing)
        {
            return string.Compare(instance, comparing, StringComparison.OrdinalIgnoreCase) == 0;
        }

        /// <summary>
        /// Determines whether this instance and another specified System.String object have the same value.
        /// </summary>
        /// <param name="instance">The string to check equality.</param>
        /// <param name="comparing">The comparing with string.</param>
        /// <returns>
        /// <c>true</c> if the value of the comparing parameter is the same as this string; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsCaseSensitiveEqual(this string instance, string comparing)
        {
            return string.CompareOrdinal(instance, comparing) == 0;
        }

        public static string SplitPascalCase(this string value)
        {
            return StringExtensions.NameExpression.Replace(value, " $1").Trim();
        }

        public static string ToCamelCase(this string instance)
        {
            char chr = instance[0];
            return string.Concat(chr.ToString().ToLowerInvariant(), instance.Substring(1));
        }

        public static T ToEnum<T>(this string value, T defaultValue)
        {
            T t;
            if (!value.HasValue())
            {
                return defaultValue;
            }
            try
            {
                t = (T)Enum.Parse(typeof(T), value, true);
            }
            catch
            {
                t = defaultValue;
            }
            return t;
        }
    }
}