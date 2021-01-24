using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace Office4U.Articles.ImportExport.Api.Entities
{
    public class AppRole: IdentityRole<int>
    {
        public ICollection<AppUserRole> UserRoles { get; set; }
    }
}