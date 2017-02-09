using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NeuroSystem.VirtualMachine.Core.Attributes;
using NeuroSystem.Workflow.Core.Extensions;
using NeuroSystem.Workflow.UserData.UI.Html.Fluent.Views;
using NeuroSystem.Workflow.UserData.UI.Html.Widgets.ItemsWidgets;

namespace NeuroSystem.Workflow.Core.Process.ProcessWithUI.Html
{
    public class ListProcess<T> : EditProcess<T>
    {
        public override object Start()
        {
            while (true)
            {
                var widokListy = CreateGridView<T>(
                    "Lista obiektów typu '" + typeof(T).Name + "'",
                    typeof(T).GetClassDescription());
                widokListy.DataSource(GetDataSource());
                generateMenu(widokListy);

                var wynikListy = ShowView(widokListy);
                var grid = wynikListy.Panel.GetWidgetByType<GridView>();

                if (wynikListy.ActionName == "Dodaj nowy")
                {
                    AddNewObject();
                }
                else
                {
                    var zaznaczonyObiekt = grid.SelectedValue?.ToString();
                    if (zaznaczonyObiekt == null)
                    {
                        //continue;
                    }
                    else if (wynikListy.ActionName == "Edytuj")
                    {
                        Edit(zaznaczonyObiekt);
                    }
                    else if (wynikListy.ActionName == "Usuń")
                    {
                        Delete(grid);
                    }
                    else if (wynikListy.ActionName == "Zamknij")
                    {
                        EndProcess("Zakończono listę " + nameof(T));
                    }
                }
            }
            return null;
        }

        private void generateMenu(UserData.UI.Html.Fluent.Views.ListViewFactory<T> widokListy)
        {
            widokListy.AddAction("Edytuj");
            widokListy.AddAction("Dodaj nowy");
            widokListy.AddAction("Usuń");
            widokListy.AddAction("Zamknij");
            //dodaje akce użytkownika
            foreach (var userAction in UserActions)
            {
                widokListy.AddAction(userAction);
            }
        }

        [Interpret]
        public void Edit(string selectedObjectId)
        {
            var obiekt = GetObjectById(selectedObjectId);
            var widokEdycji = CreateEditView(obiekt);
            widokEdycji.AddAction("Zapisz");
            widokEdycji.AddAction("Anuluj");

            var wynikEdycji = ShowView(widokEdycji);
            if (wynikEdycji.ActionName == "Zapisz")
            {
                obiekt = (T)wynikEdycji.DataContext;

                UpdateObject(obiekt);
                ShowMessage("Zapisano zmiany w " + obiekt);
            }
        }

        


        [Interpret]
        public void AddNewObject()
        {
            var obiekt = CreateNewObject();
            var widokEdycji = CreateEditView(obiekt);
            widokEdycji.AddAction("Dodaj");
            widokEdycji.AddAction("Anuluj");

            var wynikEdycji = ShowView(widokEdycji);
            if (wynikEdycji.ActionName == "Dodaj")
            {
                obiekt = (T)wynikEdycji.DataContext;

                AddObject(obiekt);
                wynikEdycji.Panel?.SetDataContext(null);
                obiekt = default(T); //null'uje obiekt żeby go nie serializować
                ShowMessage("Dodano nowy obiektu " + obiekt);
            }
        }

        [Interpret]
        public void Delete(GridView grid)
        {
            DeleteObjects(grid);
            ShowMessage("Usunięto obiekt o Id "+ grid.SelectedValue?.ToString());
        }

        public virtual string DeleteObjects(GridView grid)
        {
            string zaznaczoneObiekty = "";
            if (grid.SelectedIds != null && grid.SelectedIds.Any())
            {
                foreach (var gridSelectedId in grid.SelectedIds)
                {
                    zaznaczoneObiekty += gridSelectedId + ";";
                    DeleteObject(gridSelectedId);
                }
            }
            else
            {
                var zaznaczonyObiekt = grid.SelectedValue?.ToString();
                zaznaczoneObiekty += zaznaczonyObiekt + ";";
                DeleteObject(zaznaczonyObiekt);
            }
            return zaznaczoneObiekty;
        }

        public virtual void DeleteObject(string id)
        {
            var ds = GetDataSource();
            ds.DeleteById(id);
        }

        public virtual T GetObjectById(string id)
        {
            var ds = GetDataSource();
            return (T)ds.GetObjectById(id, true);
        }

        public virtual T CreateNewObject()
        {
            var ds = GetDataSource();
            return (T)ds.CreateNewObject();
        }

        public virtual void AddObject(object newObject)
        {
            var ds = GetDataSource();
            ds.Add(newObject);
        }
    }
}
