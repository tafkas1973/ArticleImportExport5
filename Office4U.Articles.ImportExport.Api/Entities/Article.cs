namespace Api.Entities
{
    public class Article
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string SupplierId { get; set; }
        public string SupplierReference { get; set; }
        public string Name1 { get; set; }
        public string Unit { get; set; }
        public decimal PurchasePrice { get; set; }
    }
}