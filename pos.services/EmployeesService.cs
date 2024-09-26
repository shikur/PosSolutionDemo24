using pos.data.access.Repositories;
using pos.domain.model;
using pos.services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pos.services
{
    public class EmployeesService : IEmployeesService
    {
        private readonly IRepository<Employee> _repository;

        public EmployeesService(IRepository<Employee> repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Employee>> GetAllEmployeesAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Employee> GetEmployeesByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task AddEmployeeAsync(Employee employee)
        {
            await _repository.AddAsync(employee);
        }

        public async Task UpdateEmployeeAsync(Employee employee)
        {
            await _repository.UpdateAsync(employee);
        }

        public async Task DeleteEmployeesAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}
