using HahnProject.Domain.AggregatesModel.PersonAggregate;

namespace HahnProject.Service
{
    public class PersonService : IPersonService
    {
        public Person p = new Person();
        public List<Person> FindAll()
        {
            return p.FindAll();
        }

        public List<Person> FindAllByType(long id)
        {
            return p.FindAllByType(id).Where(x => x.persontype.ID == id).ToList();
        }

        public Person FindById(long id)
        {
            return p.FindById(id);
        }

        public void Insert(Person person)
        {
            p.Insert(person);
        }

        public void Update(Person person)
        {
            p.Update(person);
        }

        public void Delete(long id)
        {
            p.Delete(id);
        }
    }
}