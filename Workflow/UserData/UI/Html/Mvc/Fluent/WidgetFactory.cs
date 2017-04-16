using NeuroSystem.Workflow.UserData.UI.Html.Mvc.UI;

namespace NeuroSystem.Workflow.UserData.UI.Html.Mvc.Fluent
{
    public class WidgetFactory
    {
        public object Helper;

        public WidgetFactory()
        {
        }

        public WidgetFactory(object helper)
        {
            this.Helper = helper;
        }

        /// <summary>
        /// Creates a new <see cref="M:Kendo.Mvc.UI.Fluent.WidgetFactory.AutoComplete" />.
        /// </summary>
        /// <example>
        /// <code lang="CS">
        ///  &lt;%= Html.Kendo().AutoComplete()
        ///             .Name("AutoComplete")
        ///             .Items(items =&gt;
        ///             {
        ///                 items.Add().Text("First Item");
        ///                 items.Add().Text("Second Item");
        ///             })
        /// %&gt;
        /// </code>
        /// </example>
        public virtual AutoCompleteBuilder AutoComplete()
        {
            return new AutoCompleteBuilder(new AutoComplete());
        }

        public virtual PanelBuilder Panel()
        {
            return new PanelBuilder(new Panel());
        }

        public virtual PanelBuilder<T> Panel<T>()
        {
            return new PanelBuilder<T>(new Panel<T>());
        }

        /// <summary>
        /// Creates a new <see cref="M:Kendo.Mvc.UI.Fluent.WidgetFactory.TextBox" />.
        /// </summary>
        /// <example>
        /// <code lang="CS">
        ///  &lt;%= Html.Kendo().TextBox()
        ///             .Name("TextBox")
        /// %&gt;
        /// </code>
        /// </example>
        public virtual TextBoxBuilder<string> TextBox()
        {
            return new TextBoxBuilder<string>(new TextBox<string>());
        }

        /// <summary>
        /// Creates a new <see cref="M:Kendo.Mvc.UI.Fluent.WidgetFactory.TextBox``1" />.
        /// </summary>
        /// <example>
        /// <code lang="CS">
        ///  &lt;%= Html.Kendo().TextBox&lt;double&gt;()
        ///             .Name("TextBox")
        /// %&gt;
        /// </code>
        /// </example>
        public virtual TextBoxBuilder<T> TextBox<T>()
        {
            return new TextBoxBuilder<T>(new TextBox<T>());
        }

        /// <summary>
        /// Creates a new <see cref="M:Kendo.Mvc.UI.Fluent.WidgetFactory.DatePicker" />.
        /// </summary>
        /// <example>
        /// <code lang="CS">
        ///  &lt;%= Html.Kendo().DatePicker()
        ///             .Name("DatePicker")
        /// %&gt;
        /// </code>
        /// </example>
        public virtual DatePickerBuilder DatePicker()
        {
            return new DatePickerBuilder(new DatePicker());
        }

        /// <summary>
        /// Creates a new <see cref="M:Kendo.Mvc.UI.Fluent.WidgetFactory.ComboBox" />.
        /// </summary>
        /// <example>
        /// <code lang="CS">
        ///  &lt;%= Html.Kendo().ComboBox()
        ///             .Name("ComboBox")
        ///             .Items(items =&gt;
        ///             {
        ///                 items.Add().Text("First Item");
        ///                 items.Add().Text("Second Item");
        ///             })
        /// %&gt;
        /// </code>
        /// </example>
        public virtual ComboBoxBuilder ComboBox()
        {
            return new ComboBoxBuilder(new ComboBox());
        }

        /// <summary>
        /// Creates a new <see cref="T:Kendo.Mvc.UI.Grid`1" /> bound to the specified data item type.
        /// </summary>
        /// <example>
        /// <typeparam name="T">The type of the data item</typeparam>
        /// <code lang="CS">
        ///  &lt;%= Html.Kendo().Grid&lt;Order&gt;()
        ///             .Name("Grid")
        ///             .BindTo(Model)
        /// %&gt;
        /// </code>
        /// </example>      
        public virtual GridBuilder<T> Grid<T>()
        where T : class
        {
            return new GridBuilder<T>(new Grid<T>());
        }
    }
}
