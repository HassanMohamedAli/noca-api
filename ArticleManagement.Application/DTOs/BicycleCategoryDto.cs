using ArticleManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArticleManagement.Application.DTOs
{
    public class BicycleCategoryDto : BaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
     public BicycleCategoryDto? BicycleCategory { get; set; }
    }
}
