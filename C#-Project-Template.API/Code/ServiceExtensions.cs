using C__Project_Template.API.Filters;

namespace C__Project_Template.API.Code
{
    public static class ServiceExtensions
    {
        public static void UseFilters(this IApplicationBuilder builder)
        {
            builder.UseMiddleware<AuthorizationFilter>();
        }
    }
}
