using System.Threading.Tasks;
using Office4U.Articles.ImportExport.Api.Data.Repositories.Interfaces;

namespace Office4U.Articles.ImportExport.Api.Data.Repositories
{
    public class UnitOfWork: IUnitOfWork
    {
        private readonly DataContext _context;
        public UnitOfWork(DataContext context)
        {
            _context = context;
        }

        public IUserRepository UserRepository => new UserRepository(_context);

        public IArticleRepository ArticleRepository => new ArticleRepository(_context);

        public async Task<bool> Complete()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public bool HasChanges()
        {
            return _context.ChangeTracker.HasChanges();
        }
    }
}
