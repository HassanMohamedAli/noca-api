using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArticleManagement.Domain.Entities
{
    public class ArticleCategory  : BaseEntity
    {
       
        public string Name { get; set; }

      
        public ICollection<Article> Articles { get; set; }
    }

}
