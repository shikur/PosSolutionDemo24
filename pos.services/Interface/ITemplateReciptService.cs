using pos.domain.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pos.services.Interface
{
    public interface ITemplateReciptService
    {
        Task<IEnumerable<TemplateRecipt>> GetAllTemplateReciptsAsync();
        Task<TemplateRecipt> GetTemplateReciptByIdAsync(int id);
        Task AddProductAsync(TemplateRecipt templateRecipt);
        Task UpdateTemplateReciptAsync(TemplateRecipt templateRecipt);
        Task DeleteTemplateReciptsAsync(int id);
    }
}
