using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuroSystem.Workflow.UserData.UI.Html.Widgets.ItemsWidgets
{
    public enum GridAggregateFunction
    {
        None = 0,
        Sum = 1,
        Min = 2,
        Max = 3,
        Last = 4,
        First = 5,
        Count = 6,
        Avg = 7,
        CountDistinct = 8,
        Custom = 9
    }
}
