using System.Net.Http;
using Devpro.Yanport.Client.UnitTests.Fakes;
using Microsoft.Extensions.DependencyInjection;
using Moq;

namespace Devpro.Yanport.Client.UnitTests.Repositories
{
    public abstract class RepositoryTestBase
    {
        protected RepositoryTestBase()
        {
            var services = new ServiceCollection()
                .AddLogging();
            ServiceProvider = services.BuildServiceProvider();
            Configuration = new FakeConfiguration();
            HttpMessageHandlerMock = new Mock<FakeHttpMessageHandler> { CallBase = true };
        }

        protected ServiceProvider ServiceProvider { get; private set; }

        protected IYanportClientConfiguration Configuration { get; private set; }

        protected Mock<FakeHttpMessageHandler> HttpMessageHandlerMock { get; private set; }

        protected virtual Mock<IHttpClientFactory> BuildHttpClientFactory(HttpResponseMessage httpResponseMessage, HttpMethod httpMethod, string absoluteUri)
        {
            HttpMessageHandlerMock.Setup(f => f.Send(It.Is<HttpRequestMessage>(m =>
                    m.Method == httpMethod
                    && m.RequestUri.AbsoluteUri == absoluteUri)))
                .Returns(httpResponseMessage);

            var httpClient = new HttpClient(HttpMessageHandlerMock.Object);

            var httpClientFactoryMock = new Mock<IHttpClientFactory>();
            httpClientFactoryMock.Setup(x => x.CreateClient(Configuration.HttpClientName))
                .Returns(httpClient);

            return httpClientFactoryMock;
        }
    }
}
