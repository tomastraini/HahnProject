namespace HahnProject.API.RequestEntities
{
    public class TransactionR
    {
        public long ID { get; set; }
        public long person { get; set; }
        public DateTime transaction_began { get; set; }
        public decimal total { get; set; }
    }
}
