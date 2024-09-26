using pos.data.access.Repositories.Interface;
using pos.domain.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pos.data.access.Repositories
{
    
    public class TemplateReciptRepository : Repository<TemplateRecipt>, ITemplateReciptRepository
    {
        private readonly ApplicationDbContext _context;
        public TemplateReciptRepository(ApplicationDbContext context) : base(context)
        {
            this._context = context;
        }

        public IEnumerable<TemplateRecipt> GetAllTemplateRecipt()
        {
            return _context.Set<TemplateRecipt>().ToList();
        }


    }
}
