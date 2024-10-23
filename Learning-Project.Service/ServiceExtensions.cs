using Microsoft.Extensions.DependencyInjection;

namespace Learning_Project.Service
{
    public static class ServiceExtensions
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<ICourseService, CourseService>();
        }
    }
}
