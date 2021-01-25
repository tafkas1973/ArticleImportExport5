using System.Threading.Tasks;
using Office4U.Articles.ImportExport.Api.Entities;
using Office4U.Articles.ImportExport.Api.Helpers;

namespace Office4U.Articles.ImportExport.Api.Interfaces
{
    public interface IArticleRepository: IRepositoryBase
    {
        Task<PagedList<Article>> GetArticlesAsync(ArticleParams articleParams);
        Task<Article> GetArticleByIdAsync(int id);
    }
}