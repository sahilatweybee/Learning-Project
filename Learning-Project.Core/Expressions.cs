using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace Learning_Project.Core
{
    public static class Expressions
    {

        private static Expression<Func<TEntity, TProp>> MakeMemberExpression<TEntity, TProp>(PropertyInfo prop)
            where TEntity : class
        {
            var param = Expression.Parameter(typeof(TEntity), "model");
            var property = Expression.MakeMemberAccess(param, prop!);
            var conversion = Expression.Convert(property, prop.PropertyType);
            return Expression.Lambda<Func<TEntity, TProp>>(conversion, param);
        }

        public static Expression<Func<TEntity, object>> CreateMemberExpression<TEntity>(string propName)
            where TEntity : class
        {
            var props = typeof(TEntity).GetProperties();
            var prop = props.FirstOrDefault(x => x.Name.Equals(propName, StringComparison.OrdinalIgnoreCase)) ?? props.FirstOrDefault();

            var expr = typeof(Core.Expressions).GetMethod("MakeMemberExpression")!
                                  .MakeGenericMethod(typeof(TEntity), prop.PropertyType)
                                  .Invoke(null, new object[] { prop });

            return (Expression<Func<TEntity, object>>)Convert.ChangeType(expr, typeof(Expression<Func<TEntity, object>>))!;
        }
    }
}
