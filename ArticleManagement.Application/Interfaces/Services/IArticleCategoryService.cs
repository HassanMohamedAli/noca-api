using ArticleManagement.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArticleManagement.Application.Interfaces.Services
{
    public interface IArticleCategoryService
    {
        Task<IEnumerable<ArticleCategoryDto>> GetAllAsync();
        Task<ArticleCategoryDto?> GetByIdAsync(int id);
        Task<int> CreateAsync(ArticleCategoryDto articleCategoryDto);
        Task UpdateAsync(ArticleCategoryDto articleCategoryDto);
        Task DeleteAsync(int id);
    }

}
