using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuroSystem.Workflow.UserData.UI.Html.Widgets
{
    public class Grid : WidgetBase
    {
        public DataSource DataSource { get; set; }
    }

    /// <summary>
    /// The server side wrapper for Kendo UI Grid
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Grid<T> : Grid
        where T : class
    {

        
    }
}
