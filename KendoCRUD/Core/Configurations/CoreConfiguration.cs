
using Core.ApplicationCore.UnitOfWork;
using Microsoft.Extensions.DependencyInjection;

namespace KendoCRUD.Core.Configurations
{
    public static class CoreConfiguration
    {
        public static IServiceCollection ConfigureCoreModules(this IServiceCollection services)
        {
           
            services.AddScoped(typeof(IUnitOfWork<>), typeof(UnitOfWork<>));

            return services;
        }
    }
}
