using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Action = NeuroSystem.Workflow.UserData.UI.Html.Widgets.Actions.Action;

namespace NeuroSystem.Workflow.UserData.UI.Html.Fluent.Widgets.Actions
{
    public class ActionFactory<T> : WidgetFactory<T>
    {
        public Action Action => Widget as Action;

        public ActionFactory()
        {
            Widget = new Action();
        }
    }
}
