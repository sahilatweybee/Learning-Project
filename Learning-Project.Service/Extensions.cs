using Microsoft.Extensions.DependencyInjection;

namespace Learning_Project.Service
{
    public static partial class Extensions
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<ICourseService, CourseService>();
        }
    }
}
