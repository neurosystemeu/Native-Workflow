using System;
using System.Web.Mvc;
using Kendo.Mvc;
using Kendo.Mvc.Infrastructure;
using NeuroSystem.Workflow.UserData.UI.Html.Mvc.TestViews;

namespace NeuroSystem.Workflow.UserData.UI.Html.Mvc.Extensions
{
    public static class DataSourceExtension
    {
        public static void SetDataSource(this DataSource ds, Kendo.Mvc.UI.DataSource datasource,
            HtmlHelper helper, IJavaScriptInitializer initializer, IUrlGenerator urlGenerator) 
        {
            
            if (ds.Type==null || ds.Type.Value == UserData.UI.Html.Mvc.DataSourceType.Custom)
            {
                var dsb = new Kendo.Mvc.UI.Fluent.DataSourceBuilder<PracownikTest>(datasource, helper.ViewContext,
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
                var dsbType = typeof(Kendo.Mvc.UI.Fluent.DataSourceBuilder<>).MakeGenericType(ds.ObjectType);
                dynamic dsb = Activator.CreateInstance(dsbType, datasource, helper.ViewContext, urlGenerator);
                
                //var dsb = new Kendo.Mvc.UI.Fluent.DataSourceBuilder<object>(datasource, helper.ViewContext,
                //    urlGenerator);
                var ajax = dsb.Ajax();
                    //ajax.Model(m => m.Id("Id"));
                    ajax.Read(ds.Transport.Read.ActionName, 
                        ds.Transport.Read.ControllerName ?? helper.ViewContext.Controller.GetType().Name.Replace("Controller","")
                        );
            } 

            //datasource.Type = DataSourceType.Ajax;
            //datasource.Transport.Read.ActionName = ds.Transport.Read.ActionName;
            //datasource.Transport.Read.ControllerName = ds.Transport.Read.ControllerName;
            //datasource.Schema.Model.

        }
    }
}
