using HahnProject.Domain.AggregatesModel.TransactionAggregate;

namespace HahnProject.Service
{
    public interface ITransactionsService
    {
        public List<Transactions> FindAll();
        public Transactions FindById(long id);
        public void Insert(Transactions item);
        public void Update(Transactions item);
        public void Delete(long id);
    }
}
