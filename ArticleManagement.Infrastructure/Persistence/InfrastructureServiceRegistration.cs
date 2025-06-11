


using ArticleManagement.Application.Interfaces.Repositories;
using ArticleManagement.Application.Interfaces.Services;
using ArticleManagement.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArticleManagement.Infrastructure.Persistence
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

         

            services.AddScoped<IArticleRepository, ArticleRepository>();
            services.AddScoped<IMaterialRepository, MaterialRepository>();
            services.AddScoped<IArticleCategoryRepository, ArticleCategoryRepository>();

            services.AddScoped<IBicycleCategoryRepository, BicycleCategoryRepository>();
            return services;
        }
    }
}
