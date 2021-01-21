using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Office4U.Articles.ImportExport.Api.Entities;
using Office4U.Articles.ImportExport.Api.Helpers;
using Office4U.Articles.ImportExport.Api.Interfaces;

namespace Office4U.Articles.ImportExport.Api.Data.Repositories
{
    public class ArticleRepository : BaseRepository, IArticleRepository
    {
        public ArticleRepository(DataContext context) : base(context) { }

        public async Task<PagedList<Article>> GetArticlesAsync(UserParams userParams)
        {
            var articles = _context.Articles
                .Include(a => a.Photos)
                .AsQueryable();

            return await PagedList<Article>.CreateAsync(
                articles,
                userParams.PageNumber,
                userParams.PageSize);
            }

        public async Task<Article> GetArticleByIdAsync(int id)
        {
            return await _context.Articles
                .Include(a => a.Photos)
                .SingleOrDefaultAsync(a => a.Id == id);
        }

        public async Task<bool> SaveAllAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public void Update(Article article)
        {
            _context.Entry(article).State = EntityState.Modified;
        }
    }
}