using ArticleManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArticleManagement.Application.Interfaces.Repositories
{
    public interface IArticleCategoryRepository
    {
        Task<List<ArticleCategory>> GetAllAsync();
        Task<ArticleCategory?> GetByIdAsync(int id);
        Task AddAsync(ArticleCategory category);
        Task UpdateAsync(ArticleCategory category);
        Task DeleteAsync(int id);
    }
}
