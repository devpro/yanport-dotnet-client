using System.Net.Http;
using Devpro.Yanport.Abstractions.Repositories;
using Microsoft.Extensions.Logging;

namespace Devpro.Yanport.Client.Repositories
{
    public class PropertyRepository : RepositoryBase, IPropertyRepository
    {
        public PropertyRepository(IYanportClientConfiguration configuration, ILogger logger, IHttpClientFactory httpClientFactory)
            : base(configuration, logger, httpClientFactory)
        {
        }

        protected override string ResourceName => throw new System.NotImplementedException();
    }
}
