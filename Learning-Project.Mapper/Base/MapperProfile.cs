using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Learning_Project.Mapper.Base
{
    public class MapperProfile
    {
        internal List<IMapExpression> MapperProfiles { get; set; }
        
        protected void CreateMap<TModel, TResult>() where TResult : new()
        {
            var asdf = new MapExpression<TModel, TResult>();
        }
    }
}
