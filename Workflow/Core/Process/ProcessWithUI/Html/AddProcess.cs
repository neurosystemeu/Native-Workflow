using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NeuroSystem.Workflow.Core.Extensions;
using NeuroSystem.Workflow.UserData.UI.Html.DataSources;

namespace NeuroSystem.Workflow.Core.Process.ProcessWithUI.Html
{
    public class AddProcess<T> : EditProcess<T>
    {
        public override object Start()
        {
            var obiekt = CreateNewObject();
            var widokEdycji = CreateDataFormView(obiekt, description:this.GetType().GetClassDescription());
            widokEdycji.AddAction("Dodaj");
            widokEdycji.AddAction("Anuluj");

            var wynikEdycji = ShowView(widokEdycji);
            if (wynikEdycji.ActionName == "Dodaj")
            {
                UpdateObject(obiekt);
                return "Dodano obiekt " + obiekt;
            }
            else
            {
                return "Anulowano dodawanie obiektu " + obiekt;
            }
        }

        public virtual void AddObject(T obiekt)
        {
            var ds = GetDataSource();
            ds.Add(obiekt);
        }

        public virtual T CreateNewObject()
        {
            var ds = GetDataSource();
            return (T)ds.CreateNewObject();
        }
    }
}
