using BB.SmsQuiz.Infrastructure.Domain;
using HahnProject.Domain.AggregatesModel.PersonAggregate;
using HahnProject.Domain.Domain;
using HahnProject.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HahnProject.Domain.AggregatesModel.ClientAggregate
{
    public class Person : EntityBase, IAggregateRoot, BaseRepositoryMethods<Person>
    {
        public readonly Context ctx = new Context();

        public long ID { get; set; }
        public string business_name { get; set; }
        public decimal balance { get; set;}
        public DateTime creation_date { get; set;}
        public PersonType persontype { get; set;}

        

        public Person FindById(long id)
        {
            var x = (from p in ctx.person
                            join pt in ctx.persontype on p.person_type equals pt.id
                            where p.id.Equals(id)
                            select new Person()
                            {
                                ID = p.id,
                                business_name =p.business_name,
                                balance = p.balance,
                                creation_date = p.creation_date,
                                persontype  = persontype,
                            }
                       ).FirstOrDefault();
            if (x == null)
                return new Person();
            var response = new Person()
            {
                ID = x.ID,
                business_name = x.business_name,
                balance = x.balance,
                creation_date = x.creation_date,
                persontype = new PersonType()
                {
                    ID = x.persontype.ID,
                    type = x.persontype.type
                }
            };
                    
            return response;
        }

        public List<Person> FindAll()
        {
            var dbresult = (from p in ctx.person
                            join pt in ctx.persontype on p.person_type equals pt.id
                            select new Person()
                            {
                                ID = p.id,
                                business_name = p.business_name,
                                balance = p.balance,
                                creation_date = p.creation_date,
                                persontype = persontype,
                            }
                       ).ToList();

            var response = new List<Person>();
            dbresult.ForEach(x =>
            {
                response.Add(new Person()
                {
                    ID = x.ID,
                    business_name = x.business_name,
                    balance = x.balance,
                    creation_date = x.creation_date,
                    persontype = new PersonType()
                    {
                        ID = x.persontype.ID,
                        type = x.persontype.type
                    }
                    
                });
            });
            return response;
        }

        public void Insert(Person item)
        {
            throw new NotImplementedException();
        }

        public void Update(Person item)
        {
            throw new NotImplementedException();
        }

        public void Delete(long id)
        {
            throw new NotImplementedException();
        }
    }
}
