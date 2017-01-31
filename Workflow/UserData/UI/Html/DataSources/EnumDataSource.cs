using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuroSystem.Workflow.UserData.UI.Html.DataSources
{
    public class EnumDataSource : DataSourceBase
    {
        public EnumDataSource()
        {
            
        }

        public EnumDataSource(Type propertyType)
        {
            EnumValuesList = new List<object>();
            foreach (var value in Enum.GetValues(propertyType))
            {
                EnumValuesList.Add(value);
            }
        }

        public List<object> EnumValuesList { get; set; }

        public override object GetAll(string filtr = null)
        {
            return EnumValuesList;
        }
    }
}
