using pos.domain.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pos.services.Interface
{
    public interface IRecieptService
    {
        Task<IEnumerable<Reciept>> GetAllRecieptAsync();
        Task<Employee> GetRecieptsByIdAsync(int id);
        Task AddRecieptAsync(Reciept reciept);
        Task UpdateRecieptAsync(Reciept reciept);
        Task DeleteRecieptsAsync(int id);
    }
}
