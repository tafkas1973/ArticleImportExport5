using System.Threading.Tasks;
using Office4U.Articles.ImportExport.Api.Entities;
using Office4U.Articles.ImportExport.Api.Helpers;

namespace Office4U.Articles.ImportExport.Api.Interfaces
{
    public interface IUserRepository: IRepositoryBase
    {
        Task<PagedList<AppUser>> GetUsersAsync(UserParams userParams);
        Task<AppUser> GetUserByIdAsync(int id);
        Task<AppUser> GetUserByUsernameAsync(string username);            
    }
}