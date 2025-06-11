using ArticleManagement.Domain.Entities;
using ArticleManagement.Infrastructure.Identity;
 using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArticleManagement.Infrastructure.Persistence
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Article> Articles { get; set; }
        public DbSet<BicycleCategory> BicycleCategories { get; set; }
        public DbSet<Material> Materials { get; set; }
        public DbSet<ArticleBicycleCategory> ArticleBicycleCategories { get; set; }
        public DbSet<ArticleCategory> ArticleCategory { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);


            modelBuilder.Entity<ArticleCategory>()
     .HasMany(c => c.Articles)
     .WithOne(a => a.ArticleCategory)
     .HasForeignKey(a => a.ArticleCategoryId);
            // Global Query Filters
            modelBuilder.Entity<Article>().HasQueryFilter(a => !a.IsDeleted);
            modelBuilder.Entity<BicycleCategory>().HasQueryFilter(b => !b.IsDeleted);

            // Optional relationship between ArticleBicycleCategory and Article
            modelBuilder.Entity<ArticleBicycleCategory>()
                .HasOne(ab => ab.Article)
                .WithMany(a => a.ArticleBicycleCategories)
                .HasForeignKey(ab => ab.ArticleId)
               ;
        }



    }


}
