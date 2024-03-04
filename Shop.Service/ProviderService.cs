using Shop.Core.Entities;
using Shop.Core.Repositories;
using Shop.Core.Service;
using Solid.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Service
{
    public class ProviderService : IProviderService
    {
        private readonly IProviderRepository _providerRepository;
        public ProviderService(IProviderRepository providerRepository)
        {
            _providerRepository = providerRepository;
        }
        public async Task<IEnumerable<Provider>> GetProvidersAsync()
        {
            return await _providerRepository.GetProvidersAsync();
        }
        public Provider GetProviderById(int id)
        {
            return _providerRepository.GetProviderById(id);
        }
        public async Task<Provider> AddProviderAsync(Provider provider)
        {
            return await _providerRepository.AddProviderAsync(provider);
        }
        public Provider UpdateProvider(int id, Provider provider)
        {
            return _providerRepository.UpdateProvider(id, provider);

        }
        public void DeleteProvider(int id)
        {
            _providerRepository.DeleteProvider(id);
        }

     
    }
}
