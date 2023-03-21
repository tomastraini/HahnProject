using BB.SmsQuiz.Infrastructure.Domain;
using HahnProject.Domain.Domain;
using HahnProject.Infrastructure.PlainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HahnProject.Domain.AggregatesModel.TransactionAggregate
{
    public class Transactions : EntityBase, IAggregateRoot, BaseRepositoryMethods<Transactions>
    {
        public long ID { get; set; }
        public long person { get; set; }
        public DateTime transaction_began { get; set; }
        public decimal total { get; set; }
        public Person persondata { get; set; }
        public List<SubTransactions> SubTransactions { get; set; }

        public List<Transactions> FindAll()
        {
            var transactions = (from t in ctx.transactions
                                join p in ctx.person on t.person equals p.id
                                join pt in ctx.persontype on p.person_type equals pt.id
                                select new Transactions()
                                {
                                    ID = t.id,
                                    person = t.person,
                                    total = t.total,
                                    transaction_began = t.transaction_began,
                                    persondata = new Person()
                                    {
                                        id = p.id,
                                        balance = p.balance,
                                        business_name = p.business_name,
                                        creation_date = p.creation_date,
                                        PersonType = new PersonType()
                                        {
                                            id = pt.id,
                                            type = pt.type
                                        }
                                    },
                                    SubTransactions = new List<SubTransactions>()
                                }).ToList();
            var SubTransactions = (from p in ctx.subtransactions
                                   join pr in ctx.products on p.product_id equals pr.id
                                   join per in ctx.person on pr.supplier_id equals per.id
                                   select new SubTransactions()
                                   {
                                       ID = p.id,
                                       product_id = p.product_id,
                                       transaction_id = p.transaction_id,
                                       amount = p.amount,
                                       total = p.total,
                                       products = new ProductsAggregate.Products()
                                       {
                                           ID = pr.id,
                                           description = pr.description,
                                           price = pr.price,
                                           stock = pr.stock,
                                           supplier = new PersonAggregate.Person()
                                           {
                                               business_name = per.business_name
                                           }
                                       }
                                   }).ToList();
            transactions.ForEach(x =>
            {
                var subtransactions = SubTransactions.Where(y => y.transaction_id == x.ID).ToList();
                subtransactions.ForEach(st =>
                {
                    x.SubTransactions.Add(new TransactionAggregate.SubTransactions()
                    {
                        ID = st.ID,
                        amount = st.amount,
                        product_id = st.product_id,
                        total = st.total,
                        transaction_id = st.transaction_id,
                        products = new ProductsAggregate.Products()
                        {
                            description = st.products.description,
                            price = st.products.price,
                            stock = st.products.stock,
                            supplier = st.products.supplier
                        }
                    });
                });

            });
            if (transactions == null)
                return new List<Transactions>();

            return transactions;
        }

        public Transactions FindById(long id)
        {
            var transactions = (from t in ctx.transactions
                                join p in ctx.person on t.person equals p.id
                                join pt in ctx.persontype on p.person_type equals pt.id
                                where t.id == id
                                select new Transactions()
                                {
                                    ID = t.id,
                                    person = t.person,
                                    total = t.total,
                                    transaction_began = t.transaction_began,
                                    persondata = new Person()
                                    {
                                        id = p.id,
                                        balance = p.balance,
                                        business_name = p.business_name,
                                        creation_date = p.creation_date,
                                        PersonType = new PersonType()
                                        {
                                            id = pt.id,
                                            type = pt.type
                                        }
                                    },
                                    SubTransactions = new List<SubTransactions>()
                                }).FirstOrDefault();
            if (transactions == null)
                return new Transactions();
            var SubTransactions = (from p in ctx.subtransactions
                                   join pr in ctx.products on p.product_id equals pr.id
                                   join per in ctx.person on pr.supplier_id equals per.id
                                   where p.transaction_id == transactions.ID
                                   select new SubTransactions()
                                   {
                                       ID = p.id,
                                       product_id = p.product_id,
                                       transaction_id = p.transaction_id,
                                       amount = p.amount,
                                       total = p.total,
                                       products = new ProductsAggregate.Products()
                                       {
                                           ID = pr.id,
                                           description = pr.description,
                                           price = pr.price,
                                           stock = pr.stock,
                                           supplier = new PersonAggregate.Person()
                                           {
                                               business_name = per.business_name
                                           }
                                       }
                                   }).ToList();

            SubTransactions.ForEach(st =>
            {
                transactions.SubTransactions.Add(new TransactionAggregate.SubTransactions()
                {
                    ID = st.ID,
                    amount = st.amount,
                    product_id = st.product_id,
                    total = st.total,
                    transaction_id = st.transaction_id,
                    products = new ProductsAggregate.Products()
                    {
                        description = st.products.description,
                        price = st.products.price,
                        stock = st.products.stock,
                        supplier = st.products.supplier
                    }
                });
            });

            return transactions;
        }

        public void Insert(Transactions t)
        {
            ctx.transactions.Add(new Infrastructure.PlainModels.Transactions()
            {
                person = t.person,
                total = t.total,
                transaction_began = DateTime.Now
            });

            ctx.SaveChanges();
        }

        public void Update(Transactions t)
        {
            var result = ctx.transactions.FirstOrDefault(x => x.id == t.ID);
            if (result == null)
                return;
            result.id = t.ID;
            result.person = t.person;
            result.total = t.total;
            result.transaction_began = t.transaction_began;

            ctx.SaveChanges();
        }

        public void Delete(long id)
        {
            var result = ctx.transactions.FirstOrDefault(x => x.id == id);
            if (result == null)
                return;
            ctx.transactions.Remove(result);

            ctx.SaveChanges();
        }

    }
}
