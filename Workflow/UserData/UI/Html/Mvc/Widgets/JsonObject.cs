using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuroSystem.Workflow.UserData.UI.Html.Widgets
{
    public abstract class JsonObject
    {
        protected JsonObject()
        {
        }

        //protected abstract void Serialize(IDictionary<string, object> json);
        protected virtual void Serialize(IDictionary<string, object> json)
        {
            
        }

        public IDictionary<string, object> ToJson()
        {
            Dictionary<string, object> strs = new Dictionary<string, object>();
            this.Serialize(strs);
            return strs;
        }
    }
}
