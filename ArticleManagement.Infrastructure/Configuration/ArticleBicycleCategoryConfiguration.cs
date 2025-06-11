using ArticleManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArticleManagement.Infrastructure.Configuration
{
    public class ArticleBicycleCategoryConfiguration : IEntityTypeConfiguration<ArticleBicycleCategory>
    {
        public void Configure(EntityTypeBuilder<ArticleBicycleCategory> builder)
        {
            builder.HasKey(ab => new { ab.ArticleId, ab.BicycleCategoryId });

            builder.HasOne(ab => ab.Article)
                   .WithMany(a => a.ArticleBicycleCategories)
                   .HasForeignKey(ab => ab.ArticleId);

            builder.HasOne(ab => ab.BicycleCategory)
                   .WithMany(b => b.ArticleBicycleCategories)
                   .HasForeignKey(ab => ab.BicycleCategoryId);
        }
    }
}
