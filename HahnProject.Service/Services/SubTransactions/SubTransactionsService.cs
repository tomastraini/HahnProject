using HahnProject.Domain.AggregatesModel.TransactionAggregate;

namespace HahnProject.Service
{
    public class SubTransactionsService : ISubTransactionsService
    {
        public SubTransactions tr = new SubTransactions();
        public List<SubTransactions> FindAll()
        {
            return tr.FindAll();
        }
        public SubTransactions FindById(long id)
        {
            return tr.FindById(id);
        }
        public void Insert(SubTransactions item)
        {
            tr.Insert(item);
        }
        public void Update(SubTransactions item)
        {
            tr.Update(item);
        }
        public void Delete(long id)
        {
            tr.Delete(id);
        }
    }
}
