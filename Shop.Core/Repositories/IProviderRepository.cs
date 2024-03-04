using Shop.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Core.Repositories
{
    public interface IProviderRepository
    {
        Task<IEnumerable<Provider>> GetProvidersAsync();
        Provider GetProviderById(int id);
        Task<Provider> AddProviderAsync(Provider provider);
        Provider UpdateProvider(int id, Provider provider);
        void DeleteProvider(int id);
    }
}
