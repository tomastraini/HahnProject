namespace HahnProject.API.RequestEntities
{
    public class SubTransactionR
    {
        public long ID { get; set; }
        public long transaction_id { get; set; }
        public long product_id { get; set; }
        public decimal amount { get; set; }
        public decimal total { get; set; }
    }
}
