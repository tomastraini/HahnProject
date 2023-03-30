using HahnProject.Domain.AggregatesModel.PersonAggregate;

namespace HahnProject.Service
{
    public interface IPersonTypeService
    {
        public List<PersonType> FindAll();
        public PersonType FindById(long id);
        public void Insert(PersonType item);
        public void Update(PersonType item);
        public void Delete(long item);
    }
}
