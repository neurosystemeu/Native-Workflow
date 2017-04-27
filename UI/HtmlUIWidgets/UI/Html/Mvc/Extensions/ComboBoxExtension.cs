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
            var kendoFabric = Kendo.Mvc.UI.HtmlHelperExtension.Kendo(helper).ComboBox();
            var control = kendoFabric.ToComponent();
            control.Name = widget.Name;
            control.DataValueField = widget.DataValueField;
            control.DataTextField = widget.DataTextField;
            control.SelectedIndex = widget.SelectedIndex;
            
            if (widget.DataSource.Type == UserData.UI.Html.Mvc.DataSourceType.Server)
            {
                control.DataSource.Data = widget.DataSource.Data;
            }
            else
            {
                widget.DataSource.SetDataSource(control.DataSource, helper, initializer,urlGenerator);
            }

            return control;
        }
    }
}
