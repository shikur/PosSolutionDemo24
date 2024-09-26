using Microsoft.EntityFrameworkCore;
using pos.data.access.Repositories.Interface;
using pos.domain.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pos.data.access.Repositories
{
    
    public class EmployeeRepository : Repository<Employee>, IEmployeeRepository
    {
        private readonly ApplicationDbContext _context;
        public EmployeeRepository(ApplicationDbContext context) : base(context)
        {
            this._context = context;
        }

        public IEnumerable<Employee> GetAllEmployees()
        {
            return _context.Set<Employee>().ToList();
        }

        // You can add additional methods specific to Item here if needed
    }
}
