using pos.data.access.Repositories;
using pos.domain.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pos.services
{
    public class TemplateReciptService
    {
        private readonly IRepository<TemplateRecipt> _repository;

        public TemplateReciptService(IRepository<TemplateRecipt> repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<TemplateRecipt>> GetAllTemplateReciptsAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<TemplateRecipt> GetTemplateReciptByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task AddTemplateReciptAsync(TemplateRecipt templateRecipt)
        {
            await _repository.AddAsync(templateRecipt);
        }

        public async Task UpdateTemplateReciptAsync(TemplateRecipt templateRecipt)
        {
            await _repository.UpdateAsync(templateRecipt);
        }

        public async Task DeleteTemplateReciptAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}
