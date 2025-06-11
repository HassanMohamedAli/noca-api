using ArticleManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArticleManagement.Application.DTOs
{
    public class ArticleDto : BaseEntity
    {
        public int ArticleId { get; set; }
        public string ArticleNumber { get; set; } 
        public string ArticleName { get; set; }  
        public int ArticleCategoryId { get; set; }  
        public List<int> BicycleCategoryIds { get; set; } 
        public int MaterialId { get; set; } 
        public int LengthInMm { get; set; }
        public int WidthInMm { get; set; }
        public int HeightInMm { get; set; }
        public int NetWeightInGramm { get; set; }
        public ArticleCategoryDto? ArticleCategory { get; set; }
        public MaterialDto? Material { get; set; }
        public ICollection<BicycleCategoryDto> ArticleBicycleCategories { get; set; } = new List<BicycleCategoryDto>();

    }

}
