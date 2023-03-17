namespace HahnProject.API.RequestEntities
{
    public class ProductsR
    {
        public long id { get; set; }
        public string description { get; set; }
        public decimal price { get; set; }
        public decimal stock { get; set; }
        public long supplier_id { get; set; }
    }
}
