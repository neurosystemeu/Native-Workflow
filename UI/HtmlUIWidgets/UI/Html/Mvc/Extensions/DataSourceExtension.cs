using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Kendo.Mvc;
using Kendo.Mvc.Infrastructure;
using NeuroSystem.Workflow.UserData.UI.Html.ASP.UI.Html.Version2.TestViews;
using NeuroSystem.Workflow.UserData.UI.Html.Mvc;
using DataSourceType = Kendo.Mvc.UI.DataSourceType;

namespace NeuroSystem.Workflow.UserData.UI.Html.ASP.UI.Html.Mvc.Extensions
{
    public static class DataSourceExtension
    {
        public static void SetDataSource(this DataSource ds, Kendo.Mvc.UI.DataSource datasource,
            ViewContext viewContext,IJavaScriptInitializer initializer, ViewDataDictionary viewData,
            IUrlGenerator urlGenerator) 
        {
            if (ds.Type==null || ds.Type.Value == UserData.UI.Html.Mvc.DataSourceType.Custom)
            {
                var dsb = new Kendo.Mvc.UI.Fluent.DataSourceBuilder<PracownikTest>(datasource, viewContext,
                    urlGenerator);
                dsb.Custom().Transport(t =>
                t.Read(ds.Transport.Read.ActionName, ds.Transport.Read.ControllerName))
                .Schema(schema =>
                {
                    schema.Data("Data") //Define the [data](http://docs.telerik.com/kendo-ui/api/javascript/data/datasource#configuration-schema.data) option.
                          .Total("Total"); //Define the [total](http://docs.telerik.com/kendo-ui/api/javascript/data/datasource#configuration-schema.total) option.
                })
                .ServerFiltering(true);
            } else
            if (ds.Type == UserData.UI.Html.Mvc.DataSourceType.Ajax)
            {

                var dsb = new Kendo.Mvc.UI.Fluent.DataSourceBuilder<PracownikTest>(datasource, viewContext,
                    urlGenerator);
                dsb.Ajax()
                    .Model(m => m.Id("Id"))
                    .Read(ds.Transport.Read.ActionName, ds.Transport.Read.ControllerName);
            } 

            //datasource.Type = DataSourceType.Ajax;
            //datasource.Transport.Read.ActionName = ds.Transport.Read.ActionName;
            //datasource.Transport.Read.ControllerName = ds.Transport.Read.ControllerName;
            //datasource.Schema.Model.

        }
    }
}
