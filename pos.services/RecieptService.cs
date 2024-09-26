using pos.data.access.Repositories;
using pos.domain.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pos.services
{
    public class RecieptService
    {
        private readonly IRepository<Reciept> _repository;

        public RecieptService(IRepository<Reciept> repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Reciept>> GetAllRecieptAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Reciept> GetRecieptByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task AddRecieptAsync(Reciept reciept)
        {
            await _repository.AddAsync(reciept);
        }

        public async Task UpdateRecieptAsync(Reciept reciept)
        {
            await _repository.UpdateAsync(reciept);
        }

        public async Task DeleteRecieptAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}
