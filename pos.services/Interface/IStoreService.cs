using pos.domain.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pos.services.Interface
{
    public interface IStoreService
    {
        Task<IEnumerable<Store>> GetAllStoresAsync();
        Task<Employee> GetStoresByIdAsync(int id);
        Task AddProductAsync(Store store);
        Task UpdateStoreAsync(Store store);
        Task DeleteStoresAsync(int id);
    }
}
