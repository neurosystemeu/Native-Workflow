using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuroSystem.Workflow.UserData.UI.Html.DataSources
{
    public class ObjectDataSource : DataSourceBase
    {
        public ObjectDataSource()
        {
        }

        public ObjectDataSource(object dataObject)
        {
            DataObject = dataObject;
        }

        public object DataObject { get; set; }

        public override object GetAll(string filtr = null)
        {
            return DataObject;
        }
    }
}
