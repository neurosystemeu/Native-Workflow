using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NeuroSystem.Workflow.UserData.UI.Html.Fluent.Widgets.DataWidgets;
using NeuroSystem.Workflow.UserData.UI.Html.Widgets.ItemsWidgets;

namespace NeuroSystem.Workflow.UserData.UI.Html.Fluent.Widgets.DataForms
{
    public class TreeViewFactory<T> : ItemsWidgetsFactory<T>
    {
        public TreeView TreeView => Widget as TreeView;

        public TreeViewFactory<T> EnableDragAndDrop(bool enableDragAndDrop)
        {
            TreeView.EnableDragAndDrop = enableDragAndDrop;
            return this;
        }

        public TreeViewFactory<T> AllowNodeEditing(bool allowNodeEditing)
        {
            TreeView.AllowNodeEditing = allowNodeEditing;
            return this;
        }
    }
}
