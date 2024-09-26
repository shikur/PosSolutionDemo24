using pos.data.access.Repositories.Interface;
using pos.domain.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pos.data.access.Repositories
{
    
    public class MenuRepository : Repository<Menu>, IMenuRepository
    {
       
        private readonly ApplicationDbContext _context;
        public MenuRepository(ApplicationDbContext context) : base(context)
        {
            this._context = context;
        }

        public IEnumerable<Menu> GetAllMenus()
        {
            return _context.Set<Menu>().ToList();
        }


    }
}
