using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NeuroSystem.Workflow.UserData.UI.Html.Widgets.ItemsWidgets;

namespace NeuroSystem.Workflow.UserData.UI.Html.DataAnnotations
{
    public class GridViewAttribute : Attribute
    {
        public GridViewAttribute()
        { }

        public string Label { get; set; }
        public int Order { get; set; }
        public bool SortBy { get; set; }
        public GridKnownFunction FilterFunction { get; set; }
        public bool Group { get; set; }
        public string DataFormatString { get; set; }
        public string Agregacja { get; set; }
    }
}
