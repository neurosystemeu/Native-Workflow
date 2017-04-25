using Telerik.Web.UI;

namespace NeuroSystem.Workflow.UserData.UI.Html.Version1.Widgets.Ribbon
{
    public class NsRibbonTab : RibbonBarTab
    {
        public void DodajGrupe(NsRibbonGrupa grupa)
        {
            Groups.Add(grupa);
        }

        public string Nazwa { get; set; }

        //public List<IRibbonGrupa> Grupy
        //{
        //    get
        //    {
        //        var lista = new List<IRibbonGrupa>();
        //        foreach (var grupa in Groups)
        //        {
        //            var g = grupa as IRibbonGrupa;
        //            if (g != null)
        //            {
        //                lista.Add(g);
        //            }
        //        }

        //        return lista;
        //    }
        //}
    }
}