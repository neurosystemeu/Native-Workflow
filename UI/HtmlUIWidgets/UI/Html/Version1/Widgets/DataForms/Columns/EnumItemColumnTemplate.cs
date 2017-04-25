using System;
using System.Collections.Specialized;
using System.Web.UI;
using NeuroSystem.Workflow.Core.Extensions;
using Telerik.Web.UI;

namespace NeuroSystem.Workflow.UserData.UI.Html.Version1.Widgets.DataForms.Columns
{
    public class EnumItemColumnTemplate : ITemplate, IBindableTemplate
    {
        protected LiteralControl lControl;
        
        private string colname;
        public EnumItemColumnTemplate(string cName)
        {
            colname = cName;
        }

        public IOrderedDictionary ExtractValues(Control container)
        {
            return new OrderedDictionary();
        }

        public void InstantiateIn(System.Web.UI.Control container)
        {
            lControl = new LiteralControl();
            lControl.ID = "lControl";
            lControl.DataBinding += new EventHandler(lControl_DataBinding);
            container.Controls.Add(lControl);
            
        }
        public void lControl_DataBinding(object sender, EventArgs e)
        {
            LiteralControl l = (LiteralControl)sender;
            GridDataItem container = (GridDataItem)l.NamingContainer;
            l.Text = container.DataItem.GetPropValue(colname)?.ToString();
        }
    }
}
