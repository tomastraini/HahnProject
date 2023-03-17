using BB.SmsQuiz.Infrastructure.Domain;
using HahnProject.Domain.AggregatesModel.ClientAggregate;
using HahnProject.Domain.AggregatesModel.PersonAggregate;
using HahnProject.Domain.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HahnProject.Domain.AggregatesModel.ProductsAggregate
{
    public class Products : EntityBase, IAggregateRoot, BaseRepositoryMethods<Products>
    {
        public long ID { get; set; }
        public string description { get; set; }
        public decimal price { get; set; }
        public decimal stock { get; set; }
        public Person supplier { get; set; }

        public List<Products> FindAll()
        {
            var response = (from p in ctx.products
                            join s in ctx.person on p.supplier_id equals s.id
                            join pt in ctx.persontype on s.person_type equals pt.id
                            select new Products()
                            {
                                ID = p.id,
                                description = p.description,
                                price = p.price,
                                stock = p.stock,
                                supplier = new Person()
                                {
                                    ID = s.id,
                                    balance = s.balance,
                                    business_name = s.business_name,
                                    creation_date = s.creation_date,
                                    persontype = new PersonType()
                                    {
                                        ID = pt.id,
                                        type = pt.type
                                    }
                                }
                            }).ToList();
            if (response == null)
                return new List<Products>();

            return response;
        }

        public Products FindById(long id)
        {
            var response = (from p in ctx.products
                            join s in ctx.person on p.supplier_id equals s.id
                            join pt in ctx.persontype on s.person_type equals pt.id
                            where p.id == id
                            select new Products()
                            {
                                ID = p.id,
                                description = p.description,
                                price = p.price,
                                stock = p.stock,
                                supplier = new Person()
                                {
                                    ID = s.id,
                                    balance = s.balance,
                                    business_name = s.business_name,
                                    creation_date = s.creation_date,
                                    persontype = new PersonType()
                                    {
                                        ID = pt.id,
                                        type = pt.type
                                    }
                                }
                            }).FirstOrDefault();
            if (response == null)
                return new Products();

            return response;
        }

        public void Insert(Products p)
        {
            ctx.products.Add(new Infrastructure.PlainModels.Products()
            {
                id = p.ID,
                description = p.description,
                price = p.price,
                stock = p.stock,
                supplier_id = p.supplier.ID
            });

            ctx.SaveChanges();
        }

        public void Update(Products item)
        {
            var result = ctx.products.FirstOrDefault(x => x.id == item.ID);
            if (result == null)
                return;
            result.id = item.ID;
            result.description = item.description;
            result.price = item.price;
            result.stock = item.stock;
            result.supplier_id = item.supplier.ID;
            ctx.SaveChanges();
        }


        public void Delete(long id)
        {
            var result = ctx.products.FirstOrDefault(x => x.id == id);
            if (result == null)
                return;
            ctx.products.Remove(result);

            ctx.SaveChanges();
        }
    }
}
