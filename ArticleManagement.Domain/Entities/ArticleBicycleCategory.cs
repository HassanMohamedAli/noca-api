using System;
using System.Collections.Generic;
using System.Text;

namespace ArticleManagement.Domain.Entities
{
    public class ArticleBicycleCategory
    {
        public int ArticleId { get; set; }
        public Article Article { get; set; }
        public int BicycleCategoryId { get; set; }
        public BicycleCategory BicycleCategory { get; set; }
       
    }

}
