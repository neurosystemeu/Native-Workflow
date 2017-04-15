using System;
using System.Collections;
using System.Collections.Generic;
using NeuroSystem.Workflow.UserData.UI.Html.Mvc.Builders;
using NeuroSystem.Workflow.UserData.UI.Html.Mvc.UI;
using NeuroSystem.Workflow.UserData.UI.Html.Mvc.Widgets;

namespace NeuroSystem.Workflow.UserData.UI.Html.Mvc
{
    public class DataSource : JsonObject
    {
        //public IEnumerable<AggregateResult> AggregateResults
        //{
        //    get;
        //    set;
        //}

        public IList<AggregateDescriptor> Aggregates
        {
            get;
            set;
        }

        public bool AutoSync
        {
            get;
            set;
        }

        public bool Batch
        {
            get;
            set;
        }

        public IDictionary<string, object> CustomTransport
        {
            get;
            set;
        }

        public string CustomType
        {
            get;
            set;
        }

        public IEnumerable Data
        {
            get;
            set;
        }

        public IDictionary<string, object> Events
        {
            get;
            private set;
        }

        public IList<IFilterDescriptor> Filters
        {
            get;
            private set;
        }

        //public IList<GroupDescriptor> Groups
        //{
        //    get;
        //    private set;
        //}

        public bool IsClientBinding
        {
            get
            {
                DataSourceType? type = this.Type;
                if ((type.GetValueOrDefault() != DataSourceType.Ajax ? true : !type.HasValue))
                {
                    DataSourceType? nullable = this.Type;
                    if ((nullable.GetValueOrDefault() != DataSourceType.WebApi ? true : !nullable.HasValue))
                    {
                        DataSourceType? type1 = this.Type;
                        if (type1.GetValueOrDefault() != DataSourceType.Custom)
                        {
                            return false;
                        }
                        return type1.HasValue;
                    }
                }
                return true;
            }
        }

        public bool IsClientOperationMode
        {
            get
            {
                if (!this.IsClientBinding)
                {
                    return false;
                }
                if (!this.ServerPaging || !this.ServerSorting || !this.ServerGrouping || !this.ServerFiltering)
                {
                    return true;
                }
                return !this.ServerAggregates;
            }
        }

        public IDictionary<string, object> OfflineStorage
        {
            get;
            set;
        }

        public string OfflineStorageKey
        {
            get;
            set;
        }

        //public IList<SortDescriptor> OrderBy
        //{
        //    get;
        //    private set;
        //}

        public int Page
        {
            get;
            set;
        }

        public int PageSize
        {
            get;
            set;
        }

        public IEnumerable RawData
        {
            get;
            set;
        }

        public DataSourceSchema Schema
        {
            get;
            private set;
        }

        public bool ServerAggregates
        {
            get;
            set;
        }

        public bool ServerFiltering
        {
            get;
            set;
        }

        public bool ServerGrouping
        {
            get;
            set;
        }

        public bool ServerPaging
        {
            get;
            set;
        }

        public bool ServerSorting
        {
            get;
            set;
        }

        public int Total
        {
            get;
            set;
        }

        public int TotalPages
        {
            get;
            set;
        }

        public Transport Transport
        {
            get;
            protected set;
        }

        public DataSourceType? Type
        {
            get;
            set;
        }

        public DataSource()
        {
            this.Transport = new Transport();
            //this.Filters = new List<IFilterDescriptor>();
            //this.OrderBy = new List<SortDescriptor>();
            //this.Groups = new List<GroupDescriptor>();
            //this.Aggregates = new List<AggregateDescriptor>();
            this.Events = new Dictionary<string, object>();
            this.Schema = new DataSourceSchema();
            this.OfflineStorage = new Dictionary<string, object>();
        }

        private string GenerateTypeFunction(bool isAspNetMvc)
        {
            string str = "(function(){{if(kendo.data.transports['{0}{1}']){{return '{0}{1}';}} else{{throw new Error('The kendo.aspnetmvc.min.js script is not included.');}}}})()";
            if (isAspNetMvc)
            {
                DataSourceType? type = this.Type;
                return string.Format(str, "aspnetmvc-", type.ToString().ToLower());
            }
            DataSourceType? nullable = this.Type;
            return string.Format(str, "", nullable.ToString().ToLower());
        }

