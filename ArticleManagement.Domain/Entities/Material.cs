using System;
using System.Collections.Generic;
using System.Text;

namespace ArticleManagement.Domain.Entities
{

    public class Material : BaseEntity
    {
        public string Name { get; set; }
        public ICollection<Article> Articles { get; set; } = new List<Article>();
    }

}
