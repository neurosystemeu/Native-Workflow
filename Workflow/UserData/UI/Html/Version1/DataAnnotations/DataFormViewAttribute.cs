using System;

namespace NeuroSystem.Workflow.UserData.UI.Html.Version1.DataAnnotations
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
