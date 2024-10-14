using Learning_Project.GraphQL;
using Swashbuckle.AspNetCore.SwaggerUI;

namespace Learning_Project.API
{
    public static class BuilderExtensions
    {
        public static void ConfigureBuilder(this IApplicationBuilder app)
        {
            app.UseCors();
            app.UseHttpsRedirection();
            app.UseGraphQLGraphiQL("/UI/GraphQL");
            app.UseGraphQLAPIs();

            //app.UseWebSockets();
            //app.UseAuthorization();
        }

        public static void ConfigureSwagger(this IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(opt =>
                {
                    opt.DocumentTitle = "Learning-Project";
                    opt.DocExpansion(DocExpansion.None);
                    opt.EnableTryItOutByDefault();
                    opt.EnableFilter();
                });
            }
        }
    }
}