using Microsoft.Extensions.DependencyInjection;
using Sat.Recruitment.DataAccess.Repositories;
using Sat.Recruitment.DataAccess.Repositories.Concrete;

namespace Sat.Recruitment.DataAccess.Configurations.DependencyInjection.RepositoriesConfiguration
{
    public static class RepositoriesConfiguration
    {
        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();         
        }
    }
}
