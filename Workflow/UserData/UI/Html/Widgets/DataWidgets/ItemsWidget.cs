namespace NeuroSystem.Workflow.UserData.UI.Html.Widget.Data
{
    public class ItemsWidget : WidgetBase
    {
        /// <summary>
        /// Bindowanie do Obiektu zaznaczonego
        /// </summary>
        public object SelectedItem { get; set; }

        /// <summary>
        /// Bindowanie do wartości tekstowej 
        /// </summary>
        public object SelectedValue { get; set; }

        /// <summary>
        /// Bindowanie do źródła danych - kolekcji
        /// </summary>
        public object ItemsSource { get; set; } //binding do kolekcji

        public string DataValueField { get; set; } //ValueField dla elementu kolekcji

        public string DataTextField { get; set; } //TextField dla elementu kolekcji

    }
}
