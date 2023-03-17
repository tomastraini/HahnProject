using HahnProject.API.RequestEntities;
using HahnProject.Domain.AggregatesModel.ClientAggregate;
using HahnProject.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HahnProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        public Person person = new Person();
        [HttpGet]
        public ActionResult GetPerson()
        {
            return Ok(person.FindAll());
        }

        [HttpGet("{id}")]
        public ActionResult GetPeople(long id)
        {
            return Ok(person.FindById(id));
        }

        [HttpPost]
        public ActionResult InsertPerson(PersonR p)
        {
            person.Insert(new Person()
            { 
                business_name = p.business_name,
                balance = p.balance,
                persontype = new Domain.AggregatesModel.PersonAggregate.PersonType()
                {
                    ID = p.person_type
                }
            });
            return Ok();
        }

        [HttpPut]
        public ActionResult ModifyPerson(PersonR p)
        {
            person.Update(new Person()
            {
                ID = p.ID,
                business_name = p.business_name,
                balance = p.balance,
                persontype = new Domain.AggregatesModel.PersonAggregate.PersonType()
                {
                    ID = p.person_type
                }
            });
            return Ok();
        }

        [HttpDelete]
        public ActionResult ModifyPerson(long id)
        {
            person.Delete(id);
            return Ok();
        }
    }
}
