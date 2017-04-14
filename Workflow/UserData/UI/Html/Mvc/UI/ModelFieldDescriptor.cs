using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuroSystem.Workflow.UserData.UI.Html.Mvc.UI
{
    public class ModelFieldDescriptor
    {
        public object DefaultValue
        {
            get;
            set;
        }

        public string From
        {
            get;
            set;
        }

        public bool IsEditable
        {
            get;
            set;
        }

        public bool IsNullable
        {
            get;
            set;
        }

        public string Member
        {
            get;
            set;
        }

        public Type MemberType
        {
            get;
            set;
        }

        public ClientHandlerDescriptor Parse
        {
            get;
            set;
        }

        public ModelFieldDescriptor()
        {
            this.IsEditable = true;
            this.Parse = new ClientHandlerDescriptor();
        }
    }
}