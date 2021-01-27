using System.Threading.Tasks;

namespace Office4U.Articles.ImportExport.Api.Data.Repositories.Interfaces
{
    public interface IUnitOfWork
    {
        IUserRepository UserRepository { get; }
        IArticleRepository ArticleRepository { get; }
        Task<bool> Commit();
        bool HasChanges();
    }
}