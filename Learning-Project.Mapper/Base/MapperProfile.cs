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
