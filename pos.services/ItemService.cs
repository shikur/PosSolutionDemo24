using pos.data.access.Repositories;
using pos.domain.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using pos.domain.model;
using pos.services.Interface;

namespace pos.services
{
    public class ItemService: IItemService
    {
        private readonly IRepository<Item> _repository;

        public ItemService(IRepository<Item> repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Item>> GetAllItemsAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Item> GetItemByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task AddItemAsync(Item item)
        {
            await _repository.AddAsync(item);
        }

        public async Task UpdateItemAsync(Item item)
        {
            await _repository.UpdateAsync(item);
        }

        public async Task DeleteItemsAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }

       

      
    }
}
