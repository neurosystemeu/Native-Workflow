using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace NeuroSystem.Workflow.UserData.UI.Html.Version2.Builders
{
    /// <summary>
    /// Defines the fluent interface for configuring filter.
    /// </summary>    
    public class DataSourceFilterDescriptorFactory<TModel> : DataSourceFilterDescriptorFactoryBase
    where TModel : class
    {
        public DataSourceFilterDescriptorFactory(IList<IFilterDescriptor> filters) : base(filters)
        {
        }

        ///// <summary>
        ///// Specifies the member on which the filter should be applied.
        ///// </summary>
        ///// <param name="expression">Member access expression which describes the member</param>        
        //public virtual DataSourceFilterEqualityDescriptorBuilder<bool> Add(Expression<Func<TModel, bool>> expression)
        //{
        //    return new DataSourceFilterEqualityDescriptorBuilder<bool>(this.CreateFilter<bool>(expression));
        //}

        ///// <summary>
        ///// Specifies the member on which the filter should be applied.
        ///// </summary>
        ///// <param name="expression">Member access expression which describes the member</param>
        //public virtual DataSourceFilterEqualityDescriptorBuilder<bool?> Add(Expression<Func<TModel, bool?>> expression)
        //{
        //    return new DataSourceFilterEqualityDescriptorBuilder<bool?>(this.CreateFilter<bool?>(expression));
        //}

        ///// <summary>
        ///// Specifies the member on which the filter should be applied.
        ///// </summary>
        ///// <typeparam name="TValue">Member type</typeparam>
        ///// <param name="expression">Member access expression which describes the member</param>        
        //public virtual DataSourceFilterComparisonDescriptorBuilder<TValue> Add<TValue>(Expression<Func<TModel, TValue>> expression)
        //{
        //    return new DataSourceFilterComparisonDescriptorBuilder<TValue>(this.CreateFilter<TValue>(expression));
        //}

        ///// <summary>
        ///// Specifies the member on which the filter should be applied.
        ///// </summary>
        ///// <param name="expression">Member access expression which describes the member</param>
        //public virtual DataSourceFilterStringDescriptorBuilder Add(Expression<Func<TModel, string>> expression)
        //{
        //    return new DataSourceFilterStringDescriptorBuilder(this.CreateFilter<string>(expression));
        //}

        //protected virtual CompositeFilterDescriptor CreateFilter<TValue>(Expression<Func<TModel, TValue>> expression)
        //{
        //    CompositeFilterDescriptor compositeFilterDescriptor = new CompositeFilterDescriptor()
        //    {
        //        LogicalOperator = FilterCompositionLogicalOperator.And
        //    };
        //    FilterDescriptor filterDescriptor = new FilterDescriptor()
        //    {
        //        Member = expression.MemberWithoutInstance()
        //    };
        //    compositeFilterDescriptor.FilterDescriptors.Add(filterDescriptor);
        //    base.Filters.Add(compositeFilterDescriptor);
        //    return compositeFilterDescriptor;
        //}

        
    }
}