using C__Project_Template.GraphQL.Queries;
using C__Project_Template.GraphQL.Schemas;
using GraphQL;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Protocols;
using Lifetime = GraphQL.DI.ServiceLifetime;

namespace C__Project_Template.GraphQL
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
            services.AddSchemas();
        }

        private static void AddQueries(this IServiceCollection services)
        {
            services.AddScoped<CoursesQuery>();
        }
        
        {
            services.AddScoped<CoursesSchema>();
        }

        {
            //app.UseGraphQL<CoursesSchema>("/graphql", opt =>
            //{
            //    opt.
            //});
            
            app.UseGraphQL<CoursesSchema>();
        }
    }
}
