using Microsoft.Extensions.DependencyInjection;

namespace Be.Vlaanderen.Basisregisters.DependencyInjection
{
    public interface IServiceCollectionModule
    {
        void Load(IServiceCollection services);
    }
}
