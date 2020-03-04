using System;
using System.Net.Http;
using System.Threading.Tasks;
using Devpro.Yanport.Abstractions.Exceptions;
using Microsoft.Extensions.Logging;
using Withywoods.Serialization.Json;

namespace Devpro.Yanport.Client.Repositories
{
    public abstract class RepositoryBase
    {
        protected RepositoryBase(IYanportClientConfiguration configuration, ILogger logger, IHttpClientFactory httpClientFactory)
        {
            Configuration = configuration;
            Logger = logger;
            HttpClientFactory = httpClientFactory;
        }

        protected IYanportClientConfiguration Configuration { get; private set; }

        protected ILogger Logger { get; private set; }

        protected IHttpClientFactory HttpClientFactory { get; private set; }

        protected abstract string ResourceName { get; }

        protected string GenerateUrl(string prefix = "", string suffix = "", string arguments = "")
        {
            return $"{Configuration.BaseUrl}{prefix}/{ResourceName}{suffix}{arguments}";
        }

        protected virtual async Task<T> GetAsync<T>(string url) where T : class
        {
            var client = HttpClientFactory.CreateClient(Configuration.ClientName);

            var response = await client.GetAsync(url);

            var stringResult = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                Logger.LogDebug($"Status code doesn't indicate success [HttpRequestUrl={url}] [HttpResponseStatusCode={response.StatusCode}] [HttpResponseContent={stringResult ?? ""}]");
                response.EnsureSuccessStatusCode();
            }

            if (string.IsNullOrEmpty(stringResult))
            {
                throw new ConnectivityException($"Empty response received while calling {url}");
            }

            try
            {
                return stringResult.FromJson<T>();
            }
            catch (Exception exc)
            {
                Logger.LogWarning($"Cannot deserialize GET call response content [HttpRequestUrl={url}] [HttpResponseContent={stringResult}] [SerializationType={typeof(T).ToString()}] [ExceptionMessage={exc.Message}]");
                Logger.LogDebug($"[Stacktrace={exc.StackTrace}]");
                throw new ConnectivityException($"Invalid data received when calling \"{url}\". {exc.Message}.", exc);
            }
        }
    }
}
