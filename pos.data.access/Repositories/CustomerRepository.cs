using pos.data.access.Repositories.Interface;
using pos.domain.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pos.data.access.Repositories
{
   

    public class CustomerRepository : Repository<Employee>, ICustomerRepository
    {
        private readonly ApplicationDbContext _context;
        public CustomerRepository(ApplicationDbContext context) : base(context)
        {
            this._context = context;
        }

        public IEnumerable<Customer> GetAllEmployees()
        {
            return _context.Set<Customer>().ToList();
        }

       
    }
}
