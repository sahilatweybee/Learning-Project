using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Learning_Project.Core
{
    public static class Expressions
    {
        public static Expression<Func<T, object>> CreateMemberExpression<T>(string propName)
        {
            var props = typeof(T).GetProperties();
            var prop = props.FirstOrDefault(x => x.Name.Equals(propName, StringComparison.OrdinalIgnoreCase)) ?? props.FirstOrDefault();

            var param = Expression.Parameter(typeof(T), "model");
            var property = Expression.MakeMemberAccess(param, prop!);
            var conversion = Expression.Convert(property, typeof(object));
            return Expression.Lambda<Func<T, object>>(conversion, param);
        }
    }
}
