using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using Office4U.Articles.ImportExport.Api.Extensions;

namespace Office4U.Articles.ImportExport.Api.Entities
{
    public class AppUser: IdentityUser<int>
    {
        public DateTime DateOfBirth { get; set; }
        public DateTime Created { get; set; } = DateTime.Now;
        public DateTime LastActive { get; set; } = DateTime.Now;
        public ICollection<AppUserRole> UserRoles { get; set; }
        public int GetAge() {
            return DateOfBirth.CalculateAge();
        }
    }
}
