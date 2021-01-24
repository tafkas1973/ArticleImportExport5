using System.Threading.Tasks;
using Office4U.Articles.ImportExport.Api.Entities;

namespace Office4U.Articles.ImportExport.Api.Interfaces
{
    public interface ITokenService
    {
        Task<string> CreateToken(AppUser user);
    }
}
