using Office4U.Articles.ImportExport.Api.Entities;

namespace Office4U.Articles.ImportExport.Api.Interfaces
{
    public interface IRepositoryBase
    {
        void Update<T>(T entity);
    }
}
