using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NeuroSystem.Workflow.UserData.UI.Html.DataSources;

namespace NeuroSystem.Workflow.UserData.UI.Html.Fluent.DataSources
{
    public class DataSourceFactory<T>
    {
        public DataSourceBase DataSource { get; set; }
    }
}
