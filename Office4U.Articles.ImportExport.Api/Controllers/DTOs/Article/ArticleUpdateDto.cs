using System.ComponentModel.DataAnnotations;

namespace Office4U.Articles.ImportExport.Api.Controllers.DTOs.Article
{
    public class ArticleUpdateDto
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string SupplierId { get; set; }

        [Required]
        [MaxLength(150)]
        public string SupplierReference { get; set; }
        [Required]
        public string Name1 { get; set; }
    }
}