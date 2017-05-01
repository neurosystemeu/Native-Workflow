using System.Web.Mvc;
using Kendo.Mvc.Infrastructure;
using NeuroSystem.Workflow.UserData.UI.Html.Mvc.UI;

namespace NeuroSystem.Workflow.UserData.UI.Html.Mvc.Extensions
{
    public static class GridExtension
    {
        public static Kendo.Mvc.UI.WidgetBase ToKendoWidget(this Grid widget, HtmlHelper helper,
            IJavaScriptInitializer initializer)
        {
            var kendoFabric = Kendo.Mvc.UI.HtmlHelperExtension.Kendo(helper).Grid<object>();
            kendoFabric
                .Name(widget.Name);

            foreach (var widgetColumn in widget.Columns)
            {
                kendoFabric.Columns(columns =>
                {
                    columns.Bound(widgetColumn.Name);
                });
            }

            kendoFabric.Filterable()
                .Sortable()
                .Pageable(p =>
                {
                    p.PageSizes(new int[] {10, 50, 100, 200});
                })
                .DataSource(dataSource => dataSource
                    .Ajax()
                    .PageSize(10)
                    .Read(read => read.Action("PracownikTest_Read", "Proces", new { id = widget.DataSourceFilter }))
                );

            return kendoFabric.ToComponent();
        }
    }
}
