using Microsoft.EntityFrameworkCore;
using Shop.Core.Entities;
using Shop.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solid.Data.Repositories
{
    public class ProviderRepository : IProviderRepository
    {
        private readonly DataContext _context;
        public ProviderRepository(DataContext dataContext)
        {
            _context = dataContext;
        }
        public async Task<IEnumerable<Provider>> GetProvidersAsync()
        {
            return await _context.Providers.ToListAsync();
        }
        public Provider GetProviderById(int id)
        {
            return _context.Providers.ToList().Find(x => x.Id == id);
        }
        public async Task<Provider> AddProviderAsync(Provider provider)
        {
           _context.Providers.Add(provider);
            await  _context.SaveChangesAsync();
            return provider;
        }
        public Provider UpdateProvider(int id, Provider provider)
        {
            Provider provider1 = _context.Providers.ToList().Find(x => x.Id == id);

            if (provider1 != null)
            {
                provider1.Name = provider.Name;               
                provider1.City = provider.City;

            }
            _context.SaveChanges();
            return provider1;
        }
        public void DeleteProvider(int id)
        {
            _context.Providers.Remove(_context.Providers.ToList().Find(x => x.Id == id));
            _context.SaveChanges();
        }
    }
}
