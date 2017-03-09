using NeuroSystem.Workflow.UserData.UI.Html.DataSources;
using NeuroSystem.Workflow.UserData.UI.Html.Fluent.DataSources;
using NeuroSystem.Workflow.UserData.UI.Html.Widgets.DataWidgets;

namespace NeuroSystem.Workflow.UserData.UI.Html.Fluent.Widgets.DataWidgets
{
    public class ItemsWidgetsFactory<T> : WidgetFactory<T>
    {
        public ItemsWidget ItemsWidget => Widget as ItemsWidget;

        public DataSourceFactory<T> DataSource(DataSourceBase dataSource)
        {
            var sourceFactory = new DataSourceFactory<T>();
            sourceFactory.DataSource = dataSource;
            ItemsWidget.DataSource = dataSource;
            return sourceFactory;
        }

        public ItemsWidgetsFactory<T> DataIdField(string dataIdField)
        {
            ItemsWidget.DataIdField = dataIdField;
            return this;
        }

        public ItemsWidgetsFactory<T> DataTextField(string dataTextField)
        {
            ItemsWidget.DataTextField = dataTextField;
            return this;
        }

        public ItemsWidgetsFactory<T> DataValueField(string dataValueField)
        {
            ItemsWidget.DataValueField = dataValueField;
            return this;
        }

        public ItemsWidgetsFactory<T> SelectedItem(object selectedItem)
        {
            ItemsWidget.SelectedItem = selectedItem;
            return this;
        }

        public ItemsWidgetsFactory<T> SelectedValue(object selectedValue)
        {
            ItemsWidget.SelectedValue = selectedValue;
            return this;
        }

        public ItemsWidgetsFactory<T> ItemsSource(object itemsSource)
        {
            ItemsWidget.ItemsSource = itemsSource;
            return this;
        }

        //AutoLoadDataSource
        public ItemsWidgetsFactory<T> LoadOnDemand(bool loadOnDemand)
        {
            ItemsWidget.LoadOnDemand = loadOnDemand;
            return this;
        }
    }
}
