using System.Collections.Generic;
using System.Threading.Tasks;
using Office4U.Articles.ImportExport.Api.Entities;

namespace Office4U.Articles.ImportExport.Api.Interfaces
{
    public interface IArticleRepository
    {
        // TODO: use generics
        Task<IEnumerable<Article>> GetArticlesAsync();
        Task<Article> GetArticleByIdAsync(int id);
        void Update(Article article);
        Task<bool> SaveAllAsync();
    }
}