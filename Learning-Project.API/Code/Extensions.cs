using Learning_Project.Data;
using Learning_Project.GraphQL;
using Learning_Project.Repository;
using Learning_Project.Service;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerUI;

namespace Learning_Project.API
{
    public static partial class Extensions
    {
        public static void AddDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddControllers(config =>
            {
                //config.Filters.Add<AuthorizationFilter>();
            });

            services.AddCors(options =>
            {
                options.AddDefaultPolicy(
                    builder =>
                    builder
                    .AllowAnyOrigin()
                     .AllowAnyMethod()
                     .AllowAnyHeader()
                     .WithExposedHeaders("Content-Disposition"));
            });

            services.AddEndpointsApiExplorer();
            services.ConfigureSwagger();

            // Add SignalR in the App
            services.AddSignalR(opt =>
            {
                opt.EnableDetailedErrors = true;
            });

            services.AddDbContext(configuration);
            services.AddRepositories();
            services.AddServices();
            services.AddGraphQL();
        }

        public static void ConfigureBuilder(this IApplicationBuilder app)
        {
            app.UseCors();
            //app.UseHttpsRedirection();

            //Add GraphQL and Configure GraphiQL UI 
            app.UseGraphQLGraphiQL("/UI/GraphQL");
            app.UseGraphQLAPIs();
        }

        #region Swagger

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

        private static void ConfigureSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(opt =>
            {
                opt.SwaggerDoc("v1", new OpenApiInfo()
                {
                    Contact = new OpenApiContact()
                    {
                        Email = "sahil.parsaniya270@gmail.com",
                        Name = "Sahil Parsaniya",
                        Url = new Uri("https://www.linkedin.com/in/sahil-parsaniya/"),
                    },
                    Description = "A Learning Project created to Learn various concepts such as Rest APIs, GraphQL, SignalR, etc.",
                    Title = "Learning-Project",
                    Version = "v1",
                });
                opt.AddSecurityDefinition(JwtBearerDefaults.AuthenticationScheme, new OpenApiSecurityScheme()
                {
                    In = ParameterLocation.Header,
                    Description = "JWT Bearer token",
                    Name = JwtBearerDefaults.AuthenticationScheme,
                    Scheme = JwtBearerDefaults.AuthenticationScheme,
                    Type = SecuritySchemeType.Http,
                });
                opt.AddSecurityRequirement(new OpenApiSecurityRequirement(){
                    {
                        new OpenApiSecurityScheme(){
                            In = ParameterLocation.Header,
                            Reference = new OpenApiReference()
                            {
                                Id = JwtBearerDefaults.AuthenticationScheme,
                                Type = ReferenceType.SecurityScheme,
                            }
                        },
                        new string[]{}
                    }
                });
            });
        } 
        
        #endregion
    }
}