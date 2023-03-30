using HahnProject.Domain.AggregatesModel.TransactionAggregate;

namespace HahnProject.Service
{
    public interface ISubTransactionsService
    {
        public List<SubTransactions> FindAll();
        public SubTransactions FindById(long id);
        public void Insert(SubTransactions item);
        public void Update(SubTransactions item);
        public void Delete(long id);
    }
}
