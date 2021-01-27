using System.ComponentModel.DataAnnotations;

namespace Office4U.Articles.ImportExport.Api.Controllers.DTOs.AppUser
{
    public class RegisterDto
    {
        [Required]
        public string Username { get; set; }
        [Required]
        [StringLength(8, MinimumLength = 4)]
        public string Password { get; set; }
    }
}
