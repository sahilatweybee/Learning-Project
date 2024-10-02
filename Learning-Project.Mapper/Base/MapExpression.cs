using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Learning_Project.Mapper.Base
{
    public interface IMapExpression
    {
        void ReverseMap();
    }

    public class MapExpression<TModel, TResult> : IMapExpression where TResult : new()
    {
        private Type sourceType = typeof(TModel);
        private Type resultType = typeof(TResult);

        Expression<Func<TModel, TResult>> resultExpression = null;
        Expression<Func<TResult, TModel>> reverseResultExpression = null;

        public MapExpression()
        {
            var sourceExpression = Expression.Parameter(sourceType, "input");
            IEnumerable<MemberExpression>? sourceProps = sourceType.GetMembers().Select(x => Expression.MakeMemberAccess(sourceExpression, x));
        }

        public void ReverseMap()
        {
        }
    }
}
