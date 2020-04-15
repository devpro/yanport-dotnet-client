using System.Net.Http;
using System.Threading.Tasks;
using Devpro.Yanport.Abstractions.Repositories;
using Devpro.Yanport.Client.Repositories;
using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Xunit;

namespace Devpro.Yanport.Client.IntegrationTests.Sandbox
{
    [Trait("Environment", "Sandbox")]
    public class PropertyRepositorySandboxIntegrationTest : RepositoryIntegrationTestBase<SandboxYanportClientConfiguration>
    {
        public PropertyRepositorySandboxIntegrationTest()
            : base(new SandboxYanportClientConfiguration())
        {
        }

        [Fact]
        public async Task PropertyRepositorySandboxFindAllAsync_ReturnToken()
        {
            // Arrange
            var repository = BuildRepository();

            // Act
            var output = await repository.FindAllAsync("?from=0&size=100&marketingTypes=SALE&active=true&published=true");

            // Assert
            output.Should().NotBeNull();
            output.Should().NotBeEmpty();
        }

        private IPropertyRepository BuildRepository()
        {
            var logger = ServiceProvider.GetService<ILogger<PropertyRepository>>();
            var httpClientFactory = ServiceProvider.GetService<IHttpClientFactory>();

            return new PropertyRepository(Configuration, logger, httpClientFactory);
        }
    }
}
