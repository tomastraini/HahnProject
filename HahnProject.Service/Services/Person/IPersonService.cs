using HahnProject.Domain.AggregatesModel.PersonAggregate;

namespace HahnProject.Service
{
    public interface IPersonService
    {
        public List<Person> FindAll();
        public List<Person> FindAllByType(long id);
        public Person FindById(long id);
        public void Insert(Person person);
        public void Update(Person person);
        public void Delete(long id);
    }
}