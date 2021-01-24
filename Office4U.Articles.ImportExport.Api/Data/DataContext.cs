using Office4U.Articles.ImportExport.Api.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace Office4U.Articles.ImportExport.Api.Data
{
    public class DataContext :
       IdentityDbContext<
           AppUser,
           AppRole,
           int,
           IdentityUserClaim<int>,
           AppUserRole,
           IdentityUserLogin<int>,
           IdentityRoleClaim<int>,
           IdentityUserToken<int>
       >
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Article> Articles { get; set; }
        public DbSet<ArticlePhoto> ArticlePhotos { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<AppUser>()
                .HasMany(u => u.UserRoles)
                .WithOne(ur => ur.User)
                .HasForeignKey(u => u.UserId)
                .IsRequired();

            builder.Entity<AppRole>()
                .HasMany(ar => ar.UserRoles)
                .WithOne(ur => ur.Role)
                .HasForeignKey(r => r.RoleId)
                .IsRequired();
        }
    }
}
