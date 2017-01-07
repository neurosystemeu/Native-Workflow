using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NeuroSystem.Workflow.UserData.UI.Html.Widgets.ItemsWidgets;

namespace NeuroSystem.Workflow.Core.Process.ProcessWithUI.Html
{
    public class ListProcess<T> : EditProcess<T>
    {
        public override object Start()
        {
            while (true)
            {
                var widokListy = GridView<T>();
                widokListy.DataSource(GetDataSource());
                widokListy.AddAction("Edytuj");
                widokListy.AddAction("Zamknij");

                var wynikListy = ShowView(widokListy);
                if (wynikListy.ActionName == "Edytuj")
                {
                    var grid = wynikListy.Panel.GetWidgetByType<GridView>();
                    var zaznaczonyObiekt = grid.SelectedValue?.ToString();
                    if (zaznaczonyObiekt == null)
                    {
                        continue;
                    }

                    //Edycja
                    var obiekt = GetObjectById(zaznaczonyObiekt);
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
                        continue;
                    }
                }
                else
                {
                    return "Zakończono listę " + nameof(T);
                }
            }
        }

        public virtual T GetObjectById(string id)
        {
            var ds = GetDataSource();
            return (T)ds.GetObjectById(id);
        }
    }
}
