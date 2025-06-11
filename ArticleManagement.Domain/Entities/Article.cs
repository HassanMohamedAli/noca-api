using System;
using System.Collections.Generic;
using System.Text;

namespace ArticleManagement.Domain.Entities
{
    public class Article  : BaseEntity
    {
       
        public string ArticleNumber { get; set; } 
        public   string ArticleName { get; set; } 
        public   int ArticleCategoryId { get; set; }
   
        public int MaterialId { get; set; }

        public int LengthInMm { get; set; }
        public int WidthInMm { get; set; }
        public int HeightInMm { get; set; }
        public int NetWeightInGramm { get; set; }

        public ArticleCategory ArticleCategory { get; set; }
        public Material Material { get; set; }
        public ICollection<ArticleBicycleCategory> ArticleBicycleCategories { get; set; } = new List<ArticleBicycleCategory>();
    }

}
