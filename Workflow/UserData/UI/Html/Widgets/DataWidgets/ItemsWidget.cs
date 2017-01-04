using System.Collections;
using NeuroSystem.Workflow.UserData.UI.Html.DataSources;
using NeuroSystem.Workflow.UserData.UI.Html.ViewModel;
using System.Collections.Generic;

namespace NeuroSystem.Workflow.UserData.UI.Html.Widgets.DataWidgets
{
    public class ItemsWidget : WidgetBase
    {
        public ItemsWidget()
        {
            AutoLoadDataSource = true;
            DataValueField = "Id";
            DataIdField = "Id";
            DataFieldParentId = "RodzicId";
        }

        /// <summary>
        /// Bindowanie do źródła danych - kolekcji
        /// </summary>
        public object ItemsSource { get; set; } //binding do kolekcji

        /// <summary>
        /// Zródło danych - jeśli jest ustawiony i ItemsSource i DataSource to DataSource jest wykorzystywany
        /// </summary>
        public DataSourceBase DataSource { get; set; }

        /// <summary>
        /// Bindowanie do Obiektu zaznaczonego
        /// </summary>
        public object SelectedItem { get; set; }

        /// <summary>
        /// Bindowanie do wartości tekstowej 
        /// </summary>
        public object SelectedValue { get; set; }

        /// <summary>
        /// Zaznaczone id'ki z kontrolki
        /// </summary>
        public List<string> SelectedIds { get; set; }

        public string DataValueField { get; set; } //ValueField dla elementu kolekcji

        public string DataIdField { get; set; } //IdField dla elementu kolekcji

        public string DataFieldParentId { get; set; }

        public string DataTextField { get; set; } //TextField dla elementu kolekcji

        public bool AutoLoadDataSource { get; set; }


        #region Data access

        /// <summary>
        /// Metoda zwraca wszystkie dane albo z ItemSource albo z DataSource
        /// </summary>
        /// <returns></returns>
        public object GetAllData()
        {
            if (ItemsSource != null)
            {
                //zwracam z ItemsSource
                return Binding.PobierzWartosc(ItemsSource, DataContext);
            }
            else if( DataSource != null)
            {
                return DataSource.GetAll();
            }
            return null;
        }

        public object GetData(long start, long count, string sort, string filtr,
            out long virtualItemsCout)
        {
            if (ItemsSource != null)
            {
                //zwracam z ItemsSource
                var ret = Binding.PobierzWartosc(ItemsSource, DataContext);
                if (ret is ICollection)
                {
                    var collection = ret as ICollection;
                    virtualItemsCout = collection.Count;
                }
            }
            else if (DataSource != null)
            {
                return DataSource.GetData(start, count, sort, filtr, out virtualItemsCout);
            }

            virtualItemsCout = 0;
            return null;
        }

        #endregion
    }
}
