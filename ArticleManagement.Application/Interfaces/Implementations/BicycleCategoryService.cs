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
    public class BicycleCategoryService : IBicycleCategoryService
    {
        private readonly IBicycleCategoryRepository _repository;
        private readonly IMapper _mapper;

        public BicycleCategoryService(IBicycleCategoryRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<BicycleCategoryDto>> GetAllAsync()
        {
            var categories = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<BicycleCategoryDto>>(categories);
        }

        public async Task<BicycleCategoryDto?> GetByIdAsync(int id)
        {
            var category = await _repository.GetByIdAsync(id);
            return _mapper.Map<BicycleCategoryDto?>(category);
        }

        public async Task<int> CreateAsync(BicycleCategoryDto dto)
        {
            var entity = _mapper.Map<BicycleCategory>(dto);
            await _repository.AddAsync(entity);
            return entity.Id;
        }

        public async Task UpdateAsync(BicycleCategoryDto dto)
        {
            var entity = _mapper.Map<BicycleCategory>(dto);
            await _repository.UpdateAsync(entity);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}
