using System.Collections.Generic;

namespace Office4U.Articles.ImportExport.Api.DTOs
{
    public class ArticleUpdateDto
    {
        public int Id { get; set; }
        public string SupplierId { get; set; }
        public string SupplierReference { get; set; }
        public string Name1 { get; set; }
    }
}