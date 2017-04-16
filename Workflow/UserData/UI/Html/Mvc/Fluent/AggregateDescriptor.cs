using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NeuroSystem.Workflow.UserData.UI.Html.Mvc.Fluent
{
    public class AggregateDescriptor
    {
        private readonly IDictionary<string, Func<AggregateFunction>> aggregateFactories;

        public ICollection<AggregateFunction> Aggregates
        {
            get;
            private set;
        }

        public string Member
        {
            get;
            set;
        }

        public AggregateDescriptor()
        {
            this.Aggregates = new List<AggregateFunction>();
            Dictionary<string, Func<AggregateFunction>> strs = new Dictionary<string, Func<AggregateFunction>>()
            {
                { "sum", new Func<AggregateFunction>(() => new AggregateFunction()
                {
                    FunctionName = "sum",
                    SourceField = this.Member
                }) },
                { "count", new Func<AggregateFunction>(() => new AggregateFunction()
                {
                    FunctionName = "count",
                    SourceField = this.Member
                }) },
                { "average", new Func<AggregateFunction>(() => new AggregateFunction()
                {
                    FunctionName = "average",
                    SourceField = this.Member
                }) },
                { "min", new Func<AggregateFunction>(() => new AggregateFunction()
                {
                    FunctionName = "min",
                    SourceField = this.Member
                }) },
                { "max", new Func<AggregateFunction>(() => new AggregateFunction()
                {
                    FunctionName = "max",
                    SourceField = this.Member
                }) }
            };
            this.aggregateFactories = strs;
        }

        public void Deserialize(string source)
        {
            string[] strArrays = source.Split(new char[] { '-' });
            if (strArrays.Any<string>())
            {
                this.Member = strArrays[0];
                for (int i = 1; i < (int)strArrays.Length; i++)
                {
                    this.DeserializeAggregate(strArrays[i]);
                }
            }
        }

        private void DeserializeAggregate(string aggregate)
        {
            Func<AggregateFunction> func;
            if (this.aggregateFactories.TryGetValue(aggregate, out func))
            {
                this.Aggregates.Add(func());
            }
        }

        public string Serialize()
        {
            StringBuilder stringBuilder = new StringBuilder(this.Member);
            IEnumerable<string> aggregates =
                from aggregate in this.Aggregates
                select aggregate.FunctionName.Split(new char[] { '\u005F' })[0].ToLowerInvariant();
            foreach (string str in aggregates)
            {
                stringBuilder.Append("-");
                stringBuilder.Append(str);
            }
            return stringBuilder.ToString();
        }
    }
}