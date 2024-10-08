using Learning_Project.GraphQL.Mutations;
using Learning_Project.GraphQL.Queries;
using Learning_Project.GraphQL.Schemas;
using GraphQL;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Protocols;
using Lifetime = GraphQL.DI.ServiceLifetime;

namespace Learning_Project.GraphQL
{
    public static class Extensions
    {
        public static void AddGraphQL(this IServiceCollection services)
        {
            services.AddGraphQL(b =>
            {
                b.AddSchema<CoursesSchema>(Lifetime.Scoped);
                b.AddSystemTextJson();
            });

            services.AddQueries();
            services.AddMutations();
            services.AddSchemas();
        } 

        private static void AddQueries(this IServiceCollection services)
        {
            services.AddScoped<CourseQuery>();
        }
        
        private static void AddMutations(this IServiceCollection services)
        {
            services.AddScoped<CourseMutation>();
        }

        private static void AddSchemas(this IServiceCollection services)
        {
            services.AddScoped<CoursesSchema>();
        }
        
        public static void UseGraphQLAPIs(this IApplicationBuilder app)
        {
            app.UseGraphQL<CoursesSchema>();
        }
    }
}
