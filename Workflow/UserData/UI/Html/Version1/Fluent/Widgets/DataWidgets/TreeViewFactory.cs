using NeuroSystem.Workflow.UserData.UI.Html.Version1.Widgets.ItemsWidgets;

namespace NeuroSystem.Workflow.UserData.UI.Html.Version1.Fluent.Widgets.DataWidgets
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
