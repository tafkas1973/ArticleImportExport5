using Office4U.Articles.ImportExport.Api.Data.Repositories.Interfaces;

namespace Office4U.Articles.ImportExport.Api.Data.Repositories
{
    public class RepositoryBase : IRepositoryBase
    {
        protected readonly DataContext _context;
        public RepositoryBase(DataContext context)
        {
            _context = context;
        }

        public void Update<T>(T entity)
        {
            _context.Update(entity);
        }
    }
}