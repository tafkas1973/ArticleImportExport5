using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Office4U.Articles.ImportExport.Api.Data;
using Office4U.Articles.ImportExport.Api.Data.Repositories;
using Office4U.Articles.ImportExport.Api.Data.Repositories.Interfaces;
using Office4U.Articles.ImportExport.Api.Helpers;
using Office4U.Articles.ImportExport.Api.Services;
using Office4U.Articles.ImportExport.Api.Services.Interfaces;

namespace Office4U.Articles.ImportExport.Api.Extensions
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IArticleRepository, ArticleRepository>();
            services.AddAutoMapper(typeof(AutoMapperProfiles).Assembly);
            services.AddDbContext<DataContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            });

            return services;
        }
    }
}