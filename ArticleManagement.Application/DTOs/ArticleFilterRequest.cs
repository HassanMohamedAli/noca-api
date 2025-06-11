using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArticleManagement.Application.DTOs
{
    public class ArticleFilterDto
    {
        public int? ArticleCategoryId { get; set; }
        public List<int>? BicycleCategoryIds { get; set; }
        public int? MaterialId { get; set; }
    }

}
