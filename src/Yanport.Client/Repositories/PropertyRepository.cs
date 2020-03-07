using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Devpro.Yanport.Abstractions.Models;
using Devpro.Yanport.Abstractions.Repositories;
using Microsoft.Extensions.Logging;

namespace Devpro.Yanport.Client.Repositories
{
    public class PropertyRepository : RepositoryBase, IPropertyRepository
    {
        public PropertyRepository(IYanportClientConfiguration configuration, ILogger<PropertyRepository> logger, IHttpClientFactory httpClientFactory)
            : base(configuration, logger, httpClientFactory)
        {
        }

        protected override string ResourceName => "properties";

        public async Task<List<HitModel>> FindAllAsync()
        {
            var url = GenerateUrl();
            var output = await GetAsync<ResultModel>(url);
            return output.Hits;
        }
    }
}
