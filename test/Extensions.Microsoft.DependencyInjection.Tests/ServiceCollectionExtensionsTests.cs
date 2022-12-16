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
        public void AddModules()
        {
            var services = new ServiceCollection();
            services.AddModules(new TestModule());
            Assert.True(services.Count == 1);
        }

        [Fact]
        public void AddModule()
        {
            var services = new ServiceCollection();
            services.AddModule(new TestModule());
            Assert.True(services.Count == 1);
        }

        [Fact]
        public void AddModuleGeneric()
        {
            var services = new ServiceCollection();
            services.AddModule<TestModule>();
            Assert.True(services.Count == 1);
        }
    }
}