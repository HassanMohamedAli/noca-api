using System;
using System.Collections.Generic;
using System.Text;

namespace ArticleManagement.Domain.Entities
{
    public class BicycleCategory : BaseEntity
    {
        
        public string Name { get; set; }

        public ICollection<ArticleBicycleCategory> ArticleBicycleCategories { get; set; } = new List<ArticleBicycleCategory>();
     }

}
