using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NeuroSystem.Workflow.UserData.UI.Html.Mvc
{
    public static class ExpressionBuilder
    {
        //public static Expression<Func<TModel, TValue>> Expression<TModel, TValue>(string memberName)
        //{
        //    return (Expression<Func<TModel, TValue>>)ExpressionBuilder.Lambda<TModel>(memberName);
        //}

        //public static Expression<Func<T, bool>> Expression<T>(IList<IFilterDescriptor> filterDescriptors)
        //{
        //    return ExpressionBuilder.Expression<T>(filterDescriptors, true);
        //}

        //public static Expression<Func<T, bool>> Expression<T>(IList<IFilterDescriptor> filterDescriptors, bool checkForNull)
        //{
        //    ParameterExpression parameterExpression = System.Linq.Expressions.Expression.Parameter(typeof(T), "item");
        //    FilterDescriptorCollectionExpressionBuilder filterDescriptorCollectionExpressionBuilder = new FilterDescriptorCollectionExpressionBuilder(parameterExpression, filterDescriptors);
        //    filterDescriptorCollectionExpressionBuilder.Options.LiftMemberAccessToNull = checkForNull;
        //    return (Expression<Func<T, bool>>)filterDescriptorCollectionExpressionBuilder.CreateFilterExpression();
        //}

        //public static LambdaExpression Lambda<T>(string memberName)
        //{
        //    return ExpressionBuilder.Lambda<T>(memberName, false);
        //}

        //public static LambdaExpression Lambda<T>(Type memberType, string memberName, bool checkForNull)
        //{
        //    MemberAccessExpressionBuilderBase memberAccessExpressionBuilderBase = ExpressionBuilderFactory.MemberAccess(typeof(T), memberType, memberName, checkForNull);
        //    return memberAccessExpressionBuilderBase.CreateLambdaExpression();
        //}

        //public static LambdaExpression Lambda<T>(string memberName, bool checkForNull)
        //{
        //    return ExpressionBuilderFactory.MemberAccess(typeof(T), memberName, checkForNull).CreateLambdaExpression();
        //}
    }
}