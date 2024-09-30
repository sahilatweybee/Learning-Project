using C__Project_Template.GraphQL.Queries;
using C__Project_Template.GraphQL.Schemas;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace C__Project_Template.GraphQL
{
    public static class Extensions
    {
        public static void AddQueries(this IServiceCollection services)
        {
            services.AddScoped<CoursesQuery>();
        }
        
        public static void AddSchemas(this IServiceCollection services)
        {
            services.AddScoped<CoursesSchema>();
        }

        public static void UseSchemas(this IApplicationBuilder app)
        {
            app.UseGraphQL<CoursesSchema>();
        }
    }
}
