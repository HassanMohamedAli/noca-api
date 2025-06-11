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
    public class BicycleCategoryRepository : IBicycleCategoryRepository
    {
        private readonly ApplicationDbContext _context;

        public BicycleCategoryRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<BicycleCategory>> GetAllAsync()
        {
            return await _context.BicycleCategories
                .Where(c => !c.IsDeleted)
                .ToListAsync();
        }

        public async Task<BicycleCategory?> GetByIdAsync(int id)
        {
            return await _context.BicycleCategories
                .FirstOrDefaultAsync(c => c.Id == id && !c.IsDeleted);
        }

        public async Task AddAsync(BicycleCategory category)
        {
            await _context.BicycleCategories.AddAsync(category);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(BicycleCategory category)
        {
            _context.BicycleCategories.Update(category);
            await _context.SaveChangesAsync();
        }

        public async Task  DeleteAsync(int id)
        {
            var category = await _context.BicycleCategories.FindAsync(id);
            if (category != null)
            {
                category.IsDeleted = true;
              
                await _context.SaveChangesAsync();
            }
        }
    }
}
