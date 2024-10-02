using Learning_Project.API.Filters;

namespace Learning_Project.API.Code
{
    public static class ServiceExtensions
    {
        public static void UseFilters(this IApplicationBuilder builder)
        {
            builder.UseMiddleware<AuthorizationFilter>();
        }
    }
}
