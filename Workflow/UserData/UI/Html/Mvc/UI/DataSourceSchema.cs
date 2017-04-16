using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NeuroSystem.Workflow.UserData.UI.Html.Mvc.Infrastructure;

namespace NeuroSystem.Workflow.UserData.UI.Html.Mvc.UI
{
    public class DataSourceSchema : JsonObject
    {
        public string Aggregates
        {
            get;
            set;
        }

        public string Data
        {
            get;
            set;
        }

        public string Errors
        {
            get;
            set;
        }

        public ClientHandlerDescriptor FunctionAggregates
        {
            get;
            set;
        }

        public ClientHandlerDescriptor FunctionData
        {
            get;
            set;
        }

        public ClientHandlerDescriptor FunctionErrors
        {
            get;
            set;
        }

        public ClientHandlerDescriptor FunctionGroups
        {
            get;
            set;
        }

        public object FunctionModel
        {
            get;
            set;
        }

        public ClientHandlerDescriptor FunctionTotal
        {
            get;
            set;
        }

        public string Groups
        {
            get;
            set;
        }

        public ModelDescriptor Model
        {
            get;
            set;
        }

        public ClientHandlerDescriptor Parse
        {
            get;
            set;
        }

        public string Total
        {
            get;
            set;
        }

        public string Type
        {
            get;
            set;
        }

        public DataSourceSchema()
        {
            this.Data = "Data";
            this.Total = "Total";
            this.Errors = "Errors";
            this.FunctionData = new ClientHandlerDescriptor();
            this.FunctionTotal = new ClientHandlerDescriptor();
            this.FunctionErrors = new ClientHandlerDescriptor();
            this.FunctionAggregates = new ClientHandlerDescriptor();
            this.FunctionGroups = new ClientHandlerDescriptor();
            this.Parse = new ClientHandlerDescriptor();
        }

        protected override void Serialize(IDictionary<string, object> json)
        {
            if (!this.FunctionData.HasValue())
            {
                FluentDictionary.For(json).Add<string>("data", this.Data, string.Empty);
            }
            else
            {
                json.Add("data", this.FunctionData);
            }
            if (!this.FunctionTotal.HasValue())
            {
                FluentDictionary.For(json).Add<string>("total", this.Total, string.Empty);
            }
            else
            {
                json.Add("total", this.FunctionTotal);
            }
            if (!this.FunctionErrors.HasValue())
            {
                FluentDictionary.For(json).Add<string>("errors", this.Errors, string.Empty);
            }
            else
            {
                json.Add("errors", this.FunctionErrors);
            }
            if (!this.FunctionAggregates.HasValue())
            {
                FluentDictionary.For(json).Add<string>("aggregates", this.Aggregates, string.Empty);
            }
            else
            {
                json.Add("aggregates", this.FunctionAggregates);
            }
            if (!this.FunctionGroups.HasValue())
            {
                FluentDictionary.For(json).Add<string>("groups", this.Groups, string.Empty);
            }
            else
            {
                json.Add("groups", this.FunctionGroups);
            }
            if (this.FunctionModel != null)
            {
                json.Add("model", this.FunctionModel);
            }
            else if (this.Model != null)
            {
                json.Add("model", this.Model.ToJson());
            }
            if (!string.IsNullOrEmpty(this.Type))
            {
                json.Add("type", this.Type);
            }
            if (this.Parse.HasValue())
            {
                json.Add("parse", this.Parse);
            }
        }
    }
}