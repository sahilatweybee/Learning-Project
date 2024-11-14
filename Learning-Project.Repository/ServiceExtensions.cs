using Microsoft.Extensions.DependencyInjection;

namespace Learning_Project.Repository
{
    public static partial class Extensions
    {
        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped(typeof(IRepository<,>), typeof(Repository<,>));
        }
    }
}
