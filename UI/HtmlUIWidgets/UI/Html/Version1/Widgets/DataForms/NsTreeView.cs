using System;
using NeuroSystem.Workflow.Core.Extensions;
using NeuroSystem.Workflow.UserData.UI.Html.Version1.ViewModel;
using NeuroSystem.Workflow.UserData.UI.Html.Version1.Widgets;
using NeuroSystem.Workflow.UserData.UI.Html.Version1.Widgets.ItemsWidgets;
using Telerik.Web.UI;

namespace NeuroSystem.Workflow.UserData.UI.Html.ASP.UI.Html.Version1.Widgets.DataForms
{
    public class NsTreeView : RadTreeView, IBindingControl
    {
        public NsTreeView()
        {
            NodeEdit += NsTreeView_NodeEdit;
            NodeDrop += NsTreeView_NodeDrop;
        }

        private void NsTreeView_NodeDrop(object sender, RadTreeNodeDragDropEventArgs e)
        {
            var treeView = Widget as TreeView;
            if (treeView != null)
            {
                var ds = treeView.DataSource;
                if (ds != null)
                {
                    var id = e.DestDragNode.Value;
                    //var obiektDest = ds.GetObjectById(id);

                    foreach (var item in e.DraggedNodes)
                    {
                        var idDragged = item.Value;
                        var folder = ds.GetObjectById(idDragged);
                        folder.SetPropValue(treeView.DataFieldParentId, Guid.Parse(id));
                        ds.Update(folder);
                        //item.ParentNode = e.;
                    }

                    RadTreeNode sourceNode = e.SourceDragNode;
                    RadTreeNode destinationNode = e.DestDragNode;

                    if (destinationNode != null)
                    {
                        MoveNode(e.DropPosition, sourceNode, destinationNode);
                    }
                }
            }
        }

        private void MoveNode(RadTreeViewDropPosition dropPosition, RadTreeNode sourceNode, RadTreeNode destNode)
        {
            if (sourceNode == destNode || sourceNode.IsAncestorOf(destNode))
            {
                return;
            }

            sourceNode.Owner.Nodes.Remove(sourceNode);

            switch (dropPosition)
            {
                case RadTreeViewDropPosition.Over:
                    // child
                    if (!sourceNode.IsAncestorOf(destNode))
                    {
                        destNode.Nodes.Add(sourceNode);
                        destNode.Expanded = true;
                    }
                    break;

                case RadTreeViewDropPosition.Above:
                    // sibling - above                    
                    destNode.InsertBefore(sourceNode);
                    break;

                case RadTreeViewDropPosition.Below:
                    // sibling - below
                    destNode.InsertAfter(sourceNode);
                    break;
            }

            sourceNode.Selected = false;
        }

        private void NsTreeView_NodeEdit(object sender, RadTreeNodeEditEventArgs e)
        {
            var treeView = Widget as TreeView;
            if (treeView != null && string.IsNullOrEmpty(treeView.DataTextField) == false )
            {
                var ds = treeView.DataSource;
                if (ds != null)
                {
                    var node = ds.GetObjectById(e.Node.Value);
                    node.SetPropValue(treeView.DataTextField, e.Text);
                    ds.Update(node);
                    e.Node.Text = e.Text;
                }
            }
        }

        public WidgetBase Widget { get; set; }

        public void LoadToControl()
        {
            var dataWidget = Widget as TreeView;
            var date = Binding.PobierzWartosc(dataWidget.SelectedValue, dataWidget.DataContext);
            //SelectedValue = date?.ToString();
        }

        public void SaveFromControl()
        {
            var dataWidget = Widget as TreeView;
            var binding = dataWidget.SelectedValue;
            if (binding != null)
            {
                Binding.UstawWartosc(ref binding, dataWidget.DataContext, SelectedValue);
                dataWidget.SelectedValue = binding; //w binding może być wartość - dane bez bindowania
            }
            else
            {
                dataWidget.SelectedValue = SelectedValue;
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (Page.IsPostBack == false)
            {
                var dataWidget = Widget as TreeView;
                if (dataWidget.AutoLoadDataSource)
                {
                    DataSource = dataWidget.GetAllData();
                    DataBind();
                }
            }
        }



        internal static NsTreeView UtworzTreeView(TreeView opisPola)
        {
            var cb = new NsTreeView()
            {
                Widget = opisPola,
                ToolTip = opisPola.ToolTip,
                DataFieldID = opisPola.DataIdField,
                DataFieldParentID = opisPola.DataFieldParentId,
                DataTextField = opisPola.DataTextField,
                DataValueField = opisPola.DataValueField,
                AllowNodeEditing = opisPola.AllowNodeEditing,
                EnableDragAndDrop = opisPola.EnableDragAndDrop
            };
            return cb;
        }
    }
}
