using ArticleManagement.Application.DTOs;
using ArticleManagement.Domain.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArticleManagement.Application.Mapping
{
   
        public class MappingProfile : Profile
        {
            public MappingProfile()
            {
                // Article <-> ArticleDto
                CreateMap<Article, ArticleDto>().ReverseMap();

                // Material <-> MaterialDto
                CreateMap<Material, MaterialDto>().ReverseMap();
            CreateMap<ArticleCategory, ArticleCategoryDto>().ReverseMap();


            // BicycleCategory <-> BicycleCategoryDto
            CreateMap<BicycleCategory, BicycleCategoryDto>().ReverseMap();
            }
        
    }
}
