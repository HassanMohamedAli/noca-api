using ArticleManagement.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArticleManagement.Application.Interfaces.Services
{
    public interface IMaterialService
    {
        Task<IEnumerable<MaterialDto>> GetAllAsync();
        Task<MaterialDto?> GetByIdAsync(int id);
        Task<int> CreateAsync(MaterialDto materialDto);
        Task UpdateAsync(MaterialDto materialDto);
        Task DeleteAsync(int id);
    }

}
