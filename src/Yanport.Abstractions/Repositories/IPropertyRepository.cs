using System.Collections.Generic;
using System.Threading.Tasks;
using Devpro.Yanport.Abstractions.Models;

namespace Devpro.Yanport.Abstractions.Repositories
{
    public interface IPropertyRepository
    {
        Task<List<HitModel>> FindAllAsync();
    }
}
