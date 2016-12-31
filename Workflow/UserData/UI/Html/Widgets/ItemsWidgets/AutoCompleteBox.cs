using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NeuroSystem.Workflow.UserData.UI.Html.Widgets.DataWidgets;

namespace NeuroSystem.Workflow.UserData.UI.Html.Widgets.ItemsWidgets
{
    public class AutoCompleteBox : ItemsWidget
    {
        /// <summary>
        /// Zanzaczone Id oddzielone ; 
        /// </summary>
        public object SelectedIds { get; set; }

        /// <summary>
        /// Zaznaczone nazwy oddzielone ;
        /// </summary>
        public object SelectedNames { get; set; }
    }
}
