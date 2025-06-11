using ArticleManagement.Application.DTOs;
using ArticleManagement.Application.Interfaces.Repositories;
using ArticleManagement.Application.Interfaces.Services;
using ArticleManagement.Domain.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArticleManagement.Application.Interfaces.Implementations
{
    public class ArticleCategoryService : IArticleCategoryService
    {
      
            private readonly IArticleCategoryRepository _repository;
            private readonly IMapper _mapper;

            public ArticleCategoryService(IArticleCategoryRepository repository, IMapper mapper)
            {
                _repository = repository;
                _mapper = mapper;
            }

            public async Task<IEnumerable<ArticleCategoryDto>> GetAllAsync()
            {
                var materials = await _repository.GetAllAsync();
                return _mapper.Map<IEnumerable<ArticleCategoryDto>>(materials);
            }

            public async Task<ArticleCategoryDto?> GetByIdAsync(int id)
            {
                var material = await _repository.GetByIdAsync(id);
                return material != null ? _mapper.Map<ArticleCategoryDto>(material) : null;
            }

            public async Task<int> CreateAsync(ArticleCategoryDto materialDto)
            {
                var entity = _mapper.Map<ArticleCategory>(materialDto);
                await _repository.AddAsync(entity);
                return entity.Id;
            }

            public async Task UpdateAsync(ArticleCategoryDto materialDto)
            {
                var entity = _mapper.Map<ArticleCategory>(materialDto);
                await _repository.UpdateAsync(entity);
            }

            public async Task DeleteAsync(int id)
            {
                await _repository.DeleteAsync(id);
            }
        
    }
}
