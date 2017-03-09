using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuroSystem.Workflow.UserData.UI.Html.DataAnnotations
{
    
    public class DataFormViewAttribute : Attribute
    {
        public DataFormViewAttribute()
        {
            TabName = "Podstawowe";
        }

        public string Name { get; set; }
        public string GroupName { get; set; }
        public string TabName { get; set; }
        public string Height { get; set; }
        public Type RepositoryType { get; set; }
    }
}
