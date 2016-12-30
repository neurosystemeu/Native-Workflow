using NeuroSystem.Workflow.UserData.UI.Html.DataSources;

namespace NeuroSystem.Workflow.UserData.UI.Html.Widgets.DataWidgets
{
    public class ItemsWidget : WidgetBase
    {
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

        public string DataValueField { get; set; } //ValueField dla elementu kolekcji

        public string DataIdField { get; set; } //IdField dla elementu kolekcji

        public string DataTextField { get; set; } //TextField dla elementu kolekcji

    }
}
