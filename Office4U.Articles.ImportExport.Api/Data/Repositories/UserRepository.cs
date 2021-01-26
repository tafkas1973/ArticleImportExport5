using Microsoft.EntityFrameworkCore;
using Office4U.Articles.ImportExport.Api.Entities;
using Office4U.Articles.ImportExport.Api.Helpers;
using Office4U.Articles.ImportExport.Api.Data.Repositories.Interfaces;
using System.Linq;
using System.Threading.Tasks;

namespace Office4U.Articles.ImportExport.Api.Data.Repositories
{
    public class UserRepository : RepositoryBase, IUserRepository
    {
        public UserRepository(DataContext context) : base(context) { }

        public async Task<AppUser> GetUserByIdAsync(int id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task<AppUser> GetUserByUsernameAsync(string username)
        {
            return await _context.Users
                .Include(u => u.Photos)
                .SingleOrDefaultAsync(u => u.UserName == username);
        }

        public async Task<PagedList<AppUser>> GetUsersAsync(UserParams userParams)
        {
            var users = _context.Users
                .Include(u => u.Photos)
                .AsQueryable();

            return await PagedList<AppUser>.CreateAsync(
                users,
                userParams.PageNumber,
                userParams.PageSize);
        }
    }
}