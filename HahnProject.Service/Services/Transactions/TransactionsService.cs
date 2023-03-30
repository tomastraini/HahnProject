
using HahnProject.Domain.AggregatesModel.TransactionAggregate;

namespace HahnProject.Service
{
    public class TransactionsService : ITransactionsService
    {
        public Transactions t = new Transactions();
        public SubTransactions subt = new SubTransactions();
        public List<Transactions> FindAll()
        {
            return t.FindAll();
        }
        public Transactions FindById(long id)
        {
            return t.FindById(id);
        }
        public void Insert(Transactions item)
        {
            t.Insert(item);
        }
        public void Update(Transactions item)
        {
            t.Update(item);
        }
        public void Delete(long id)
        {
            t.Delete(id);
        }
    }
}
