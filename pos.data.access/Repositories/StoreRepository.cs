using pos.data.access.Repositories.Interface;
using pos.domain.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pos.data.access.Repositories
{
   
    public class StoreRepository : Repository<Store>, IStoreRepository
    {
        
        private readonly ApplicationDbContext _context;
        public StoreRepository(ApplicationDbContext context) : base(context)
        {
            this._context = context;
        }

        public IEnumerable<Store> GetAllStores()
        {
            return _context.Set<Store>().ToList();
        }

    }
}
