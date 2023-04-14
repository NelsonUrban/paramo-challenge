using Microsoft.Extensions.DependencyInjection;
using Sat.Recruitment.Custom.Services.Abstract;
using Sat.Recruitment.Custom.Services.Concrete;

namespace Sat.Recruitment.Custom.Configurations.DependencyInjection
{
    public static class CustomConfiguration
    {
        public static void AddCustomSevices(this IServiceCollection services)
        {
            services.AddScoped<IFileService, FileService>();
        }
    }
}
