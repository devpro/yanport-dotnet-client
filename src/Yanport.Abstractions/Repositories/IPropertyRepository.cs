using System.Collections.Generic;
using System.Threading.Tasks;
using Devpro.Yanport.Abstractions.Models;

namespace Devpro.Yanport.Abstractions.Repositories
{
    /// <summary>
    /// Property repository.
    /// </summary>
    public interface IPropertyRepository
    {
        // TODO: add arguments in the FindAllAsync method
        // - from, size, marketingTypes, active, published, sort, surfaceMin, priceMax, propertyTypes, zipCodes, publicationDateMax, lastPriceUpdateDateMin, publicationDateMin, publicationDateMax

        /// <summary>
        /// Find all properties.
        /// </summary>
        /// <returns></returns>
        /// <remarks>First search criteria will be delivered in the next release of the Client</remarks>
        Task<List<HitModel>> FindAllAsync();
    }
}
