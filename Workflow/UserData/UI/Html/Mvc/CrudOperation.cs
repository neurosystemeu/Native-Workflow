namespace NeuroSystem.Workflow.UserData.UI.Html.Mvc
{
    public class CrudOperation
    {
        public string ActionName { get; set; }

        public bool Cache { get; set; }

        public string ContentType { get; set; }

        public string ControllerName { get; set; }
        
        public string DataType
        {
            get;
            set;
        }

        public string Type
        {
            get;
            set;
        }

        public string Url
        {
            get;
            set;
        }
    }
}
