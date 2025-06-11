using ArticleManagement.Application.DTOs;
using ArticleManagement.Application.Interfaces.Services;
using ArticleManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ArticleManagement.Application.Interfaces.Repositories;


namespace ArticleManagement.Application.Interfaces.Implementations
{
    public class ArticleService : IArticleService
    {
        private readonly IArticleRepository _repository;
        private readonly IMapper _mapper;

        public ArticleService(IArticleRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<int> CreateAsync(ArticleDto request)
        {
            var entity = _mapper.Map<Article>(request);
            entity.ArticleBicycleCategories = request.BicycleCategoryIds
    .Select(id => new ArticleBicycleCategory
    {
        BicycleCategoryId = id
    }).ToList();

            await _repository.AddAsync(entity);
            return entity.Id;
        }

        public async Task UpdateAsync(ArticleDto request)
        {
          var entity=  await _repository.GetByIdAsync(request.ArticleId);
            entity.ArticleBicycleCategories.Clear();


            entity.MaterialId = request.MaterialId;
            entity.ArticleCategoryId = request.ArticleCategoryId;
            entity.ArticleName = request.ArticleName;
            entity.ArticleNumber = request.ArticleNumber;
            entity.WidthInMm = request.WidthInMm;
            entity.HeightInMm = request.HeightInMm;
            entity.LengthInMm = request.LengthInMm;
            entity.NetWeightInGramm = request.NetWeightInGramm;
            entity.UpdatedOn = request.UpdatedOn;   
            entity.UpdatedBy    = request.UpdatedBy;    

      
           

 
             entity.ArticleBicycleCategories = request.BicycleCategoryIds
  .Select(id => new ArticleBicycleCategory
  {
      BicycleCategoryId = id
  }).ToList();

            

            await _repository.UpdateAsync(entity);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }

        public async Task<IEnumerable<ArticleDto>> GetAllAsync()
        {
            var articles = await _repository.GetAllAsync();

            var lst = articles.Select(a =>
                new ArticleDto
                {
                    ArticleId = a.Id,
                    ArticleNumber = a.ArticleNumber,
                    ArticleName = a.ArticleName,
                    ArticleCategoryId = a.ArticleCategoryId,
                    MaterialId = a.MaterialId,
                    LengthInMm = a.LengthInMm,
                    WidthInMm = a.WidthInMm,
                    HeightInMm = a.HeightInMm,
                    NetWeightInGramm = a.NetWeightInGramm,
                    ArticleCategory = new ArticleCategoryDto { Id = a.ArticleCategory.Id, Name = a.ArticleCategory.Name },
                    Material = new MaterialDto
                    {
                        Id = a.Material.Id,
                        Name = a.Material.Name
                    },
                    ArticleBicycleCategories = a.ArticleBicycleCategories.Select(ab => new BicycleCategoryDto
                    {
                        Id = ab.BicycleCategory.Id,
                        Name = ab.BicycleCategory.Name
                    }).ToList()
                }).ToList();

            return lst;

        }

        public async Task<ArticleDto?> GetByIdAsync(int id)
        {
            var article = await _repository.GetByIdAsync(id);

            var articleDto =
              new ArticleDto
              {
                  ArticleId = article.Id,
                  ArticleNumber = article.ArticleNumber,
                  ArticleName = article.ArticleName,
                  ArticleCategoryId = article.ArticleCategoryId,
                  MaterialId = article.MaterialId,
                  LengthInMm = article.LengthInMm,
                  WidthInMm = article.WidthInMm,
                  HeightInMm = article.HeightInMm,
                  NetWeightInGramm = article.NetWeightInGramm,
                 BicycleCategoryIds= article
            .ArticleBicycleCategories.Select(ab => ab.BicycleCategoryId).ToList()           ,
                  Material = new MaterialDto
                  {
                      Id = article.Material.Id,
                      Name = article.Material.Name
                  },
                  ArticleBicycleCategories = article.ArticleBicycleCategories.Select(ab => new BicycleCategoryDto
                  {
                      Id = ab.BicycleCategory.Id,
                      Name = ab.BicycleCategory.Name
                  }).ToList()
              } ;


            return articleDto;
        }

        public async Task<IEnumerable<ArticleDto>> FilterArticlesAsync(ArticleFilterDto articleFilterDto)
        {
            var articles =  await  _repository.FilterArticlesAsync(articleFilterDto);

            var lst = articles.Select(a =>
                new ArticleDto
                {
                    ArticleId = a.Id,
                    ArticleNumber = a.ArticleNumber,
                    ArticleName = a.ArticleName,
                    ArticleCategoryId = a.ArticleCategoryId,
                    MaterialId = a.MaterialId,
                    LengthInMm = a.LengthInMm,
                    WidthInMm = a.WidthInMm,
                    HeightInMm = a.HeightInMm,
                    NetWeightInGramm = a.NetWeightInGramm,
                    ArticleCategory = new ArticleCategoryDto { Id = a.ArticleCategory.Id, Name = a.ArticleCategory.Name },
                    Material = new MaterialDto
                    {
                        Id = a.Material.Id,
                        Name = a.Material.Name
                    },
                    ArticleBicycleCategories = a.ArticleBicycleCategories.Select(ab => new BicycleCategoryDto
                    {
                        Id = ab.BicycleCategory.Id,
                        Name = ab.BicycleCategory.Name
                    }).ToList()
                }).ToList();

            return lst;
        }
    }
}
