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
    public class BicycleCategoryConfiguration : IEntityTypeConfiguration<BicycleCategory>
    {
        public void Configure(EntityTypeBuilder<BicycleCategory> builder)
        {
            builder.HasKey(b => b.Id);

            builder.Property(b => b.Name)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.HasMany(b => b.ArticleBicycleCategories)
                   .WithOne(ab => ab.BicycleCategory)
                   .HasForeignKey(ab => ab.BicycleCategoryId);
        }
    }
}
