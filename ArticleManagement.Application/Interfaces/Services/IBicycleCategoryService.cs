using ArticleManagement.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArticleManagement.Application.Interfaces.Services
{
    public interface IBicycleCategoryService
    {
        Task<IEnumerable<BicycleCategoryDto>> GetAllAsync();
        Task<BicycleCategoryDto?> GetByIdAsync(int id);
        Task<int> CreateAsync(BicycleCategoryDto categoryDto);
        Task UpdateAsync(BicycleCategoryDto categoryDto);
        Task DeleteAsync(int id);
    }
}