        //private void MergeAggregateTypes(DataSourceRequest request)
        //{
        //    DataSource.<> c__DisplayClass13 variable;
        //    if (this.Aggregates.Any<AggregateDescriptor>())
        //    {
        //        foreach (AggregateDescriptor aggregate in request.Aggregates)
        //        {
        //            AggregateDescriptor aggregateDescriptor = this.Aggregates.SingleOrDefault<AggregateDescriptor>((AggregateDescriptor agg) => agg.Member.Equals(aggregate.Member, StringComparison.InvariantCultureIgnoreCase));
        //            if (aggregateDescriptor == null)
        //            {
        //                continue;
        //            }
        //            aggregate.Aggregates.Each<AggregateFunction>((AggregateFunction function) => {
        //                AggregateFunction aggregateFunction = aggregateDescriptor.Aggregates.SingleOrDefault<AggregateFunction>((AggregateFunction matchFunction) => matchFunction.AggregateMethodName == function.AggregateMethodName);
        //                if (aggregateFunction != null && aggregateFunction.MemberType != null)
        //                {
        //                    function.MemberType = aggregateFunction.MemberType;
        //                }
        //            });
        //        }
        //    }
        //}

        //public void ModelType(Type modelType)
        //{
        //    this.Schema.Model = new ModelDescriptor(modelType);
        //}

        //public void Process(DataSourceRequest request, bool processData)
        //{
        //    this.RawData = this.Data;
        //    if (request.Sorts == null)
        //    {
        //        request.Sorts = this.OrderBy;
        //    }
        //    else if (!request.Sorts.Any<SortDescriptor>())
        //    {
        //        this.OrderBy.Clear();
        //    }
        //    else
        //    {
        //        this.OrderBy.Clear();
        //        this.OrderBy.AddRange<SortDescriptor>(request.Sorts);
        //    }
        //    if (request.PageSize == 0)
        //    {
        //        request.PageSize = this.PageSize;
        //    }
        //    this.PageSize = request.PageSize;
        //    if (request.Groups == null)
        //    {
        //        request.Groups = this.Groups;
        //    }
        //    else if (!request.Groups.Any<GroupDescriptor>())
        //    {
        //        this.Groups.Clear();
        //    }
        //    else
        //    {
        //        this.Groups.Clear();
        //        this.Groups.AddRange<GroupDescriptor>(request.Groups);
        //    }
        //    if (request.Filters == null)
        //    {
        //        request.Filters = this.Filters;
        //    }
        //    else if (!request.Filters.Any<IFilterDescriptor>())
        //    {
        //        this.Filters.Clear();
        //    }
        //    else
        //    {
        //        this.Filters.Clear();
        //        this.Filters.AddRange<IFilterDescriptor>(request.Filters);
        //    }
        //    if (!request.Aggregates.Any<AggregateDescriptor>())
        //    {
        //        request.Aggregates = this.Aggregates;
        //    }
        //    else if (!request.Aggregates.Any<AggregateDescriptor>())
        //    {
        //        this.Aggregates.Clear();
        //    }
        //    else
        //    {
        //        this.MergeAggregateTypes(request);
        //        this.Aggregates.Clear();
        //        this.Aggregates.AddRange<AggregateDescriptor>(request.Aggregates);
        //    }
        //    if (this.Groups.Any<GroupDescriptor>() && this.Aggregates.Any<AggregateDescriptor>() && this.Data == null)
        //    {
        //        this.Groups.Each<GroupDescriptor>((GroupDescriptor g) => g.AggregateFunctions.AddRange<AggregateFunction>(this.Aggregates.SelectMany<AggregateDescriptor, AggregateFunction>((AggregateDescriptor a) => a.Aggregates)));
        //    }
        //    if (this.Data != null)
        //    {
        //        if (!processData)
        //        {
        //            IGridCustomGroupingWrapper data = this.Data as IGridCustomGroupingWrapper;
        //            if (data != null)
        //            {
        //                IEnumerable enumerable = data.GroupedEnumerable.AsGenericEnumerable();
        //                IEnumerable enumerable1 = enumerable;
        //                this.Data = enumerable;
        //                this.RawData = enumerable1;
        //            }
        //        }
        //        else
        //        {
        //            DataSourceResult dataSourceResult = this.Data.AsQueryable().ToDataSourceResult(request);
        //            this.Data = dataSourceResult.Data;
        //            this.Total = dataSourceResult.Total;
        //            this.AggregateResults = dataSourceResult.AggregateResults;
        //        }
        //    }
        //    this.Page = request.Page;
        //    if (this.Total == 0 || this.PageSize == 0)
        //    {
        //        this.TotalPages = 1;
        //        return;
        //    }
        //    this.TotalPages = (this.Total + this.PageSize - 1) / this.PageSize;
        //}

