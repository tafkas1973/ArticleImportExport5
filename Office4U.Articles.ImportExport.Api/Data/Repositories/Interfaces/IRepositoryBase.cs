using Office4U.Articles.ImportExport.Api.Entities;

namespace Office4U.Articles.ImportExport.Api.Data.Repositories.Interfaces
{
    public interface IRepositoryBase
    {
        void Update<T>(T entity);
    }
}
