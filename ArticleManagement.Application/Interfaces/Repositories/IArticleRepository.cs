using ArticleManagement.Application.DTOs;
using ArticleManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArticleManagement.Application.Interfaces.Repositories
{
    public interface IArticleRepository
    {
        Task<List<Article>> GetAllAsync();
        Task<List<Article>> FilterArticlesAsync(ArticleFilterDto articleFilterDto);

        
        Task<Article?> GetByIdAsync(int id);
        Task AddAsync(Article article);
        Task UpdateAsync(Article article);
        Task DeleteAsync(int id);
        Task<bool> ExistsAsync(int id);
    }
}
