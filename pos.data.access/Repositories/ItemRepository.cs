using pos.data.access.Repositories.Interface;
using pos.domain.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pos.data.access.Repositories
{
    public class ItemRepository : Repository<Item>, IItemRepository
    {
        private readonly ApplicationDbContext _context;
        public ItemRepository(ApplicationDbContext context) : base(context)
        {
            this._context = context;
        }

        public IEnumerable<Item> GetAllItems()
        {
            return _context.Set<Item>().ToList();
        }


    }
}
