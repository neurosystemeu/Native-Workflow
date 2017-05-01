using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuroSystem.Workflow.UserData.UI.Html.Mvc.DataAnnotations
{
    public class DataFormViewAttribute : Attribute
    {
        public DataFormViewAttribute()
        {
            TabName = "Podstawowe";
            GroupName = "Podstawowa";
        }

        public bool IsReadOnly { get; set; }
        public string Name { get; set; }
        public string GroupName { get; set; }
        public string TabName { get; set; }
        public string Height { get; set; }
        public Type RepositoryType { get; set; }
        public EnumControlType ControlType { get; set; }

        /// <summary>
        /// Url do widoku listy danego typu
        /// </summary>
        public string ListViewUrl { get; set; }

        /// <summary>
        /// Url do widoku formy 
        /// </summary>
        public string DataFormViewUrl { get; set; }
    }
}
