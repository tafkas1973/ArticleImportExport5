using Microsoft.AspNetCore.Identity;

namespace Office4U.Articles.ImportExport.Api.Entities
{
    public class AppUserRole: IdentityUserRole<int>
    {
        public AppUser User { get; set; }
        public AppRole Role { get; set; }
    }
}    
