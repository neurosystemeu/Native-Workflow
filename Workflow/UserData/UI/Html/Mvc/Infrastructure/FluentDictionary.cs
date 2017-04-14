using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuroSystem.Workflow.UserData.UI.Html.Mvc.Infrastructure
{
    public class FluentDictionary
    {
        private readonly IDictionary<string, object> dictionary;

        internal FluentDictionary(IDictionary<string, object> dictionary)
        {
            this.dictionary = dictionary;
        }

        public FluentDictionary Add<T>(string key, T value)
        {
            this.dictionary[key] = value;
            return this;
        }

        public FluentDictionary Add<T>(string key, T value, T defaultValue)
        where T : IComparable
        {
            if (value != null && value.CompareTo(defaultValue) != 0)
            {
                this.dictionary[key] = value;
            }
            return this;
        }

        public FluentDictionary Add<T>(string key, T value, Func<bool> condition)
        {
            if (condition())
            {
                this.dictionary[key] = value;
            }
            return this;
        }

        public static FluentDictionary For(IDictionary<string, object> dictionary)
        {
            return new FluentDictionary(dictionary);
        }
    }
}