using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuroSystem.Workflow.UserData.UI.Html
{
    public class CrudOperation
    {
        public string ActionName { get; set; }

        public bool Cache { get; set; }

        public string ContentType { get; set; }

        public string ControllerName { get; set; }
        
        public string DataType
        {
            get;
            set;
        }

        public string Type
        {
            get;
            set;
        }

        public string Url
        {
            get;
            set;
        }
    }
}
