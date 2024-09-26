using pos.data.access.Repositories.Interface;
using pos.domain.model;

namespace pos.data.access.Repositories
{
    public class RecieptRepository : Repository<Reciept>, IRecieptRepository
    {
        
        private readonly ApplicationDbContext _context;
        public RecieptRepository(ApplicationDbContext context) : base(context)
        {
            this._context = context;
        }

        public IEnumerable<Reciept> GetAllReciepts()
        {
            return _context.Set<Reciept>().ToList();
        }


    }
}
