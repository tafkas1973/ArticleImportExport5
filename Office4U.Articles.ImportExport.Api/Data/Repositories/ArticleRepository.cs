using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Office4U.Articles.ImportExport.Api.Entities;
using Office4U.Articles.ImportExport.Api.Interfaces;

namespace Office4U.Articles.ImportExport.Api.Data.Repositories
{
    public class ArticleRepository : BaseRepository, IArticleRepository
    {
        public ArticleRepository(DataContext context) : base(context) { }

        public async Task<IEnumerable<Article>> GetArticlesAsync()
        {
            return await _context.Articles
                .Include(a => a.Photos)
                .ToListAsync();
        }

        public async Task<Article> GetArticleByIdAsync(int id)
        {
            return await _context.Articles
                .Include(a => a.Photos)
                .SingleOrDefaultAsync(a => a.Id == id);
        }
    }
}