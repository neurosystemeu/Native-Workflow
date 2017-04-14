using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NeuroSystem.Workflow.UserData.UI.Html.Mvc.Extensions;
using NeuroSystem.Workflow.UserData.UI.Html.Widgets;

namespace NeuroSystem.Workflow.UserData.UI.Html.Mvc.UI
{
    public class Transport : JsonObject
    {
        public CrudOperation Create
        {
            get;
            private set;
        }

        public IDictionary<string, object> CustomCreate
        {
            get;
            set;
        }

        public IDictionary<string, object> CustomDestroy
        {
            get;
            set;
        }

        public IDictionary<string, object> CustomRead
        {
            get;
            set;
        }

        public IDictionary<string, object> CustomUpdate
        {
            get;
            set;
        }

        public CrudOperation Destroy
        {
            get;
            private set;
        }

        public ClientHandlerDescriptor FunctionCreate
        {
            get;
            set;
        }

        public ClientHandlerDescriptor FunctionDestroy
        {
            get;
            set;
        }

        public ClientHandlerDescriptor FunctionRead
        {
            get;
            set;
        }

        public ClientHandlerDescriptor FunctionSubmit
        {
            get;
            set;
        }

        public ClientHandlerDescriptor FunctionUpdate
        {
            get;
            set;
        }

        public string IdField
        {
            get;
            set;
        }

        public ClientHandlerDescriptor ParameterMap
        {
            get;
            set;
        }

        public string Prefix
        {
            get;
            set;
        }

        public CrudOperation Read
        {
            get;
            private set;
        }

        public bool SerializeEmptyPrefix
        {
            get;
            set;
        }

        //public TransportSignalR SignalR
        //{
        //    get;
        //    set;
        //}

        public bool StringifyDates
        {
            get;
            set;
        }

        public CrudOperation Update
        {
            get;
            private set;
        }

        public Transport()
        {
            this.Read = new CrudOperation();
            this.Update = new CrudOperation();
            this.Destroy = new CrudOperation();
            this.Create = new CrudOperation();
            this.FunctionRead = new ClientHandlerDescriptor();
            this.FunctionUpdate = new ClientHandlerDescriptor();
            this.FunctionDestroy = new ClientHandlerDescriptor();
            this.FunctionCreate = new ClientHandlerDescriptor();
            this.FunctionSubmit = new ClientHandlerDescriptor();
            this.ParameterMap = new ClientHandlerDescriptor();
            this.SerializeEmptyPrefix = true;
            //this.SignalR = new TransportSignalR();
        }

        //protected override void Serialize(IDictionary<string, object> json)
    //    {
    //        if (this.CustomRead != null)
    //        {
    //            json["read"] = this.CustomRead;
    //        }
    //        else if (!this.FunctionRead.HasValue())
    //        {
    //            IDictionary<string, object> strs = this.Read.ToJson();
    //            if (strs.Keys.Any<string>())
    //            {
    //                json["read"] = strs;
    //            }
    //        }
    //        else
    //        {
    //            json["read"] = this.FunctionRead;
    //        }
    //        if (this.SerializeEmptyPrefix)
    //        {
    //            json["prefix"] = (this.Prefix.HasValue() ? this.Prefix : string.Empty);
    //        }
    //        else if (this.Prefix.HasValue())
    //        {
    //            json["prefix"] = this.Prefix;
    //        }
    //        if (this.CustomUpdate != null)
    //        {
    //            json["update"] = this.CustomUpdate;
    //        }
    //        else if (!this.FunctionUpdate.HasValue())
    //        {
    //            IDictionary<string, object> strs1 = this.Update.ToJson();
    //            if (strs1.Keys.Any<string>())
    //            {
    //                json["update"] = strs1;
    //            }
    //        }
    //        else
    //        {
    //            json["update"] = this.FunctionUpdate;
    //        }
    //        if (this.CustomCreate != null)
    //        {
    //            json["create"] = this.CustomCreate;
    //        }
    //        else if (!this.FunctionCreate.HasValue())
    //        {
    //            IDictionary<string, object> strs2 = this.Create.ToJson();
    //            if (strs2.Keys.Any<string>())
    //            {
    //                json["create"] = strs2;
    //            }
    //        }
    //        else
    //        {
    //            json["create"] = this.FunctionCreate;
    //        }
    //        if (this.CustomDestroy != null)
    //        {
    //            json["destroy"] = this.CustomDestroy;
    //        }
    //        else if (!this.FunctionDestroy.HasValue())
    //        {
    //            IDictionary<string, object> strs3 = this.Destroy.ToJson();
    //            if (strs3.Keys.Any<string>())
    //            {
    //                json["destroy"] = strs3;
    //            }
    //        }
    //        else
    //        {
    //            json["destroy"] = this.FunctionDestroy;
    //        }
    //        if (this.FunctionSubmit.HasValue())
    //        {
    //            json["submit"] = this.FunctionSubmit;
    //        }
    //        if (this.StringifyDates)
    //        {
    //            json["stringifyDates"] = this.StringifyDates;
    //        }
    //        if (!string.IsNullOrEmpty(this.IdField))
    //        {
    //            json["idField"] = this.IdField;
    //        }
    //        if (this.ParameterMap.HasValue())
    //        {
    //            json["parameterMap"] = this.ParameterMap;
    //        }
    //        IDictionary<string, object> strs4 = this.SignalR.ToJson();
    //        if (strs4.Keys.Any<string>())
    //        {
    //            json["signalr"] = strs4;
    //        }
    //    }
    }
}