using BB.SmsQuiz.Infrastructure.Domain;
using HahnProject.Domain.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HahnProject.Domain.AggregatesModel.PersonAggregate
{
    public class PersonType : EntityBase, IAggregateRoot, BaseRepositoryMethods<PersonType>
    {

        public long ID { get; set; }
        public string type { get; set; }


        public List<PersonType> FindAll()
        {
            var response = (from p in ctx.persontype
                     select new PersonType()
                     {
                         ID = p.id,
                         type = p.type,
                            
                     }).ToList();
            if (response == null)
                return new List<PersonType>();

            return response;
        }

        public PersonType FindById(long id)
        {
            var x = (from p in ctx.persontype
                     where p.id.Equals((int)id)
                     select new PersonType()
                     {
                         ID = p.id,
                         type = p.type,
                     }).FirstOrDefault();
            if (x == null)
                return new PersonType();
            var response = new PersonType()
            {
                ID = x.ID,
                type = x.type
            };

            return response;
        }

        public void Insert(PersonType item)
        {
            ctx.persontype.Add(new Infrastructure.PlainModels.PersonType()
            {
                type = item.type
            });

            ctx.SaveChanges();
        }

        public void Update(PersonType item)
        {
            var result = ctx.persontype.FirstOrDefault(x => x.id == item.ID);
            if (result == null)
                return;
            result.type = item.type;

            ctx.SaveChanges();
        }


        public void Delete(long id)
        {
            var result = ctx.persontype.FirstOrDefault(x => x.id == id);
            if (result == null)
                return;
            ctx.persontype.Remove(result);

            ctx.SaveChanges();
        }
    }
}
