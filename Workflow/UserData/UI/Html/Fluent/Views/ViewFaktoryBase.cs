using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NeuroSystem.Workflow.UserData.UI.Html.Views;
using NeuroSystem.Workflow.UserData.UI.Html.Widgets;

namespace NeuroSystem.Workflow.UserData.UI.Html.Fluent.Views
{
    public class ViewFaktoryBase
    {
        public WidgetBase Widget { get; set; }

        public virtual ViewBase GetView()
        {
            throw new NotImplementedException();
        }

        public void DataContext(object dataContext)
        {
            Widget.DataContext = dataContext;
        }
    }
}
