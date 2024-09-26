using pos.data.access.Repositories;
using pos.domain.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pos.services
{
    public class MenuService
    {
        private readonly IRepository<Menu> _repository;

        public MenuService(IRepository<Menu> repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Menu>> GetAllMenusAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Menu> GetMenusByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task AddMenuAsync(Menu menu)
        {
            await _repository.AddAsync(menu);
        }

        public async Task UpdateMenuAsync(Menu menu)
        {
            await _repository.UpdateAsync(menu);
        }

        public async Task DeleteMenusAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}
