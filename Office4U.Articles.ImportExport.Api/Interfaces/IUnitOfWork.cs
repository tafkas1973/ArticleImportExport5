using System.Threading.Tasks;

namespace Office4U.Articles.ImportExport.Api.Interfaces
{
    public interface IUnitOfWork
    {
        IUserRepository UserRepository { get; }
        IArticleRepository ArticleRepository { get; }

        Task<bool> Complete();

        bool HasChanges();
    }
}