using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NeuroSystem.Workflow.UserData.UI.Html.ViewModel;
using NeuroSystem.Workflow.UserData.UI.Html.Widgets;
using NeuroSystem.Workflow.UserData.UI.Html.Widgets.ItemsWidgets;
using Telerik.Web.UI;

namespace NeuroSystem.Workflow.UserData.UI.Html.ASP.UI.Html.Widgets.DataForms
{
    public class NsGrid : RadGrid, IBindingControl
    {
        public NsGrid()
        {
            this.NeedDataSource += NsGrid_NeedDataSource;
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
            var binding = dataWidget.SelectedValue;
            Binding.UstawWartosc(ref binding, dataWidget.DataContext, SelectedValue);
            dataWidget.SelectedValue = binding; //w binding może być wartość - dane bez bindowania
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

        }

        internal static NsGrid UtworzGridView(GridView opisPola)
        {
            var cb = new NsGrid() { Widget = opisPola, ToolTip = opisPola.ToolTip };
            return cb;
        }
    }
}