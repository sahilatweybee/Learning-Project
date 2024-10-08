using Learning_Project.API.Filters;
using Learning_Project.Data;
using Learning_Project.GraphQL;
using Learning_Project.Repository;
using Learning_Project.Service;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.OpenApi.Models;

namespace Learning_Project.API
{
    public static class ServiceExtensions
    {
        public static void AddDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddControllers(config =>
            {
                //config.Filters.Add<AuthorizationFilter>();
            });

            services.AddCors();

            services.AddEndpointsApiExplorer();
            services.ConfigureSwagger();

            services.AddSignalRServices();

            services.AddDbContext(configuration);
            services.AddRepositories();
            services.AddServices();
            services.AddGraphQL();
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

        private static void AddSignalRServices(this IServiceCollection services)
        {
            services.AddSignalR(opt =>
            {
                opt.EnableDetailedErrors = true;
            });
        }
    }
}
