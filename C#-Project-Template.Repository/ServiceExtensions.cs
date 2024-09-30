using Microsoft.Extensions.DependencyInjection;

namespace C__Project_Template.Repository
{
    public static class ServiceExtensions
    {
        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped(typeof(IRepository<,>), typeof(Repository<,>));
        }
    }
}
