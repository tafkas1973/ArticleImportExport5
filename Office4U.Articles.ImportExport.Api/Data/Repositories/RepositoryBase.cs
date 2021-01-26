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

        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Update<T>(T entity)
        {
            _context.Update(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }
    }
}