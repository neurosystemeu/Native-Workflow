namespace NeuroSystem.Workflow.UserData.UI.Html.Mvc.UI
{
    public class TextBox<T> : WidgetBase<T>
    {
        public bool Enabled { get; set; }

        public string Format { get; set; }

        public T Value { get; set; }

        public TextBox()
        {
            this.Enabled = true;
        }
    }
}
