using System.Net.Http;
using Devpro.Yanport.Client.DependencyInjection;
using Devpro.Yanport.Client.UnitTests.Fakes;
using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace Devpro.Yanport.Client.UnitTests.DependencyInjection
{
    [Trait("Category", "UnitTests")]
    public class ServiceCollectionExtensionsTest
    {
        [Fact]
        public void AddYanportClient_ShouldProvideRepositories()
        {
            // Arrange
            var serviceCollection = new ServiceCollection()
                .AddLogging();
            var configuration = new FakeConfiguration();

            // Act
            serviceCollection.AddYanportClient(configuration);

            // Assert
            var services = serviceCollection.BuildServiceProvider();
            services.GetRequiredService<Abstractions.Repositories.IPropertyRepository>().Should().NotBeNull();
        }

        [Fact]
        public void AddYanportClient_ShouldProvideHttpClient()
        {
            // Arrange
            var serviceCollection = new ServiceCollection()
                .AddLogging();
            var configuration = new FakeConfiguration();

            // Act
            serviceCollection.AddYanportClient(configuration);

            // Assert
            var services = serviceCollection.BuildServiceProvider();
            var httpClientFactory = services.GetRequiredService<IHttpClientFactory>();
            httpClientFactory.Should().NotBeNull();
            var client = httpClientFactory.CreateClient(configuration.HttpClientName);
            client.Should().NotBeNull();
        }
    }
}
