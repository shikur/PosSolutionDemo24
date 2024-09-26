using pos.data.access.Repositories;
using pos.domain.model;
using pos.services.Interface;

namespace pos.services
{
    public class CustomerService: ICustomerService
    {
        private readonly IRepository<Customer> _repository;

        public CustomerService(IRepository<Customer> repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Customer>> GetAllCustomersAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Customer> GetCustomersByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task AddCustomerAsync(Customer customer)
        {
            await _repository.AddAsync(customer);
        }

        public async Task UpdateCustomerAsync(Customer customer)
        {
            await _repository.UpdateAsync(customer);
        }

        public async Task DeleteCustomersAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }
               
    }
}
