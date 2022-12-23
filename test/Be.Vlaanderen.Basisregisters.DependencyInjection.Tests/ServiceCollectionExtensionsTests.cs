using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace Be.Vlaanderen.Basisregisters.DependencyInjection.Tests
{
    public class ServiceCollectionExtensionsTests
    {
        private class TestModule : IServiceCollectionModule
        {
            public void Load(IServiceCollection services)
            {
                services.AddSingleton<TestModule>();
            }
        }

        [Fact]
        public void RegisterModules()
        {
            var services = new ServiceCollection();
            services.RegisterModules(new TestModule());
            Assert.True(services.Count == 1);
        }

        [Fact]
        public void RegisterModule()
        {
            var services = new ServiceCollection();
            services.RegisterModule(new TestModule());
            Assert.True(services.Count == 1);
        }

        [Fact]
        public void RegisterModuleGeneric()
        {
            var services = new ServiceCollection();
            services.RegisterModule<TestModule>();
            Assert.True(services.Count == 1);
        }
    }
}