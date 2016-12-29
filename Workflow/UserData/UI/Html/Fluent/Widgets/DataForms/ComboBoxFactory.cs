using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NeuroSystem.Workflow.UserData.UI.Html.Fluent.Widgets;
using NeuroSystem.Workflow.UserData.UI.Html.Widget.ItemsWidget;

namespace NeuroSystem.Workflow.UserData.UI.Html.Fluent.DataForms
{
    public class ComboBoxFactory<T> : ItemsWidgetsFactory<T>
    {
        public ComboBox ComboBox => Widget as ComboBox;
    }
}
