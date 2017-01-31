using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NeuroSystem.Workflow.UserData.UI.Html.Widgets.ItemsWidgets;

namespace NeuroSystem.Workflow.UserData.UI.Html.Fluent.Widgets.DataWidgets
{
    public class TreeComboBoxFactory<T> : ItemsWidgetsFactory<T>
    {
        public TreeComboBox TreeComboBox => Widget as TreeComboBox;
    }
}
