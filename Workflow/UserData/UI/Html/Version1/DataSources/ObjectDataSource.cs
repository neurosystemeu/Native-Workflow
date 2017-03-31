using System.Collections;

namespace NeuroSystem.Workflow.UserData.UI.Html.Version1.DataSources
{
    public class ObjectDataSource : DataSourceBase
    {
        public ObjectDataSource()
        {
        }

        public ObjectDataSource(IList dataObject)
        {
            DataObject = dataObject;
        }

        public IList DataObject { get; set; }

        public override object GetAll(string filtr = null)
        {
            return DataObject;
        }

        public override object GetData(long start, long cout, string sort, string filtr, out long virtualItemsCout)
        {
            virtualItemsCout = DataObject.Count;
            return DataObject;
        }
    }
}
