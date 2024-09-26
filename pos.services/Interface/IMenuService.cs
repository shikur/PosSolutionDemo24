using pos.domain.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pos.services.Interface
{
    public interface IMenuService
    {
        Task<IEnumerable<Menu>> GetAllMenusAsync();
        Task<Menu> GetMenusByIdAsync(int id);
        Task AddProductAsync(Menu menu);
        Task UpdateMenutAsync(Menu menu);
        Task DeleteMenusAsync(int id);
    }
}
