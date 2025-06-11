using ArticleManagement.Application.DTOs;
using ArticleManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArticleManagement.Application.Interfaces.Services
{
    public interface IArticleService
    {
        Task<int> CreateAsync(ArticleDto request);
        Task UpdateAsync(ArticleDto request);
        Task DeleteAsync(int id);
        Task<IEnumerable<ArticleDto>> GetAllAsync();
        Task<IEnumerable<ArticleDto>> FilterArticlesAsync(ArticleFilterDto articleFilterDto);

        Task<ArticleDto?> GetByIdAsync(int id);
    }

  
}
