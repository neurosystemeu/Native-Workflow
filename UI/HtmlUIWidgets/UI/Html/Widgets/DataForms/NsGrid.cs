using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using NeuroSystem.Workflow.Core.Extensions;
using NeuroSystem.Workflow.UserData.UI.Html.ViewModel;
using NeuroSystem.Workflow.UserData.UI.Html.Widgets;
using NeuroSystem.Workflow.UserData.UI.Html.Widgets.ItemsWidgets;
using Telerik.Web.UI;
using GridView = NeuroSystem.Workflow.UserData.UI.Html.Widgets.ItemsWidgets.GridView;

namespace NeuroSystem.Workflow.UserData.UI.Html.ASP.UI.Html.Widgets.DataForms
{
    public class NsGrid : RadGrid, IBindingControl
    {
        public NsGrid()
        {
            this.NeedDataSource += NsGrid_NeedDataSource;
            this.BatchEditCommand += NsGrid_BatchEditCommand;
            
        }

        public WidgetBase Widget { get; set; }

        public void LoadToControl()
        {
            //var dataWidget = Widget as GridView;
            //var date = Binding.PobierzWartosc(dataWidget.SelectedValue, dataWidget.DataContext);
            //SelectedValue = date;
        }

        public void SaveFromControl()
        {
            var dataWidget = Widget as GridView;
            var binding = dataWidget.SelectedValue as Binding;
            if (binding != null)
            {
                object bind = binding;
                Binding.UstawWartosc(ref bind, dataWidget.DataContext, SelectedValue);
                dataWidget.SelectedValue = binding; //w binding może być wartość - dane bez bindowania
            }
            else
            {
                dataWidget.SelectedValue = this.SelectedValue;
                var lista = new List<string>();
                foreach (GridDataItem selectedItem in this.SelectedItems)
                {
                    lista.Add(selectedItem.GetDataKeyValue("Id")?.ToString());
                }
                dataWidget.SelectedIds = lista;
            }
        }

        private void NsGrid_BatchEditCommand(object sender, GridBatchEditingEventArgs e)
        {
            var dataWidget = Widget as GridView;
            if (dataWidget != null && dataWidget.DataSource != null)
            {
                var ds = dataWidget.DataSource;
                foreach (var item in e.Commands)
                {
                    if (item.Type == GridBatchEditingCommandType.Update)
                    {
                        var id = item.Item.GetDataKeyValue("Id");
                        var obiekt = ds.GetObjectById(id.ToString());
                        obiekt.UpdateValuesFromHashtable(item.NewValues);
                        ds.Update(obiekt);
                    }
                }
            }
        }


        private void NsGrid_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {
            var dataWidget = Widget as GridView;
            var filter = MasterTableView.FilterExpression;
            var sort = MasterTableView.SortExpressions.GetSortString();
            var numerAktualnejStrony = CurrentPageIndex;
            var rozmiarStrony = PageSize;
            long iloscWszystkichDanych = 0;

            //foreach (var column in this.Columns)
            //{
            //    var k = column as GridBoundColumn;
            //    if (string.IsNullOrEmpty(k.CurrentFilterValue))
            //    {
                    
            //    }
            //}

            DataSource = dataWidget.GetData(numerAktualnejStrony*rozmiarStrony, rozmiarStrony, sort, filter,
                out iloscWszystkichDanych);
            VirtualItemCount = (int)iloscWszystkichDanych;

        }

        public static NsGrid UtworzGridView(GridView opisPola, bool isPostBack)
        {
            var radGrid = new NsGrid() { Widget = opisPola, ToolTip = opisPola.ToolTip };
            radGrid.AutoGenerateColumns = false;
            radGrid.MasterTableView.DataKeyNames = new string[] { "Id" };
            UstawParametryGrida(opisPola, radGrid, isPostBack);
            UtworzKolumny(opisPola.Columns, radGrid, isPostBack);

            return radGrid;
        }

