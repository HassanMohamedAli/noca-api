using ArticleManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArticleManagement.Application.Interfaces.Repositories
{
    public interface IMaterialRepository
    {
        Task<List<Material>> GetAllAsync();
        Task<Material?> GetByIdAsync(int id);
        Task AddAsync(Material material);
        Task UpdateAsync(Material material);
        Task  DeleteAsync(int id);
    }

}
