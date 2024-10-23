using System.Linq.Expressions;

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
