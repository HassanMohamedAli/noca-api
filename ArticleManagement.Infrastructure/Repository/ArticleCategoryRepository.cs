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
    public class ArticleCategoryRepository : IArticleCategoryRepository
    {
        private readonly ApplicationDbContext _context;

        public ArticleCategoryRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<ArticleCategory>> GetAllAsync()
        {
            return await _context.ArticleCategory
                .Where(c => !c.IsDeleted)
                .ToListAsync();
        }

        public async Task<ArticleCategory?> GetByIdAsync(int id)
        {
            return await _context.ArticleCategory
                .FirstOrDefaultAsync(c => c.Id == id && !c.IsDeleted);
        }

        public async Task AddAsync(ArticleCategory category)
        {
            await _context.ArticleCategory.AddAsync(category);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(ArticleCategory category)
        {
            _context.ArticleCategory.Update(category);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var category = await _context.ArticleCategory.FindAsync(id);
            if (category != null)
            {
                category.IsDeleted = true;

                await _context.SaveChangesAsync();
            }
        }
    }
}
