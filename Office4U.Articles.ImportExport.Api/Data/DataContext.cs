using Office4U.Articles.ImportExport.Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace Office4U.Articles.ImportExport.Api.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }
        
        public DbSet<AppUser> Users { get; set; }
        public DbSet<Article> Articles { get; set; }
        public DbSet<ArticlePhoto> ArticlePhotos { get; set; }
    }
}
