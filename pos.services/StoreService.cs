using pos.data.access.Repositories;
using pos.domain.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using pos.domain.model;

namespace pos.services
{
    public class StoreService
    {
        private readonly IRepository<Store> _repository;

        public StoreService(IRepository<Store> repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Store>> GetAllStoresAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Store> GetStoreByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task AddStoreAsync(Store store)
        {
            await _repository.AddAsync(store);
        }

        public async Task UpdateStoreAsync(Store store)
        {
            await _repository.UpdateAsync(store);
        }

        public async Task DeleteStoreAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}
