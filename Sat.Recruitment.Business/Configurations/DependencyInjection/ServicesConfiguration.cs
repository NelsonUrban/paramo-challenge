using Microsoft.Extensions.DependencyInjection;
using Sat.Recruitment.Business.Services.Abstract;
using Sat.Recruitment.Business.Services.Concrete;

namespace Sat.Recruitment.Business.Configurations.DependencyInjection
{
    public static class ServicesConfiguration
    {
        public static void AddSevices(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IMoneyService, MoneyService>();           
        }
    }
}
