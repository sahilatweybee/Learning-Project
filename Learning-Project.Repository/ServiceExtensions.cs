using Microsoft.Extensions.DependencyInjection;

namespace Learning_Project.Repository
{
    public static class ServiceExtensions
    {
        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped(typeof(IRepository<,>), typeof(Repository<,>));
        }
    }
}
