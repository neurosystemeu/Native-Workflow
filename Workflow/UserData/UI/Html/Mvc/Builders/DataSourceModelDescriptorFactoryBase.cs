using NeuroSystem.Workflow.UserData.UI.Html.Mvc.UI;

namespace NeuroSystem.Workflow.UserData.UI.Html.Mvc.Builders
{
    /// <summary>
    /// Defines the fluent interface for configuring the <see cref="T:Kendo.Mvc.UI.DataSource" /> Model definition.
    /// </summary>
    /// <typeparam name="TModel">Type of the model</typeparam>
    public abstract class DataSourceModelDescriptorFactoryBase<TModel> 
    where TModel : class
    {
        protected readonly ModelDescriptor model;

        public DataSourceModelDescriptorFactoryBase(ModelDescriptor model)
        {
            this.model = model;
        }

        //protected IGridDataKey<TModel> GetDataKeyForField(string fieldName)
        //{
        //    LambdaExpression lambdaExpression = ExpressionBuilder.Lambda<TModel>(fieldName);
        //    Type type = typeof(GridDataKey<,>);
        //    Type[] typeArray = new Type[] { typeof(TModel), lambdaExpression.Body.Type };
        //    Type type1 = type.MakeGenericType(typeArray);
        //    Type[] typeArray1 = new Type[] { lambdaExpression.GetType() };
        //    ConstructorInfo constructor = type1.GetConstructor(typeArray1);
        //    return (IGridDataKey<TModel>)constructor.Invoke(new object[] { lambdaExpression });
        //}

        /// <summary>
        /// Specify the member used to identify an unique Model instance.
        /// </summary>
        /// <param name="fieldName">The member name.</param>
        protected void Id(string fieldName)
        {
            //IGridDataKey<TModel> gridRowViewDataKey;
            //if (typeof(TModel) != typeof(DataRowView))
            //{
            //    gridRowViewDataKey = (!typeof(TModel).IsDynamicObject() ? this.GetDataKeyForField(fieldName) : (IGridDataKey<TModel>)(new GridDynamicDataKey(fieldName, ExpressionBuilder.Expression<object, object>(fieldName))));
            //}
            //else
            //{
            //    gridRowViewDataKey = (IGridDataKey<TModel>)(new GridRowViewDataKey(fieldName));
            //}
            //gridRowViewDataKey.RouteKey = gridRowViewDataKey.Name;
            //this.model.Id = gridRowViewDataKey;
        }
    }
}