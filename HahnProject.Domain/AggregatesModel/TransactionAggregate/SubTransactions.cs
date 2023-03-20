using BB.SmsQuiz.Infrastructure.Domain;
using HahnProject.Domain.AggregatesModel.ProductsAggregate;
using HahnProject.Domain.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HahnProject.Domain.AggregatesModel.TransactionAggregate
{
    public class SubTransactions : EntityBase, IAggregateRoot, BaseRepositoryMethods<SubTransactions>
    {
        public long ID { get; set; }
        public long transaction_id { get; set; }
        public long product_id { get; set; }
        public decimal amount { get; set; }
        public decimal total { get; set; }
        public Transactions transactions { get; set; }
        public Products products { get; set; }

        public List<SubTransactions> FindAll()
        {
            var response = (from p in ctx.subtransactions
                            join pr in ctx.products on p.product_id equals pr.id
                            select new SubTransactions()
                            {
                                ID = p.id,
                                product_id = p.product_id,
                                transaction_id = p.transaction_id,
                                amount = p.amount,
                                total = p.total,
                                products = new Products()
                                {

                                }
                            }).ToList();
            if (response == null)
                return new List<SubTransactions>();

            return response;
        }

        public SubTransactions FindById(long id)
        {
            var response = (from p in ctx.subtransactions
                            join pr in ctx.products on p.product_id equals pr.id
                            where p.transaction_id == id
                            select new SubTransactions()
                            {
                                ID = p.id,
                                product_id = p.product_id,
                                transaction_id = p.transaction_id,
                                amount = p.amount,
                                total = p.total,
                                products = new Products()
                                {
                                    ID = pr.id,
                                    description = pr.description,
                                    price = pr.price,
                                    stock = pr.stock,
                                }
                            }).FirstOrDefault();
            if (response == null)
                return new SubTransactions();

            return response;
        }

        public void Insert(SubTransactions st)
        {
            var productPrice = (from p in ctx.products
                                where p.id == st.product_id
                                select p.price).FirstOrDefault();

            var r = ctx.subtransactions.Add(new Infrastructure.PlainModels.SubTransactions()
            {
                amount = st.amount,
                product_id = st.product_id,
                total = st.amount * productPrice,
                transaction_id = st.transaction_id
            });
        }

        public void Update(SubTransactions st)
        {
            var result = ctx.subtransactions.FirstOrDefault(x => x.id == st.ID);
            if (result == null)
                return;
            var productPrice = (from p in ctx.products
                                where p.id == result.product_id
                                select p.price).FirstOrDefault();

            result.id = st.ID;
            result.amount = st.amount;
            result.product_id = st.product_id;
            result.transaction_id = st.transaction_id;
            result.total = st.amount * productPrice;

            ctx.SaveChanges();
        }

        public void Delete(long id)
        {
            var result = ctx.subtransactions.FirstOrDefault(x => x.id == id);
            if (result == null)
                return;
            ctx.subtransactions.Remove(result);

            ctx.SaveChanges();
        }

    }
}
