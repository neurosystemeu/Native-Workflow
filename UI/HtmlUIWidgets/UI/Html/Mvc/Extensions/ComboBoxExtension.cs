using System.Web.Mvc;
using Kendo.Mvc;
using Kendo.Mvc.Infrastructure;
using NeuroSystem.Workflow.UserData.UI.Html.Mvc.UI;

namespace NeuroSystem.Workflow.UserData.UI.Html.Mvc.Extensions
{
    public static class ComboBoxExtension
    {
        public static Kendo.Mvc.UI.WidgetBase ToKendoWidget(this ComboBox widget, HtmlHelper helper,
            IJavaScriptInitializer initializer, IUrlGenerator urlGenerator)
        {
            
            


            if (widget.DataSource.Type == UserData.UI.Html.Mvc.DataSourceType.Server)
            {
                var kendoFabric = Kendo.Mvc.UI.HtmlHelperExtension.Kendo(helper).ComboBox();
                kendoFabric.Filter("contains");
                var control = kendoFabric.ToComponent();
                control.Name = widget.Name;
                control.DataValueField = widget.DataValueField;
                control.DataTextField = widget.DataTextField;
                control.SelectedIndex = widget.SelectedIndex;
                control.DataSource.Data = widget.DataSource.Data;

                return control;
            }
            else
            {
                var cb = Kendo.Mvc.UI.HtmlHelperExtension.Kendo(helper)
                    .ComboBox()
                    .Name(widget.Name)
                    .DataTextField(widget.DataTextField)
                    .DataValueField(widget.DataValueField)
                    //.HtmlAttributes(new {style = "width:100%;"})
                    .Filter("contains")
                    .DataSource(source =>
                    {
                        source.Read(read =>
                        {
                            read.Action(widget.DataSource.Transport.Read.ActionName,
                                widget.DataSource.Transport.Read.ControllerName
                                ?? helper.ViewContext.Controller.GetType().Name.Replace("Controller", ""));
                        }).ServerFiltering(true);
                    });

                var combobox = cb.ToComponent();
                return combobox;

                //var kendoFabric = Kendo.Mvc.UI.HtmlHelperExtension.Kendo(helper).ComboBox();
                //kendoFabric.Filter("contains");
                //var control = kendoFabric.ToComponent();
                //control.Name = widget.Name;
                //control.DataValueField = widget.DataValueField;
                //control.DataTextField = widget.DataTextField;
                //control.SelectedIndex = widget.SelectedIndex;

                //widget.DataSource.SetDataSource(control.DataSource, helper, initializer,urlGenerator);
                
                //return control;
            }

            
        }
    }
}
