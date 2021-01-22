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

        public async Task<PagedList<Article>> GetArticlesAsync(
            ArticleParams articleParams)
        {
            var query = _context.Articles
                .Include(a => a.Photos)
                .AsQueryable();

            query = FilterQuery(articleParams, query);
            query = OrderByQuery(articleParams, query);

            return await PagedList<Article>.CreateAsync(
                query,
                articleParams.PageNumber,
                articleParams.PageSize);
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

        private static IQueryable<Article> FilterQuery(
            ArticleParams articleParams,
            IQueryable<Article> articles)
        {
            if (!string.IsNullOrEmpty(articleParams.Code))
            {
                articles = articles.Where(a => a.Code.Contains(articleParams.Code));
            }

            if (!string.IsNullOrEmpty(articleParams.SupplierId))
            {
                articles = articles.Where(a => a.SupplierId.Contains(articleParams.SupplierId));
            }

            if (!string.IsNullOrEmpty(articleParams.SupplierReference))
            {
                articles = articles.Where(a => a.SupplierReference.Contains(articleParams.SupplierReference));
            }

            if (!string.IsNullOrEmpty(articleParams.Name1))
            {
                articles = articles.Where(a => a.Name1.Contains(articleParams.Name1));
            }

            if (!string.IsNullOrEmpty(articleParams.Unit))
            {
                articles = articles.Where(a => a.Unit == articleParams.Unit);
            }

            if (articleParams.PurchasePriceMin != null)
            {
                articles = articles.Where(a => a.PurchasePrice >= articleParams.PurchasePriceMin);
            }

            if (articleParams.PurchasePriceMax != null)
            {
                articles = articles.Where(a => a.PurchasePrice <= articleParams.PurchasePriceMax);
            }

            return articles;
        }

        private static IQueryable<Article> OrderByQuery(
            ArticleParams articleParams,
            IQueryable<Article> articles)
        {
            articles = articleParams.OrderBy switch
            {
                "code" => articles.OrderBy(a => a.Code),
                "supplierReference" => articles.OrderBy(a => a.SupplierReference),
                _ => articles.OrderBy(a => a.Id)
            };

            return articles;
        }
    }
}