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
            throw new NotImplementedException();
        }

        public PersonType FindById(long id)
        {
            throw new NotImplementedException();
        }

        public void Insert(PersonType item)
        {
            throw new NotImplementedException();
        }

        public void Update(PersonType item)
        {
            throw new NotImplementedException();
        }


        public void Delete(long id)
        {
            throw new NotImplementedException();
        }
    }
}
