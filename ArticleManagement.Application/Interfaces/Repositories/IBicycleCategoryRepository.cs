using ArticleManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArticleManagement.Application.Interfaces.Repositories
{
    public interface IBicycleCategoryRepository
    {
        Task<List<BicycleCategory>> GetAllAsync();
        Task<BicycleCategory?> GetByIdAsync(int id);
        Task AddAsync(BicycleCategory category);
        Task UpdateAsync(BicycleCategory category);
        Task  DeleteAsync(int id);
    }

}
