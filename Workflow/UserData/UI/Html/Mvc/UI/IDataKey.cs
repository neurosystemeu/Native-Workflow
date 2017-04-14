using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuroSystem.Workflow.UserData.UI.Html.Mvc.UI
{
    public interface IDataKey
    {
        string Name
        {
            get;
        }

        string RouteKey
        {
            get;
            set;
        }

        object GetValue(object dataItem);
    }
}