        //protected override void Serialize(IDictionary<string, object> json)
        //{
        //    bool url = this.Transport.Read.Url == null;
        //    DataSourceType? type = this.Type;
        //    if (url & (type.GetValueOrDefault() != DataSourceType.Custom ? true : !type.HasValue))
        //    {
        //        this.Transport.Read.Url = "";
        //    }
        //    if (this.Type.HasValue)
        //    {
        //        DataSourceType? nullable = this.Type;
        //        if ((nullable.GetValueOrDefault() != DataSourceType.Ajax ? true : !nullable.HasValue))
        //        {
        //            DataSourceType? type1 = this.Type;
        //            if ((type1.GetValueOrDefault() != DataSourceType.Server ? false : type1.HasValue))
        //            {
        //                goto Label1;
        //            }
        //            DataSourceType? nullable1 = this.Type;
        //            if ((nullable1.GetValueOrDefault() != DataSourceType.Custom ? true : !nullable1.HasValue))
        //            {
        //                ClientHandlerDescriptor clientHandlerDescriptor = new ClientHandlerDescriptor()
        //                {
        //                    HandlerName = this.GenerateTypeFunction(false)
        //                };
        //                json["type"] = clientHandlerDescriptor;
        //                DataSourceType? type2 = this.Type;
        //                if ((type2.GetValueOrDefault() != DataSourceType.WebApi ? false : type2.HasValue) && this.Schema.Model.Id != null)
        //                {
        //                    this.Transport.IdField = this.Schema.Model.Id.Name;
        //                    goto Label0;
        //                }
        //                else
        //                {
        //                    goto Label0;
        //                }
        //            }
        //            else if (!string.IsNullOrEmpty(this.CustomType))
        //            {
        //                json["type"] = this.CustomType;
        //                goto Label0;
        //            }
        //            else
        //            {
        //                goto Label0;
        //            }
        //        }
        //        Label1:
        //        ClientHandlerDescriptor clientHandlerDescriptor1 = new ClientHandlerDescriptor()
        //        {
        //            HandlerName = this.GenerateTypeFunction(true)
        //        };
        //        json["type"] = clientHandlerDescriptor1;
        //    }
        //    Label0:
        //    if (this.CustomTransport == null)
        //    {
        //        IDictionary<string, object> strs = this.Transport.ToJson();
        //        if (strs.Keys.Any<string>())
        //        {
        //            json["transport"] = strs;
        //        }
        //    }
        //    else
        //    {
        //        json["transport"] = this.CustomTransport;
        //    }
        //    if (!string.IsNullOrEmpty(this.OfflineStorageKey))
        //    {
        //        json["offlineStorage"] = this.OfflineStorageKey;
        //    }
        //    if (this.OfflineStorage.Any<KeyValuePair<string, object>>())
        //    {
        //        json["offlineStorage"] = this.OfflineStorage;
        //    }
        //    if (this.PageSize > 0)
        //    {
        //        json["pageSize"] = this.PageSize;
        //        json["page"] = this.Page;
        //        json["total"] = this.Total;
        //    }
        //    if (this.ServerPaging)
        //    {
        //        json["serverPaging"] = this.ServerPaging;
        //    }
        //    if (this.ServerSorting)
        //    {
        //        json["serverSorting"] = this.ServerSorting;
        //    }
        //    if (this.ServerFiltering)
        //    {
        //        json["serverFiltering"] = this.ServerFiltering;
        //    }
        //    if (this.ServerGrouping)
        //    {
        //        json["serverGrouping"] = this.ServerGrouping;
        //    }
        //    if (this.ServerAggregates)
        //    {
        //        json["serverAggregates"] = this.ServerAggregates;
        //    }
        //    if (this.OrderBy.Any<SortDescriptor>())
        //    {
        //        json["sort"] = this.OrderBy.ToJson();
        //    }
        //    if (this.Groups.Any<GroupDescriptor>())
        //    {
        //        if (this.Aggregates.Any<AggregateDescriptor>())
        //        {
        //            (
        //                from g in this.Groups
        //                where g.AggregateFunctions.Count == 0
        //                select g).Each<GroupDescriptor>((GroupDescriptor g) => g.AggregateFunctions.AddRange<AggregateFunction>(this.Aggregates.SelectMany<AggregateDescriptor, AggregateFunction>((AggregateDescriptor a) => a.Aggregates)));
        //        }
        //        json["group"] = this.Groups.ToJson();
        //    }
        //    if (this.Aggregates.Any<AggregateDescriptor>())
        //    {
        //        json["aggregate"] = this.Aggregates.SelectMany<AggregateDescriptor, IDictionary<string, object>>((AggregateDescriptor agg) => agg.Aggregates.ToJson());
        //    }
        //    if (this.Filters.Any<IFilterDescriptor>() || this.ServerFiltering)
        //    {
        //        json["filter"] = this.Filters.OfType<FilterDescriptorBase>().ToJson();
        //    }
        //    if (this.Events.Keys.Any<string>())
        //    {
        //        json.Merge(this.Events);
        //    }
        //    IDictionary<string, object> strs1 = this.Schema.ToJson();
        //    if (strs1.Keys.Any<string>())
        //    {
        //        json["schema"] = strs1;
        //    }
        //    if (this.Batch)
        //    {
        //        json["batch"] = this.Batch;
        //    }
        //    if (this.AutoSync)
        //    {
        //        json["autoSync"] = this.AutoSync;
        //    }
        //    if (this.IsClientOperationMode)
        //    {
        //        DataSourceType? nullable2 = this.Type;
        //        if ((nullable2.GetValueOrDefault() != DataSourceType.Custom ? false : nullable2.HasValue) && this.CustomType != "aspnetmvc-ajax")
        //        {
        //            this.RawData = this.Data;
        //        }
        //    }
        //    if (this.IsClientOperationMode && this.RawData != null)
        //    {
        //        this.SerializeData(json, this.RawData);
        //        return;
        //    }
        //    if (this.IsClientBinding && !this.IsClientOperationMode && this.Data != null)
        //    {
        //        this.SerializeData(json, this.Data);
        //    }
        //}

        //private void SerializeData(IDictionary<string, object> json, IEnumerable data)
        //{
        //    if (string.IsNullOrEmpty(this.Schema.Data))
        //    {
        //        json["data"] = this.SerializeDataSource(data);
        //        return;
        //    }
        //    Dictionary<string, object> strs = new Dictionary<string, object>()
        //    {
        //        { this.Schema.Data, this.SerializeDataSource(data) },
        //        { this.Schema.Total, this.Total },
        //        { "AggregateResults", this.AggregateResults }
        //    };
        //    json["data"] = strs;
        //}

        //private object SerializeDataSource(IEnumerable data)
        //{
        //    DataTableWrapper rawData = this.RawData as DataTableWrapper;
        //    if (rawData != null && rawData.Table != null)
        //    {
        //        return data.SerializeToDictionary(rawData.Table);
        //    }
        //    if (!(data is IEnumerable<AggregateFunctionsGroup>) || this.ServerGrouping)
        //    {
        //        return data;
        //    }
        //    return data.Cast<IGroup>().Leaves();
        //}

        protected override void Serialize(IDictionary<string, object> json)
        {
            throw new NotImplementedException();
        }
    }
}