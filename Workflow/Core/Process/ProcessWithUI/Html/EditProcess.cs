using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NeuroSystem.Workflow.UserData.UI.Html.DataSources;

namespace NeuroSystem.Workflow.Core.Process.ProcessWithUI.Html
{
    public class EditProcess<T> : HtmlProcessBase
    {
        public override object Start()
        {
            var obiekt = (T)ProcesInput;
            var widokEdycji = DataFormView(obiekt);
            widokEdycji.AddAction("Zapisz");
            widokEdycji.AddAction("Anuluj");

            var wynikEdycji = ShowView(widokEdycji);
            if (wynikEdycji.ActionName == "Zapisz")
            {
                UpdateObject(obiekt);
                return "Wykonano edycję obiektu " + obiekt;
            }
            else
            {
                return "Anulowano edycję " + obiekt;
            }
        }

        public virtual DataSourceBase GetDataSource()
        {
            return null;
        }

        public virtual void UpdateObject(T obiekt)
        {
            var ds = GetDataSource();
            ds.Update(obiekt);
        }
    }
}
