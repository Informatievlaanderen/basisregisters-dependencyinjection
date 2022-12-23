using System;
using Microsoft.Extensions.DependencyInjection;

namespace Be.Vlaanderen.Basisregisters.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection RegisterModules(this IServiceCollection services, params IServiceCollectionModule[] modules)
        {
            ArgumentNullException.ThrowIfNull(services);

            foreach (var module in modules)
            {
                module.Load(services);
            }

            return services;
        }

        public static IServiceCollection RegisterModule(this IServiceCollection services, IServiceCollectionModule module)
        {
            ArgumentNullException.ThrowIfNull(services);

            module.Load(services);
            return services;
        }

        public static IServiceCollection RegisterModule<TModule>(this IServiceCollection services)
            where TModule : IServiceCollectionModule, new()
        {
            ArgumentNullException.ThrowIfNull(services);

            return services.RegisterModule(new TModule());
        }
    }
}
