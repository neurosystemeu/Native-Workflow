using System;
using System.Collections.Specialized;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NeuroSystem.Workflow.UserData.UI.Html.ASP.UI.Html.Version1.Widgets.DataForms.Columns
{
    public class EnumEditColumnTemplate : ITemplate, IBindableTemplate
    {
        protected DropDownList ddl;
        protected Type TypEnuma;
        private string colname;
        public EnumEditColumnTemplate(string cName, Type enumTyp)
        {
            TypEnuma = enumTyp;
            colname = cName;
        }

        public IOrderedDictionary ExtractValues(Control container)
        {
            return new OrderedDictionary();
        }

        public void InstantiateIn(System.Web.UI.Control container)
        {
            ddl = new DropDownList();
            foreach (var value in Enum.GetValues(TypEnuma))
            {
                var i = new ListItem(value.ToString(), value.ToString());
                ddl.Items.Add(i);
            }

            container.Controls.Add(ddl);
        }
    }
}
