using System;
using System.Collections.Generic;
using System.Text;

namespace ArticleManagement.Domain.Entities
{
    public abstract class BaseEntity
    {
       
            public int Id { get; set; }
            public DateTime CreatedOn { get; set; } = DateTime.UtcNow;
            public DateTime? UpdatedOn { get; set; }

            public string? CreatedBy { get; set; }
            public string? UpdatedBy { get; set; }
        public bool IsDeleted { get; set; }



    }



}
