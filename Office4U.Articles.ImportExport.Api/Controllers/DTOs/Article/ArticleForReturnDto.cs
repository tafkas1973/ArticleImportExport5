namespace Office4U.Articles.ImportExport.Api.Controllers.DTOs.Article
{
    public class ArticleForReturnDto
    {
        public string Code { get; set; }
        public string SupplierId { get; set; }       
        public string SupplierReference { get; set; }
        public string Name1 { get; set; }
        public string Unit { get; set; }
        public decimal PurchasePrice { get; set; }
    }
}