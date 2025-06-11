using ArticleManagement.Application.DTOs;
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
    public class ArticleRepository : IArticleRepository
    {
        private readonly ApplicationDbContext _context;

        public ArticleRepository(ApplicationDbContext context)
        {
            _context = context;
        }

      


        public async Task<List<Article>> GetAllAsync()
        {
            return await _context.Articles
                .Where(a => !a.IsDeleted)
                .Include(a => a.Material)
                .Include(a => a.ArticleBicycleCategories)
                    .ThenInclude(ab => ab.BicycleCategory)
                .Select(a => new Article
                {
                    Id = a.Id,
                    ArticleNumber = a.ArticleNumber,
                    ArticleName = a.ArticleName,
                    ArticleCategoryId = a.ArticleCategoryId,
                    MaterialId = a.MaterialId,
                    LengthInMm = a.LengthInMm,
                    WidthInMm = a.WidthInMm,
                    HeightInMm = a.HeightInMm,
                    NetWeightInGramm = a.NetWeightInGramm,
                    ArticleCategory = new ArticleCategory { Id = a.ArticleCategory.Id, Name = a.ArticleCategory.Name   },
                    Material = new Material
                    {
                        Id = a.Material.Id,
                        Name = a.Material.Name
                    },
                    ArticleBicycleCategories = a.ArticleBicycleCategories.Select(ab => new ArticleBicycleCategory
                    {
                       BicycleCategory = new BicycleCategory { Id = ab.BicycleCategory.Id, Name = ab.BicycleCategory.Name },
                      
                         BicycleCategoryId = ab.BicycleCategory.Id,
                    }).ToList()
                })
                .ToListAsync();
        }


        public async Task<Article?> GetByIdAsync(int id)
        {
            return await _context.Articles
                .Include(a => a.ArticleBicycleCategories)
                    .ThenInclude(ab => ab.BicycleCategory)
                .Include(a => a.Material)
                .FirstOrDefaultAsync(a => a.Id == id);
        }



        public async Task<List<Article>> FilterArticlesAsync(ArticleFilterDto articleFilterDto
   )
        {
            var query =   _context.Articles
                .Include(a => a.Material)
                .Include(a => a.ArticleCategory)
                .Include(a => a.ArticleBicycleCategories)
                    .ThenInclude(abc => abc.BicycleCategory)
                .AsQueryable();

            if (articleFilterDto.ArticleCategoryId>0 )
            {
                query = query.Where(a => a.ArticleCategoryId == articleFilterDto.ArticleCategoryId.Value);
            }

            if (articleFilterDto.MaterialId>0)
            {
                query = query.Where(a => a.MaterialId == articleFilterDto.MaterialId.Value);
            }

            if ( (articleFilterDto.BicycleCategoryIds != null  ) && articleFilterDto.BicycleCategoryIds.Any())
            {
                query = query.Where(a =>
                    a.ArticleBicycleCategories.Any(abc => articleFilterDto.BicycleCategoryIds.Contains(abc.BicycleCategoryId)));
            }

            return await query.ToListAsync();
        }


        public async Task AddAsync(Article article)
        {
            await _context.Articles.AddAsync(article);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Article article)
        {
            _context.Articles.Update(article);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var article = await _context.Articles.FindAsync(id);
            if (article != null)
            {
                article.IsDeleted = true;
              
                await _context.SaveChangesAsync();
            }
        }


        public async Task<bool> ExistsAsync(int id)
        {
            return await _context.Articles.AnyAsync(a => a.Id == id);
        }
    }
}
