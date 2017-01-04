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

        public void WczytajDoKontrolkiZMW()
        {
            //var dataWidget = Widget as GridView;
            //var date = Binding.PobierzWartosc(dataWidget.SelectedValue, dataWidget.DataContext);
            //SelectedValue = date;
        }

        public void ZapiszDoMWZKontrolki()
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

            DataSource = dataWidget.GetData(numerAktualnejStrony*rozmiarStrony, rozmiarStrony, sort, filter,
                out iloscWszystkichDanych);
            VirtualItemCount = (int)iloscWszystkichDanych;

        }

        public static NsGrid UtworzGridView(GridView opisPola)
        {
            var radGrid = new NsGrid() { Widget = opisPola, ToolTip = opisPola.ToolTip };
            UstawParametryGrida(opisPola, radGrid);
            UtworzKolumny(opisPola.Columns, radGrid);
            radGrid.AutoGenerateColumns = false;
            radGrid.MasterTableView.DataKeyNames = new string[] { "Id" };
            return radGrid;
        }

        public static void UstawParametryGrida(GridView opisGrida, NsGrid radGrid)
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

            radGrid.AllowPaging = opisGrida.AllowPaging;
            radGrid.AllowCustomPaging = opisGrida.AllowPaging;

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

        }

        public static void UtworzKolumny(List<GridViewColumn> kolumny, NsGrid radGrid)
        {
            foreach (var opisKolumny in kolumny)
            {
                var boundColumn = new GridBoundColumn();
                boundColumn.UniqueName = opisKolumny.Name;
                boundColumn.DataField = opisKolumny.Name;
                boundColumn.HeaderText = opisKolumny.GetReadableName();
                boundColumn.HeaderTooltip = opisKolumny.ToolTip;
                boundColumn.FilterControlWidth = new Unit("80px");
                //boundColumn.ColumnEditorID = opisKolumny.ColumnEditorID;
                if (opisKolumny.Width != null)
                {
                    boundColumn.HeaderStyle.Width = new Unit(opisKolumny.Width.ToString());
                }
                //if (opisKolumny.NazwaTypuPola == "Decimal")
                //{
                //    boundColumn.DataFormatString = "{0:#.##}";
                //}

                radGrid.MasterTableView.Columns.Add(boundColumn);
            }
        }
    }
}