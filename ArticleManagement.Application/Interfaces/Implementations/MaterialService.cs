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
    public class MaterialService : IMaterialService
    {
        private readonly IMaterialRepository _repository;
        private readonly IMapper _mapper;

        public MaterialService(IMaterialRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<MaterialDto>> GetAllAsync()
        {
            var materials = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<MaterialDto>>(materials);
        }

        public async Task<MaterialDto?> GetByIdAsync(int id)
        {
            var material = await _repository.GetByIdAsync(id);
            return material != null ? _mapper.Map<MaterialDto>(material) : null;
        }

        public async Task<int> CreateAsync(MaterialDto materialDto)
        {
            var entity = _mapper.Map<Material>(materialDto);
            await _repository.AddAsync(entity);
            return entity.Id;
        }

        public async Task UpdateAsync(MaterialDto materialDto)
        {
            var entity = _mapper.Map<Material>(materialDto);
            await _repository.UpdateAsync(entity);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}