        public static void UstawParametryGrida(GridView opisGrida, NsGrid radGrid, bool isPostBack)
        {
            radGrid.MasterTableView.CommandItemSettings.SaveChangesText = "Zapisz zmiany";
            radGrid.MasterTableView.CommandItemSettings.CancelChangesText = "Anuluj";
            radGrid.MasterTableView.CommandItemSettings.RefreshText = "Odśwież";
            radGrid.MasterTableView.CommandItemSettings.ShowAddNewRecordButton = false;
            radGrid.ShowHeader = true;
            radGrid.Width = Unit.Percentage(99);
            //radGrid.ClientSettings.AllowRowsDragDrop = opisPola.CzyDragDrop;
            radGrid.PagerStyle.Mode = GridPagerMode.NextPrevAndNumeric;
            radGrid.ShowStatusBar = true;
            radGrid.ShowFooter = true;
            radGrid.AllowMultiRowSelection = true;
            radGrid.EnableLinqExpressions = false;

            //Set options to enable Group-by
            radGrid.GroupingEnabled = false;
            radGrid.ShowGroupPanel = false;
            radGrid.ClientSettings.AllowDragToGroup = false;
            radGrid.ClientSettings.AllowColumnsReorder = false;
            radGrid.ClientSettings.Selecting.AllowRowSelect = true;
            radGrid.MasterTableView.EnableColumnsViewState = false;

            radGrid.AllowSorting = opisGrida.AllowSorting;
            radGrid.AllowPaging = opisGrida.AllowPaging;
            radGrid.PageSize = opisGrida.PageSize;
            radGrid.PagerStyle.PageSizes = new int[] { 20, 50, 100, 300, 3000 };
            radGrid.MasterTableView.PagerStyle.PageSizes = radGrid.PagerStyle.PageSizes;
            radGrid.AllowCustomPaging = opisGrida.AllowPaging;
            if (opisGrida.GroupingEnabled)
            {
                radGrid.ShowGroupPanel = true;
                radGrid.GroupingEnabled = true;
                radGrid.GroupPanel.Visible = true;
                radGrid.ClientSettings.AllowDragToGroup = true;
                radGrid.GroupPanel.Text = "Przeciągnij kolumnę żeby grupować";
            }

            if (opisGrida.AggregateEnabled)
            {
                radGrid.ShowFooter = true;
                radGrid.MasterTableView.ShowFooter = true;
            }

            if (opisGrida.AllowEditing == true)
            {
                radGrid.AllowAutomaticUpdates = false;

                //radGrid.
                radGrid.MasterTableView.BatchEditingSettings.EditType = GridBatchEditingType.Cell;
                radGrid.MasterTableView.BatchEditingSettings.OpenEditingEvent = GridBatchEditingEventType.DblClick;
                radGrid.MasterTableView.CommandItemDisplay = GridCommandItemDisplay.TopAndBottom;
                radGrid.ClientSettings.AllowKeyboardNavigation = true;
                radGrid.MasterTableView.EditMode = GridEditMode.Batch;
                radGrid.AllowAutomaticUpdates = false;
                radGrid.EnableHeaderContextMenu = true;
                radGrid.EnableHeaderContextFilterMenu = true;
            }

            if (opisGrida.AllowFilteringByColumn)
            {
                radGrid.AllowFilteringByColumn = true;
                radGrid.MasterTableView.AllowFilteringByColumn = true;
            }

        }

        public static void UtworzKolumny(List<GridViewColumn> kolumny, NsGrid radGrid, bool isPostBack)
        {
            foreach (var opisKolumny in kolumny)
            {
                GridEditableColumn column = null;
                if (opisKolumny.ColumnType == GridColumnType.CheckboxColumn)
                {
                    var cbColumn = new GridCheckBoxColumn();
                    cbColumn.DataField = opisKolumny.Name;
                    

                    column = cbColumn;
                }
                else if (opisKolumny.ColumnType == GridColumnType.BoundColumn)
                {
                    var bColumn = new GridBoundColumn();
                    bColumn.DataField = opisKolumny.Name;
                    bColumn.Aggregate = (Telerik.Web.UI.GridAggregateFunction)opisKolumny.Aggregate;
                    bColumn.DataFormatString = opisKolumny.DataFormatString;

                    column = bColumn;
                }
                

                column.UniqueName = opisKolumny.Name;
                
                column.HeaderText = opisKolumny.GetReadableName();
                column.HeaderTooltip = opisKolumny.ToolTip;
                column.FilterControlWidth = new Unit("80px");
                
                //boundColumn.ColumnEditorID = opisKolumny.ColumnEditorID;
                if (opisKolumny.Width != null)
                {
                    column.HeaderStyle.Width = new Unit(opisKolumny.Width.ToString());
                }
                //if (opisKolumny.NazwaTypuPola == "Decimal")
                //{
                
                //}
                if (opisKolumny.ShowColumnFilter)
                {
                    column.AutoPostBackOnFilter = true;
                    column.CurrentFilterFunction = (Telerik.Web.UI.GridKnownFunction)opisKolumny.FilterFunction;
                    column.ShowFilterIcon = false;

                    if (isPostBack == false)
                    {
                        column.CurrentFilterValue = opisKolumny.FilterDefaultValue;
                        if (string.IsNullOrEmpty(opisKolumny.FilterDefaultValue) == false)
                        {
                            var filtr = "([" + opisKolumny.Name + "] = '" + opisKolumny.FilterDefaultValue + "')";

                            if (string.IsNullOrEmpty(radGrid.MasterTableView.FilterExpression))
                            {
                                radGrid.MasterTableView.FilterExpression = filtr;
                            }
                            else
                            {
                                radGrid.MasterTableView.FilterExpression = radGrid.MasterTableView.FilterExpression +
                                                                           " AND " +
                                                                           filtr;
                            }
                        }
                    }
                }

                radGrid.MasterTableView.Columns.Add(column);
                
            }
        }
    }
}