using HahnProject.Domain.AggregatesModel.PersonAggregate;

namespace HahnProject.Service
{
    public class PersonTypeService : IPersonTypeService
    {
        public PersonType pt = new PersonType();
        public List<PersonType> FindAll()
        {
            return pt.FindAll();
        }

        public PersonType FindById(long id)
        {
            return pt.FindById(id);
        }
        public void Insert(PersonType item)
        {
            pt.Insert(item);
        }
        public void Update(PersonType item)
        {
            pt.Update(item);
        }
        public void Delete(long id)
        {
            pt.Delete(id);
        }
    }
}
