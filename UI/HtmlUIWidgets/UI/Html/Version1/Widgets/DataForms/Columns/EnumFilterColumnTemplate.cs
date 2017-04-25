using System;
using System.Collections.Specialized;
using System.Web.UI;
using Telerik.Web.UI;

namespace NeuroSystem.Workflow.UserData.UI.Html.ASP.UI.Html.Version1.Widgets.DataForms.Columns
{
    public class EnumFilterColumnTemplate : ITemplate, IBindableTemplate
    {
        protected RadComboBox cb;
        protected Type TypEnuma;
        protected Page Page;
        private string colname;
        public EnumFilterColumnTemplate(string cName, Type enumTyp, Page page)
        {
            TypEnuma = enumTyp;
            colname = cName;
            Page = page;
        }

        public IOrderedDictionary ExtractValues(Control container)
        {
            return new OrderedDictionary();
        }

        public void InstantiateIn(System.Web.UI.Control container)
        {
            cb = new RadComboBox();
            foreach (var value in Enum.GetValues(TypEnuma))
            {
                var i = new RadComboBoxItem(value.ToString() , "'" + value+ "'");
                cb.Items.Add(i);
            }
            cb.OnClientSelectedIndexChanged = colname+"IndexChanged";

            container.Controls.Add(cb);

            string script = "function "+colname+"IndexChanged(sender, args) {" +
			"var tableView = $find(\""+ ((Telerik.Web.UI.GridItem)container.Parent).OwnerTableView.ClientID+"\");" +
            //"debugger;"+
			"tableView.filter(\""+colname+"\", args.get_item().get_value(), \"EqualTo\");}";
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "script", script, true);
        }
    }
}
