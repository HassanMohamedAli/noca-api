using ArticleManagement.Application.Interfaces.Repositories;
using ArticleManagement.Domain.Entities;
using ArticleManagement.Infrastructure.Persistence;
 
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArticleManagement.Infrastructure.Repository
{
    public class MaterialRepository : IMaterialRepository
    {
        private readonly ApplicationDbContext _context;

        public MaterialRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Material>> GetAllAsync()
        {
            return await _context.Materials
                .Where(m => !m.IsDeleted)
                .ToListAsync();
        }

        public async Task<Material?> GetByIdAsync(int id)
        {
            return await _context.Materials
                .FirstOrDefaultAsync(m => m.Id == id && !m.IsDeleted);
        }

        public async Task AddAsync(Material material)
        {
            await _context.Materials.AddAsync(material);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Material material)
        {
            _context.Materials.Update(material);
            await _context.SaveChangesAsync();
        }

        public async Task  DeleteAsync(int id)
        {
            var material = await _context.Materials.FindAsync(id);
            if (material != null)
            {
                material.IsDeleted = true;
                 await _context.SaveChangesAsync();
            }
        }
    }

}
