using System;
using NeuroSystem.Workflow.UserData.UI.Html.Version1.Views;
using NeuroSystem.Workflow.UserData.UI.Html.Version1.Widgets;

namespace NeuroSystem.Workflow.UserData.UI.Html.Version1.Fluent.Views
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
